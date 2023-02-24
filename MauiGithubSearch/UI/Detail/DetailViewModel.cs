using System;
using MauiGithubSearch.Domain.Model;
using MauiGithubSearch.Data.Api.Github;
using MauiGithubSearch.Domain.exception;
using MauiGithubSearch.Domain.Repository;
using MauiGithubSearch.Data.Repository;
using System.Windows.Input;

namespace MauiGithubSearch.UI.Detail
{
    public class DetailViewModel : ViewModel
    {
        private string? ownerAvatarUrl;
        private string? stargazersCount;
        private string? forksCount;
        private string? openIssuesCount;
        private string? watchersCount;
        private string? language;
        private string? description;
        private bool isLoading;
        private string? errorMsg;
        private readonly IGithubRepoRepository repository;

        public DetailViewModel()
        {
            repository = new GithubRepoRepositoryImpl();
            Console.WriteLine("DetailViewModel hashcode: " + this.GetHashCode());
            GetRepositoryDetail = new Command(async () =>
            {
                try
                {
                    IsLoading = true;
                    var data = await repository.getRepositoryDetail(OwnerName ?? "flutter", RepoName ?? "flutter");
                    Description = data.Description;
                    ForksCount = $"{data.ForksCount} forks";
                    Language = $"language: {data.Language}";
                    OpenIssuesCount = $"open {data.OpenIssuesCount} issues";
                    OwnerAvatarUrl = data.OwnerAvatarUrl;
                    StargazersCount = $"{data.StargazersCount} stars";
                    WatchersCount = $"{data.WatchersCount} watchers";
                    ErrorMsg = "";
                }
                catch (Exception e)
                {
                    ErrorMsg = e switch
                    {
                        ApiException => e.Message,
                        _ => e.ToString()
                    };
                }
                finally
                {
                    IsLoading = false;
                }
            });
        }

        public string? OwnerName
        {
            set; get;
        }
        public string? RepoName
        {
            set; get;
        }

        // データ - START
        public string? Description
        {
            set => SetProperty(ref description, value);
            get => description;
        }
        public string? Language
        {
            set => SetProperty(ref language, value);
            get => language;
        }
        public string? ForksCount
        {
            set => SetProperty(ref forksCount, value);
            get => forksCount;
        }
        public string? OpenIssuesCount
        {
            set => SetProperty(ref openIssuesCount, value);
            get => openIssuesCount;
        }
        public string? StargazersCount
        {
            set => SetProperty(ref stargazersCount, value);
            get => stargazersCount;
        }
        public string? WatchersCount
        {
            set => SetProperty(ref watchersCount, value);
            get => watchersCount;
        }
        public string? OwnerAvatarUrl
        {
            set => SetProperty(ref ownerAvatarUrl, value);
            get => ownerAvatarUrl;
        }
        // データ - END


        public bool IsLoading
        {
            set => SetProperty(ref isLoading, value);
            get => isLoading;
        }
        public string? ErrorMsg
        {
            set => SetProperty(ref errorMsg, value);
            get => errorMsg;
        }
        public ICommand GetRepositoryDetail { private set; get; }
    }
}

