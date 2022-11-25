using GamesMVVM.Models;
using Newtonsoft.Json;

using System.Net.Http.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GamesMVVM.Repositories
{
    public class GamesSQLiteRepository : IGamesRepository
    {
        SQLiteAsyncConnection context;


        public GamesSQLiteRepository()
        {

        }

        async Task Init()
        {
            if (context is not null)
                return;
            // Optional step: setup a prefilled db
            SetupDBFile("PREDB.db3");
            context = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await context.CreateTableAsync<Game>();

        }

        public async Task<List<Game>> GetGamesAsync()
        {
            await Init();
            return await context.Table<Game>().ToListAsync();
        }

        public async Task<Game> SaveGameAsync(Game itemToSave)
        {
            await Init();
            if (itemToSave.ID != 0) {
                await context.UpdateAsync(itemToSave);
                return itemToSave;
            }
            else
            {
                await context.InsertAsync(itemToSave);
                return itemToSave;
            }
        }

        /*
            Code to ship an existing DB with the app.
            It copies a file to the AppData folder where it is accesible for 
            the SQLite connnection. 
            In this code: seeks a folder DB in the Resources 
            the PREDB.db3 is a file containing a SQLite database and is marked 
            as an embedded resource.
         */
        public void SetupDBFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var assemblyName = assembly.GetName().Name;

            var stream = assembly.GetManifestResourceStream($"{assemblyName}.Resources.DB.{filename}");
            if (!File.Exists(Constants.DatabasePath))
            {
                FileStream fileStream = File.Create(Constants.DatabasePath);
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
                fileStream.Close();
            }
        }

    }
}
