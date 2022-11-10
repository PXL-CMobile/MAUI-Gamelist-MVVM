using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GamesMVVM.Models;
using GamesMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesMVVM.ViewModels
{
    [QueryProperty("VideoGame", "selectedGame")]
    public partial class GameDetailViewModel : ObservableObject
    {
        /* Make copies of the props so the original object is not changing untill save. */
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string genre;
        [ObservableProperty]
        private int score;

        private GameService gameService;
        public GameDetailViewModel(GameService gs)
        {
            gameService = gs;
        }

        private Game videoGame; 
        public Game VideoGame { set
            {
                videoGame = value;
                Title = videoGame.Title;
                Genre = videoGame.Genre;
                Score = videoGame.Score;
            } 
        }

        [RelayCommand]
        private async void SaveGame()
        {
            /* Save to the database should go here */
            videoGame.Title = Title;
            videoGame.Genre = Genre;
            videoGame.Score = Score;
            gameService.SaveGame(videoGame);
            await Shell.Current.GoToAsync("..");
        }
    }
}
