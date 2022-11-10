using GamesMVVM.Services;
using GamesMVVM.ViewModels;
using GamesMVVM.Views;
using CommunityToolkit.Maui;
using GamesMVVM.Repositories;

namespace GamesMVVM;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		/* Using the Community Toolkit */
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder.Services.AddSingleton<GamesSQLiteRepository>();
        builder.Services.AddSingleton<GameService>();
		builder.Services.AddTransient<GameDetailViewModel>();
		builder.Services.AddSingleton<GameListViewModel>();
		builder.Services.AddSingleton<GameListView>();
		builder.Services.AddTransient<GameDetailView>();

        /* Use this to show that sometimes you do want a Singleton!
		 builder.Services.AddTransient<GameService>();
		builder.Services.AddTransient<GameDetailViewModel>();
		builder.Services.AddTransient<GameListViewModel>();
		builder.Services.AddTransient<GameListView>();
		builder.Services.AddTransient<GameDetailView>();
		 */

        return builder.Build();
	}
}
