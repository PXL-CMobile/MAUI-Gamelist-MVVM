namespace GameWebApi.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Score { get; set; }
        public string Genre { get; set; }

        public Game()
        {
            ID = 0;
            Title= string.Empty;
            Score = 0;  
            Genre = string.Empty;  
        }
    }
}
