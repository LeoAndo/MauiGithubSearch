namespace MauiGithubSearch;
using MauiGithubSearch.UI.Detail;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        // https://learn.microsoft.com/ja-jp/dotnet/maui/fundamentals/shell/navigation?view=net-maui-7.0#register-detail-page-routes
        // アプリ内のどこからでもURIベースのナビゲーションを使用して移動できる設定
        // このようなページのルートは、"グローバル ルート" と呼ばれます。
        Routing.RegisterRoute(nameof(DetailScreen), typeof(DetailScreen));
    }
}

