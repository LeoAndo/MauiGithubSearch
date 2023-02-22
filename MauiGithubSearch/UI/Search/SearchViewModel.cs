using System.Windows.Input;
using MauiGithubSearch.Domain.Model;
using MauiGithubSearch.Data.Api.Github;

namespace MauiGithubSearch.UI.Search
{
    public class SearchViewModel : ViewModel
    {
        IList<RepositorySummary> items;
        public SearchViewModel()
        {
            Console.WriteLine("ViewModel hashcode: " + this.GetHashCode());
            SearchRepositoriesCommand = new Command(async () =>
            {
                Console.WriteLine("run IncreaseExponentCommand ");
                var result = await new GithubApi().searchRepositories();
                Console.WriteLine($"end IncreaseExponentCommand {result.Items.Count} ");
                Items = result.toModels();
            });
        }


        public IList<RepositorySummary> Items
        {
            set => SetProperty(ref items, value);
            get => items;
        }

        public ICommand SearchRepositoriesCommand { private set; get; }
    }
}

