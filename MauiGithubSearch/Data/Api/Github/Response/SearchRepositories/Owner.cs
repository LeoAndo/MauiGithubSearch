using System;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response
{
    public record Owner
    {
        [JsonPropertyName("login")]
        public required string Login { get; set; }
    }
}

