using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using MauiGithubSearch.Data.Api.Github.Response;
using MauiGithubSearch.Domain.exception;

namespace MauiGithubSearch.Data.Api.Github
{
    /// <summary>
    ///  statuscode: https://github.com/microsoft/referencesource/blob/master/System/net/System/Net/HttpStatusCode.cs
    ///  jsonの扱いはSystem.Text.Json が推奨されている : https://learn.microsoft.com/ja-jp/dotnet/standard/serialization/system-text-json/migrate-from-newtonsoft?pivots=dotnet-7-0
    /// </summary>
    public class GithubApi
    {
        private const string GITHUB_ACCESS_TOKEN = "";
        private const string GITHUB_API_DOMAIN = "https://api.github.com";
        private readonly HttpClient _httpClient;
        public List<String> Data { set; get; }
        public GithubApi()
        {
            Console.WriteLine("GithubApi hashcode: " + this.GetHashCode());
            _httpClient = new();
            Data = new();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //_httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {GITHUB_ACCESS_TOKEN}");
            _httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            _httpClient.Timeout = new(0, 0, 0,30);

        }
        public async Task<SearchRepositoriesResponse> searchRepositories(string query, int page, int perPage = 20, string sort = "stars")
        {
            var url = GITHUB_API_DOMAIN + $"/search/repositories?q={query}&page={page}&per_page={perPage}&sort={sort}";
            return await dataOrThrow<SearchRepositoriesResponse>(new(HttpMethod.Get, url));
        }

        private static GithubErrorResponse JsonToGithubErrorResponse(string json) => JsonSerializer.Deserialize<GithubErrorResponse>(json);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns>正常系： json文字列を返す 異常系: カスタムExceptionをthrowする</returns>
        private async Task<T> dataOrThrow<T>(HttpRequestMessage message)
        {
            try
            {
                var response = await _httpClient.SendAsync(message);
                var responseBodyJson = await response.Content.ReadAsStringAsync();
                var statusCodeValue = (int)response.StatusCode;
                return statusCodeValue switch
                {
                    ((int)HttpStatusCode.OK) => JsonSerializer.Deserialize<T>(responseBodyJson),
                    >= ((int)HttpStatusCode.MultipleChoices) and <= ((int)HttpStatusCode.PermanentRedirect) => throw new RedirectException(message: responseBodyJson), // 300番台エラー
                    ((int)HttpStatusCode.Unauthorized) => throw new UnAuthorizedException(message: JsonToGithubErrorResponse(responseBodyJson).Message),
                    ((int) HttpStatusCode.NotFound) => throw new NotFoundException(message: JsonToGithubErrorResponse(responseBodyJson).Message),
                    ((int) HttpStatusCode.Forbidden) => throw new ForbiddenExeption(message: JsonToGithubErrorResponse(responseBodyJson).Message),
                    ((int) HttpStatusCode.UnprocessableEntity) => throw new UnprocessableEntityException(message: JsonToGithubErrorResponse(responseBodyJson).Message),
                    >= ((int)HttpStatusCode.InternalServerError) and <= ((int)HttpStatusCode.NotExtended) => throw new ServerException(message: responseBodyJson), // 500番台エラー
                    _ => throw new UnknownException(message: responseBodyJson)

                };
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
            {
                // TaskCanceledExceptionは接続タイムアウト時にthrowされる
                // HttpRequestExceptionは、通信OFF時にthrowされる
                throw new NetworkException(message: ex.Message);
            }
        }
    }
}