using CommunityToolkit.Mvvm.Input;
using GamesMVVM.Models;
using GamesMVVM.Services;
using GamesMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesMVVM.ViewModels
{
    public partial class GameListViewModel
    {
        public ObservableCollection<Game> AllGames { get; set; }
        private GameService gameService;

        public GameListViewModel(GameService gs)
        {
            gameService = gs;
            AllGames = new ObservableCollection<Game>();
        }

        [RelayCommand]
        public void LoadGames() {
            var games = gameService.GetAllGames();
            AllGames.Clear();
            
            foreach (var game in games)
            {
                AllGames.Add(game);
            }
        }


        [RelayCommand]
        public void AddGame()
        {
            Game newGame = new Game();
            newGame.Title = "New Game";
            AllGames.Add(newGame);
            gameService.AddGame(newGame);
        }

        [RelayCommand]
        public async void GoToDetail(Game clickedGame)
        {
            await Shell.Current.GoToAsync(nameof(GameDetailView), true, new Dictionary<string, object>
            {
                {"selectedGame", clickedGame}
            });
        }
    }
}
