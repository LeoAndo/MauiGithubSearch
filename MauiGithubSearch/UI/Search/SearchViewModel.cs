using System.Windows.Input;
using MauiGithubSearch.Domain.Model;
using MauiGithubSearch.Data.Api.Github;
using MauiGithubSearch.Domain.exception;
using MauiGithubSearch.Domain.Repository;
using MauiGithubSearch.Data.Repository;

namespace MauiGithubSearch.UI.Search
{
    public class SearchViewModel : ViewModel
    {
        private IList<RepositorySummary> items;
        private bool isLoading;
        private string errorMsg;
        private bool isShowErrorLayout;
        private bool isShowEmptyItemsLayout;
        private readonly IGithubRepoRepository repository;

        public SearchViewModel()
        {
            repository = new GithubRepoRepositoryImpl();
            Console.WriteLine("ViewModel hashcode: " + this.GetHashCode());
            SearchRepositoriesCommand = new Command(async () =>
            {
                try
                {
                    IsLoading = true;
                    await Task.Delay(2000);
                    Items = await repository.searchRepositories("flutter", 1);
                    IsShowEmptyItemsLayout = (Items.Count == 0);
                    ErrorMsg = "";
                    IsShowErrorLayout = false;
                } catch (Exception e )
                {
                    ErrorMsg = e.Message;
                    IsShowErrorLayout = true;
                } finally
                {
                    IsLoading = false;
                }
            });
        }


        public IList<RepositorySummary> Items
        {
            set => SetProperty(ref items, value);
            get => items;
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
        public bool IsShowErrorLayout
        {
            set => SetProperty(ref isShowErrorLayout, value);
            get => isShowErrorLayout;
        }
        public bool IsShowEmptyItemsLayout
        {
            set => SetProperty(ref isShowEmptyItemsLayout, value);
            get => isShowEmptyItemsLayout;
        }


        public ICommand SearchRepositoriesCommand { private set; get; }
    }
}

