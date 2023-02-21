namespace MauiGithubSearch.UI.Detail;

// https://learn.microsoft.com/ja-jp/dotnet/maui/fundamentals/shell/navigation?view=net-maui-7.0#pass-and-process-multiple-items-of-data
[QueryProperty(nameof(OwnerName), "ownerName")]
[QueryProperty(nameof(RepoName), "repoName")]
public partial class DetailScreen : ContentPage
{
    public static string buildRoute(string ownerName, string repoName)
    {

        return $"{nameof(DetailScreen)}?ownerName={ownerName}&repoName={repoName}";
    }

	public string OwnerName
	{
		set;
		get;
	}
    public string RepoName
    {
        set;
        get;
    }

    public DetailScreen()
	{
		InitializeComponent();
	}

    void BtnRefresh_Clicked(System.Object sender, System.EventArgs e)
    {
        lblOwnerName.Text = OwnerName;
        lblRepoName.Text = RepoName;
    }
}