using GamesMVVM.ViewModels;

namespace GamesMVVM.Views;

public partial class GameDetailView : ContentPage
{
	public GameDetailView(GameDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}