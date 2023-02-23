using System;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response.FetchRepositoryDetail
{
    public record RepositoryDetailResponse
    {
        [JsonPropertyName("forks_count")]
        public required int ForksCount { get; set; }
        [JsonPropertyName("id")]
        public required int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("open_issues_count")]
        public required int OpenIssuesCount { get; set; }
        [JsonPropertyName("owner")]
        public required Owner Owner { get; set; }
        [JsonPropertyName("stargazers_count")]
        public required int StargazersCount { get; set; }
        [JsonPropertyName("watchers_count")]
        public required int WatchersCount { get; set; }
        [JsonPropertyName("language")]
        public required string? Language { get; set; }
        [JsonPropertyName("description")]
        public required string? Description { get; set; }
    };
}

