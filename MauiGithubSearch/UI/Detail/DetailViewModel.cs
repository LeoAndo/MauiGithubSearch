using System;
using MauiGithubSearch.Domain.Model;
using MauiGithubSearch.Data.Api.Github;
using MauiGithubSearch.Domain.exception;
using MauiGithubSearch.Domain.Repository;
using MauiGithubSearch.Data.Repository;
using System.Windows.Input;

namespace MauiGithubSearch.UI.Detail
{
	public class DetailViewModel: ViewModel
	{
        private RepositoryDetail? data;
        private bool isLoading;
        private string errorMsg;
        private readonly IGithubRepoRepository repository;

        public DetailViewModel()
        {
            errorMsg = "";
            repository = new GithubRepoRepositoryImpl();
            Console.WriteLine("DetailViewModel hashcode: " + this.GetHashCode());
            GetRepositoryDetail = new Command(async () =>
            {
                try
                {
                    IsLoading = true;
                    Data = await repository.getRepositoryDetail("flutter", "flutter");
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

        public RepositoryDetail? Data
        {
            set => SetProperty(ref data, value);
            get => data;
        }
        public bool IsLoading
        {
            set => SetProperty(ref isLoading, value);
            get => isLoading;
        }
        public string ErrorMsg
        {
            set => SetProperty(ref errorMsg, value);
            get => errorMsg;
        }
        public ICommand GetRepositoryDetail { private set; get; }
    }
}

