using System;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response.FetchRepositoryDetail
{
    public record Owner
    {
        [JsonPropertyName("avatar_url")]
        public required string AvatarUrl { get; set; }
        [JsonPropertyName("id")]
        public required int Id { get; set; }
    }
}

