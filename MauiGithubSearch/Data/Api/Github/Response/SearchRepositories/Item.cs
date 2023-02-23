using System;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response
{
    public record Item
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("owner")]
        public required Owner Owner { get; set; }
    }
}

