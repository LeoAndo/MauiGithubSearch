using System;

namespace MauiGithubSearch.Domain.Model
{
	public class RepositoryDetail
	{
		public RepositoryDetail(string ownerAvatarUrl, int stargazersCount, int forksCount, int openIssuesCount, int watchersCount, string? language, string? description)
		{
            OwnerAvatarUrl = ownerAvatarUrl;
            StargazersCount = stargazersCount;
            ForksCount = forksCount;
            OpenIssuesCount = openIssuesCount;
            WatchersCount = watchersCount;
            Language = language;
            Description = description;
        }
        public string OwnerAvatarUrl { set; get; }
        public int StargazersCount { set; get; }
        public int ForksCount { set; get; }
        public int OpenIssuesCount { set; get; }
        public int WatchersCount { set; get; }
        public string? Language { set; get; }
        public string? Description { set; get; }


    }
}