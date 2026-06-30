using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Test1
{
    internal class Program
    {

        // create a myUsers Class with properties for name, games played, games won, games lost, games tied
        class myUsers
    {
        public string name { get; set; }
        public int gamesPlayed { get; set; }
        public int gamesWon { get; set; }
        public int gamesLost { get; set; }
        public int gamesTied { get; set; }
        // create a constructor for the myUsers class that takes in a name and sets the other properties to 0
        public myUsers(string name)
        {
            this.name = name;
            this.gamesPlayed = 0;
            this.gamesWon = 0;
            this.gamesLost = 0;
            this.gamesTied = 0;
        }

        // create an abstract method to display user stats
        virtual public void displayStats() => Console.WriteLine("Name: " + name);
        }

        // create player class that inherits from myUsers
        class player : myUsers
        {
            // create a property for the player's choice
            public string choice { get; set; }

            // create a constructor for the player class that takes in a name and passes it to the base class constructor
            public player(string name) : base(name)
            {
            }
            // override the displayStats method
            override public void displayStats()
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Games Played: " + gamesPlayed);
                Console.WriteLine("Games Won: " + gamesWon);
                Console.WriteLine("Games Lost: " + gamesLost);
                Console.WriteLine("Games Tied: " + gamesTied);

            }
            // create a method to randomly returns a string rock, paper, or scissors
            public string getChoice()
            {
                Random rand = new Random();
                int choice = rand.Next(0, 3);
                switch (choice)
                {
                    case 0:
                        return "rock";
                    case 1:
                        return "paper";
                    case 2:
                        return "scissors";
                    default:
                        return "rock";
                }
            }
            // create a method to chose rock, paper, or scissors based on int input
            public string getChoice(int choice)
            {
                switch (choice)
                {
                    case 1:
                        return "rock";
                    case 2:
                        return "paper";
                    case 3:
                        return "scissors";
                    default:
                        return "rock";
                }
            }

        }
        class myGame
        {
            // create a method to play rock paper scissors
            public void playGame(player p1, player p2)
            {
                // create a list of choices
                List<string> choices = new List<string> { "rock", "paper", "scissors" };
                // get the choices for each player
                string p1Choice = p1.choice;
                string p2Choice = p2.choice;

                // display the choices
                Console.WriteLine(p1.name + " chose " + p1Choice);
                Console.WriteLine(p2.name + " chose " + p2Choice);

                // determine the winner
                if (p1Choice == p2Choice)
                {
                    Console.WriteLine("It's a tie!");
                    p1.gamesTied++;
                    p2.gamesTied++;
                }
                else if ((p1Choice == "rock" && p2Choice == "scissors") || (p1Choice == "paper" && p2Choice == "rock") || (p1Choice == "scissors" && p2Choice == "paper"))
                {
                    Console.WriteLine(p1.name + " wins!");
                    p1.gamesWon++;
                    p2.gamesLost++;
                }
                else
                {
                    Console.WriteLine(p2.name + " wins!");
                    p2.gamesWon++;
                    p1.gamesLost++;
                }
                // increment games played for both players
                p1.gamesPlayed++;
                p2.gamesPlayed++;
            }
        }

        static void Main(string[] args)
        {

            string playerName;
            int userChoice;
            string playerChoice;

            // prompt user for their name
            Console.WriteLine("Enter your name: ");
            playerName = Console.ReadLine();

            // create two players
            player player1 = new player(playerName);
            player player2 = new player("Computer");

            // create a myGame object
            myGame game = new myGame();
            // play 5 games
            for (int i = 0; i < 5; i++)
            {

                // prompt user for their choice
                Console.WriteLine("Enter your choice (1 for rock, 2 for paper, 3 for scissors): ");
                // read user input and convert to int
                userChoice = Convert.ToInt32(Console.ReadLine());

                // set the choices for both players
                player1.choice = player1.getChoice(userChoice);
                player2.choice = player2.getChoice();

                // play the game
                game.playGame(player1, player2);
                Console.WriteLine();
            }
            // display the stats for both players
            player1.displayStats();
            Console.WriteLine();
            player2.displayStats();

        }
        
    }
}
