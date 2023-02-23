using System;
using System.Text.Json.Serialization;

namespace MauiGithubSearch.Data.Api.Github.Response.FetchRepositoryDetail
{
    public class Owner
	{
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}

