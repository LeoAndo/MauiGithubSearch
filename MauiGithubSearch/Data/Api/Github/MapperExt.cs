using System;
using MauiGithubSearch.Data.Api.Github.Response;
using MauiGithubSearch.Data.Api.Github.Response.FetchRepositoryDetail;
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
                list.Add(new RepositorySummary(item.Id,item.Name,item.Owner.Login));
            }
            return list;
        }

        public static RepositoryDetail toModel(this RepositoryDetailResponse response)
        {
            var data = new RepositoryDetail(
                response.Owner.AvatarUrl,
                response.StargazersCount,
                response.ForksCount,
                response.OpenIssuesCount,
                response.WatchersCount,
                response.Language,
                response.Description
                );
            return data;
        }
    }
}

