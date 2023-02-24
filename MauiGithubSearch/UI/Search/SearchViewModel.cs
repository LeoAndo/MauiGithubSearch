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
        private bool isShowEmptyItemsLayout;
        private string query;
        private readonly IGithubRepoRepository repository;

        public SearchViewModel()
        {
            repository = new GithubRepoRepositoryImpl();
            Console.WriteLine("ViewModel hashcode: " + this.GetHashCode());
            SearchRepositoriesCommand = new Command(async () =>
            {
                try
                {
                    if (String.IsNullOrEmpty(Query))
                    {
                        throw new InputValidationException("please input search keyword");
                    }
                    IsLoading = true;
                    Items = await repository.searchRepositories(Query, 1);
                    IsShowEmptyItemsLayout = (Items.Count == 0);
                    ErrorMsg = "";
                }
                catch (Exception e)
                {
                    ErrorMsg = e switch
                    {
                        ApiException => e.Message,
                        ValidationException => e.Message,
                        _ => e.ToString()

                    };
                }
                finally
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
        public bool IsShowEmptyItemsLayout
        {
            set => SetProperty(ref isShowEmptyItemsLayout, value);
            get => isShowEmptyItemsLayout;
        }
        public string Query
        {
            set => SetProperty(ref query, value);
            get => query;
        }

        public ICommand SearchRepositoriesCommand { private set; get; }
    }
}

