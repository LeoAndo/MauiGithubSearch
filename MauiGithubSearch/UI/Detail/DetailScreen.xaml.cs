namespace MauiGithubSearch.UI.Detail;
using MauiGithubSearch.Data.Api.Github;

// https://learn.microsoft.com/ja-jp/dotnet/maui/fundamentals/shell/navigation?view=net-maui-7.0#pass-and-process-multiple-items-of-data
[QueryProperty(nameof(OwnerName), "ownerName")]
[QueryProperty(nameof(RepoName), "repoName")]
public partial class DetailScreen : ContentPage
{
    public static string buildRoute(string ownerName, string repoName)
    {

        return $"{nameof(DetailScreen)}?ownerName={ownerName}&repoName={repoName}";
    }

    public string? OwnerName
    {
        set;
        get;
    }
    public string? RepoName
    {
        set;
        get;
    }

    private readonly DetailViewModel viewModel;
    public DetailScreen()
	{
		InitializeComponent();
        viewModel = new();
        BindingContext = viewModel;
    }

    protected  override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.OwnerName = OwnerName;
        viewModel.RepoName = RepoName;
        lblRepoName.Text = $"repo: {RepoName}";
        lblOwnerName.Text = $"owner: {OwnerName}";
        viewModel.GetRepositoryDetail.Execute(null);
    }
}