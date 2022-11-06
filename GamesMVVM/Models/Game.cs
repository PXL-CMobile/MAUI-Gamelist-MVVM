using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesMVVM.Models
{
    public partial class Game : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string genre;
        [ObservableProperty]
        private int score;
    }
}
