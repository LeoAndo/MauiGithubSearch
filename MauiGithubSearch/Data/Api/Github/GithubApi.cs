using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using MauiGithubSearch.Data.Api.Github.Response;
using MauiGithubSearch.Data.Api.Github.Response.FetchRepositoryDetail;
using MauiGithubSearch.Domain.exception;
using MauiGithubSearch.Domain.Model;

namespace MauiGithubSearch.Data.Api.Github
{
    public class GithubApi
    {
        private const string GITHUB_ACCESS_TOKEN = ""; // TODO Please Input Here Your GITHUB_ACCESS_TOKEN.
        private const string GITHUB_API_DOMAIN = "https://api.github.com";
        public static int PER_PAGE = 20;
        private readonly HttpClient  _httpClient;
        public GithubApi()
        {
            Console.WriteLine("GithubApi hashcode: " + this.GetHashCode());
            _httpClient = new(new AppHttpLogger(new HttpClientHandler()));
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            // _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {GITHUB_ACCESS_TOKEN}");
            _httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            _httpClient.Timeout = new(0, 0, 0,30);

        }
        public async Task<SearchRepositoriesResponse> searchRepositories(string query, int page, int perPage = 20, string sort = "stars")
        {
            var url = GITHUB_API_DOMAIN + $"/search/repositories?q={query}&page={page}&per_page={PER_PAGE}&sort={sort}";
            return await dataOrThrow<SearchRepositoriesResponse>(new(HttpMethod.Get, url));
        }
        public async Task<RepositoryDetailResponse> fetchRepositoryDetail(string ownerName, string repositoryName)
        {
            var url = GITHUB_API_DOMAIN + $"/repos/{ownerName}/{repositoryName}";
            return await dataOrThrow<RepositoryDetailResponse>(new(HttpMethod.Get, url));
        }

        private static GithubErrorResponse JsonToGithubErrorResponse(string json) => JsonSerializer.Deserialize<GithubErrorResponse>(json)!;


        private async Task<T> dataOrThrow<T>(HttpRequestMessage message)
        {
            try
            {
                var response = await _httpClient.SendAsync(message);
                var responseBodyJson = await response.Content.ReadAsStringAsync();
                var statusCodeValue = (int)response.StatusCode;
                var result=  statusCodeValue switch
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
                return result!;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is WebException)
            {
                // TaskCanceledException: 接続タイムアウト時にthrowされる
                // WebException: 機内モード時にthrowされる
                throw new NetworkException(message: ex.Message);
            }
        }
    }
}