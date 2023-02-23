using System;
using MauiGithubSearch.Domain.Model;
using MauiGithubSearch.Domain.Repository;
using MauiGithubSearch.Data.Api.Github;
namespace MauiGithubSearch.Data.Repository
{
	public class GithubRepoRepositoryImpl: IGithubRepoRepository
	{
		private readonly GithubApi api;
		public GithubRepoRepositoryImpl()
		{
			api = new();
		}
        public async Task<IList<RepositorySummary>> searchRepositories(string query, int page)
        {
			var response = await api.searchRepositories(query: query, page: page);
            return response.toModels();
        }
    }
}

