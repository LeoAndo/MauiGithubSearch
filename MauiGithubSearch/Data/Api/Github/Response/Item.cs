using System;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response
{
    public class Item
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }
    }
}

