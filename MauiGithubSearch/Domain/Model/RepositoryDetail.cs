using System;

namespace MauiGithubSearch.Domain.Model
{
	public record RepositoryDetail(string OwnerAvatarUrl, int StargazersCount, int ForksCount, int OpenIssuesCount, int WatchersCount, string? Language, string? Description);
}