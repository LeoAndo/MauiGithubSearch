using System;
using System.Collections.Generic;

using System.Globalization;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response
{
    public class GithubErrorResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("documentation_url")]
        public string DocumentationUrl { get; set; }
    }
}

