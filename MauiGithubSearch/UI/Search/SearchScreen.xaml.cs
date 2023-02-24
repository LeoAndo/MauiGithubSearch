namespace MauiGithubSearch.UI.Search;
using UI.Detail;
using MauiGithubSearch.Data.Api.Github;
using MauiGithubSearch.Domain.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

public partial class SearchScreen : ContentPage
{
    private readonly SearchViewModel viewModel;

    public SearchScreen()
    {
        InitializeComponent();
        viewModel = new SearchViewModel();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Console.WriteLine("call OnAppearing");
        // await VM.LoadDataCommand.ExecuteAsync(null);
        // viewModel.SearchRepositoriesCommand.Execute(null);
    }

    async void listView_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;

        //Deselect Item
        ((ListView)sender).SelectedItem = null; // 選択時のグレー色を消す

        var item = (RepositorySummary)e.Item;
        await Shell.Current.GoToAsync(DetailScreen.buildRoute(item.OwnerName, item.Name));
    }
}
