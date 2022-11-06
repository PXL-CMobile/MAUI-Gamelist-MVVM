using GamesMVVM.Views;

namespace GamesMVVM;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(GameDetailView), typeof(GameDetailView));
		Routing.RegisterRoute(nameof(GameListView), typeof(GameListView));
	}
}
