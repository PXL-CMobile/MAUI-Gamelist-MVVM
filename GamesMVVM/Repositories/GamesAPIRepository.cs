using GamesMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GamesMVVM.Repositories
{
    public class GamesAPIRepository : IGamesRepository
    {
        private readonly HttpClient _httpClient;

        //local
        private string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5270/api/Game" : "http://localhost:5270/api/Game";

        public GamesAPIRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<Game>> GetGamesAsync()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new List<Game>();

            string result = await _httpClient.GetStringAsync(baseUrl);

            return JsonConvert.DeserializeObject<List<Game>>(result);
        }

        public async Task<Game> SaveGameAsync(Game itemToSave)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            var result = await _httpClient.PostAsJsonAsync(baseUrl, itemToSave);
            
            return await result.Content.ReadFromJsonAsync<Game>();
        }
    }
}
