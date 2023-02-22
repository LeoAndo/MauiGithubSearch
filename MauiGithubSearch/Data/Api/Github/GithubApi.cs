using System;
using System.Collections.Generic;

namespace MauiGithubSearch.Data.Api.Github
{
    public class GithubApi
	{
		private readonly HttpClient _httpClient = new();
        public List<String> Data { set;  get; } = new();
        public GithubApi()
		{
        }
		public async Task<String> searchRepositories()
		{
			var url = "https://api.github.com/search/repositories?q=maui&page=1&per_page=1&sort=stars";
			var ret = await _httpClient.GetStringAsync(url);
			return ret;
		} 
    }
}