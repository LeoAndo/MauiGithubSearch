using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using MauiGithubSearch.Data.Api.Github.Response;

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
            _httpClient = new();
            Data = new();
            // 共通のヘッダー設定
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {GITHUB_ACCESS_TOKEN}");
            _httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            _httpClient.Timeout = new(0,0,20); // 20秒
            // _httpClient.BaseAddress = new("https://api.github.com");

        }
        public async Task<String> searchRepositories(string query = "flutter", int page = 1, int perPage = 1, string sort = "stars")
        {
            try
            {
                var url = GITHUB_API_DOMAIN +  $"/search/repositories?q={query}&page={page}&per_page={perPage}&sort={sort}";
                HttpRequestMessage message = new(HttpMethod.Get, url);
                var response = await _httpClient.SendAsync(message);
                Console.WriteLine("response StatusCode: " + response.StatusCode);
                var responseBody = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    // 認証エラーの場合
                    var data = JsonToGithubErrorResponse(responseBody);
                    Console.WriteLine("response data: " + data.Message + " : " + data.DocumentationUrl);
                }
                // handle the response
                Console.WriteLine("response responseBody: " + responseBody);
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error StatusCode: " + ex.StatusCode);
                return "";
                // throw ex;
            }
        }

        public static GithubErrorResponse JsonToGithubErrorResponse(string json) 
        {
            GithubErrorResponse data = JsonSerializer.Deserialize<GithubErrorResponse>(json);
            return data;
        }
    }
}