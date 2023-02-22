using System;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response
{
    public class Owner
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }
    }
}

