namespace MauiGithubSearch.UI.Search;
using UI.Detail;

public partial class SearchScreen : ContentPage
{
	public SearchScreen()
	{
		InitializeComponent();
	}

    async void NextBtn_Clicked(System.Object sender, System.EventArgs e)
    {   
        await Shell.Current.GoToAsync(DetailScreen.buildRoute("flutter", "repo"));
    }
}
