
using MauiGithubSearch.Domain.Model;
using MauiGithubSearch.Data.Api.Github;
using MauiGithubSearch.Domain.exception;
using MauiGithubSearch.Domain.Repository;
using MauiGithubSearch.Data.Repository;
using System.Windows.Input;

namespace MauiGithubSearch.UI.Search.Pagination
{
    public class SearchPagingViewModel : ViewModel
    {
        private bool isLoading;
        private string errorMsg;
        private bool isShowEmptyItemsLayout;
        private string query;
        private bool isLastPage;
        private readonly IGithubRepoRepository repository;
        private int pageNo = 1;

        public SearchPagingViewModel()
        {
            repository = new GithubRepoRepositoryImpl();
            Console.WriteLine("ViewModel hashcode: " + this.GetHashCode());

            RefreshCommand = new Command(() =>
            {
                Items.Clear();
                IsLoading = false;
                ErrorMsg = "";
                IsShowEmptyItemsLayout = false;
                IsLastPage = false;
                pageNo = 1;
                SearchRepositoriesCommand?.Execute(null);
            });

            SearchRepositoriesCommand = new Command(async () =>
            {
                try
                {
                    if (IsLastPage) return;

                    if (String.IsNullOrEmpty(Query))
                    {
                        throw new InputValidationException("please input search keyword");
                    }
                    IsLoading = true;
                    var newItems = await repository.searchRepositories(Query, pageNo);
                    IsLastPage = newItems.Count < GithubApi.PER_PAGE;
                    if (!IsLastPage)
                    {
                        // 次ページがある場合
                        pageNo++;
                    }
                    Items.AddRange(newItems);
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


        public ObservableRangeCollection<RepositorySummary> Items
        {
            set;
            get;
        } = new();
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
        public bool IsLastPage
        {
            set => SetProperty(ref isLastPage, value);
            get => isLastPage;
        }

        public ICommand SearchRepositoriesCommand { private set; get; }

        public ICommand RefreshCommand { private set; get; }
    }
}