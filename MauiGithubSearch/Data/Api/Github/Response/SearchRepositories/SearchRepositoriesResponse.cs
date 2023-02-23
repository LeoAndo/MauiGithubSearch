using System;
using System.Text.Json.Serialization;
using MauiGithubSearch.Domain.Model;

namespace MauiGithubSearch.Data.Api.Github.Response
{
    public record SearchRepositoriesResponse
    {
        [JsonPropertyName("incomplete_results")]
        public required  bool IncompleteResults { get; set; }
        [JsonPropertyName("total_count")]
        public required int TotalCount { get; set; }
        [JsonPropertyName("items")]
        public required IList<Item> Items { get; set; }
    }
}

