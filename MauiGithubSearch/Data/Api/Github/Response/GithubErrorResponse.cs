using System;
using System.Collections.Generic;

using System.Globalization;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response
{
    public record GithubErrorResponse
    {
        [JsonPropertyName("message")]
        public required string Message { get; set; }
        [JsonPropertyName("documentation_url")]
        public required string DocumentationUrl { get; set; }
    }
}

