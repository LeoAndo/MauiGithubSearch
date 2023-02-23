namespace MauiGithubSearch.UI.Search.Pagination;
using UI.Detail;
using MauiGithubSearch.Data.Api.Github;
using MauiGithubSearch.Domain.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

public partial class SearchPagingScreen : ContentPage
{
    private readonly SearchPagingViewModel viewModel;

    public SearchPagingScreen()
    {
        InitializeComponent();
        viewModel = new SearchPagingViewModel();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Console.WriteLine("call SearchPagingScreen OnAppearing");
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

    void listView_ItemAppearing(System.Object sender, Microsoft.Maui.Controls.ItemVisibilityEventArgs e)
    {
        var item = (RepositorySummary) e.Item; // 画面上に表示されているリストアイテム
        if (viewModel.Items.Last() == item && !viewModel.IsLastPage)
        {
            viewModel.SearchRepositoriesCommand.Execute(null);
        }
    }
}
