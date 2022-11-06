using GamesMVVM.ViewModels;
using System.Runtime.Intrinsics.X86;

namespace GamesMVVM.Views;

public partial class GameListView : ContentPage
{
	public GameListView(GameListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}

