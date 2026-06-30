using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeffrey_Smith_RPS_Project
{
    internal static class Program
    {
        // create a myUsers class with properties for username, games played, games won, games lost, games tied
        class myUsers
        {
            public string username { get; set; }
            public int gamesPlayed { get; set; }
            public int gamesWon { get; set; }
            public int gamesLost { get; set; }
            public int gamesTied { get; set; }

            // create a constructor for the myUsers class with username parameter
            public myUsers(string username)
            {
                this.username = username;
                this.gamesPlayed = 0;
                this.gamesWon = 0;
                this.gamesLost = 0;
                this.gamesTied = 0;
            }

            // create an abstract method to display user stats
            virtual public string displayStats()
            {
                return $"Username: {username}\nGames Played: {gamesPlayed}\nGames Won: {gamesWon}\nGames Lost: {gamesLost}\nGames Tied: {gamesTied}";
            }


        }
        // create a players class that inherits from myUsers
        class players : myUsers
        {
            // create private fields for players class based on myUsers properties
            private string _username;
            private int _gamesPlayed;
            private int _gamesWon;
            private int _gamesLost;
            private int _gamesTied;

            // create a constructor for the players class with username parameter
            public players(string username) : base(username)
            {   
                _username = username;
                _gamesPlayed = 0;
                _gamesWon = 0;
                _gamesLost = 0;
                _gamesTied = 0;
            }
            // create public properties for players class to get and set private fields
            public string Username
            {
                get { return _username; }
                set { _username = value; }
            }
            // create public properties for games played, won, lost, tied
            public int GamesPlayed
            {
                get { return _gamesPlayed; }
                set { _gamesPlayed = value; }
            }
            public int GamesWon
            {
                get { return _gamesWon; }
                set { _gamesWon = value; }
            }
            public int GamesLost
            {
                get { return _gamesLost; }
                set { _gamesLost = value; }
            }
            public int GamesTied
            {
                get { return _gamesTied; }
                set { _gamesTied = value; }
            }
            public int GamesTiedLost
                {
                get { return _gamesTied + _gamesLost; }
            }
            // override displayStats method
            public override string displayStats()
            {
                return $"Username: {_username}\nGames Played: {_gamesPlayed}\nGames Won: {_gamesWon}\nGames Lost: {_gamesLost}\nGames Tied: {_gamesTied}";
            }
        }
        // Create a myGames class with properties for gameID, player1, player2, winner
        class myGames
        {
            public int gameID { get; set; }
            public players player1 { get; set; }
            public players player2 { get; set; }
            public string winner { get; set; }
            // create a constructor for the myGames class with gameID, player1, player2, winner parameters
            public myGames(int gameID, players player1, players player2, string winner)
            {
                this.gameID = gameID;
                this.player1 = player1;
                this.player2 = player2;
                this.winner = winner;
            }
            // create a method to display game info
            public string displayGameInfo()
            {
                return $"Game ID: {gameID}\nPlayer 1: {player1}\nPlayer 2: {player2}\nWinner: {winner}";
            }

            // creat a method to play rock, paper, scissors
            public string playRPS(string player1Choice, string player2Choice)
            {
                if (player1Choice == player2Choice)
                {
                    return "Tie";
                }
                else if ((player1Choice == "Rock" && player2Choice == "Scissors") ||
                         (player1Choice == "Paper" && player2Choice == "Rock") ||
                         (player1Choice == "Scissors" && player2Choice == "Paper"))
                {
                    return "Player 1 Wins";
                }
                else
                {
                    return "Player 2 Wins";
                }
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // create two players
            players player1 = new players("Alice");
            players player2 = new players("Computer");

            // create a game
            myGames game1 = new myGames(1, player1, player2, "");

            // play the game
            string result = game1.playRPS("Rock", "Scissors");
            Console.WriteLine(result);


        }
    }
}
