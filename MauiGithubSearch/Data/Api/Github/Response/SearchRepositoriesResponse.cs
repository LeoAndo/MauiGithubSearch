using System;
using System.Text.Json.Serialization;
using MauiGithubSearch.Domain.Model;

namespace MauiGithubSearch.Data.Api.Github.Response
{
    public class SearchRepositoriesResponse
    {
        /// <summary>
        ///     val incomplete_results: Boolean,
        ///     val items: List<Item>,
        ///     val total_count: Int
        /// </summary>
        [JsonPropertyName("incomplete_results")]
        public bool IncompleteResults { get; set; }
        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }
        [JsonPropertyName("items")]
        public IList<Item> Items { get; set; }
    }
}

