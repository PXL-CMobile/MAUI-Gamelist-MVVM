namespace GamesMVVM.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	/*
		For the demo: change the type of injection in MauiProgram.cs and show
		that the Service (and pages) will not be Singletons in that case.
	 */
	//private async void Button_Clicked(object sender, EventArgs e)
	//{
	//	await Shell.Current.GoToAsync("GameListView");
	//}
}