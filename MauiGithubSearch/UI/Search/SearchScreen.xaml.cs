namespace MauiGithubSearch.UI.Search;
using UI.Detail;
using MauiGithubSearch.Data.Api.Github;
using MauiGithubSearch.Domain.Model;
using System.Collections.ObjectModel;

public partial class SearchScreen : ContentPage
{
    public SearchScreen()
	{
		InitializeComponent();
    }

    async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;

        //Deselect Item
        ((ListView)sender).SelectedItem = null;

        var item = (RepositorySummary) e.Item;
        await Shell.Current.GoToAsync(DetailScreen.buildRoute(item.OwnerName, item.Name));
    }
}
