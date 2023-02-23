using System;
using MauiGithubSearch.Domain.Model;
namespace MauiGithubSearch.Domain.Repository
{
	public interface IGithubRepoRepository
	{
        public Task<IList<RepositorySummary>> searchRepositories(string query, int page);
    }
}

