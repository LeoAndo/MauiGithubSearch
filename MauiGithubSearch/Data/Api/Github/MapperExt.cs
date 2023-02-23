using System;
using MauiGithubSearch.Data.Api.Github.Response;
using MauiGithubSearch.Domain.Model;
namespace MauiGithubSearch.Data.Api.Github
{
	public static class MapperExt
	{
        public static IList<RepositorySummary> toModels(this SearchRepositoriesResponse response)
        {
            IList<RepositorySummary> list = new List<RepositorySummary>();
            foreach (Item item in response.Items)
            {
                list.Add(new RepositorySummary(id: item.Id, name: item.Name, ownerName: item.Owner.Login));
            }
            return list;
        }
    }
}

