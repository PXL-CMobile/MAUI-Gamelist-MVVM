using GamesMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesMVVM.Repositories
{
    public interface IGamesRepository
    {
        Task<List<Game>> GetGamesAsync();

        Task<Game> SaveGameAsync(Game itemToSave);
    }
}
