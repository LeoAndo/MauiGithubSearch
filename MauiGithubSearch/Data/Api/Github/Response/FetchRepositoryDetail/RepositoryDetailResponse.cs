using System;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response.FetchRepositoryDetail
{
    public class RepositoryDetailResponse
	{
        [JsonPropertyName("forks_count")]
        public int ForksCount { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("open_issues_count")]
        public int OpenIssuesCount { get; set; }
        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }
        [JsonPropertyName("stargazers_count")]
        public int StargazersCount { get; set; }
        [JsonPropertyName("watchers_count")]
        public int WatchersCount { get; set; }
        [JsonPropertyName("language")]
        public string? Language { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}

