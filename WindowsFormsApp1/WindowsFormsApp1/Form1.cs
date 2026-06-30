using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace WindowsFormsApp1
{
    

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            // message box to welcome user to the game after form built
            this.Shown += (s, e) => MessageBox.Show("Welcome! Enter your name and click the rock, paper, or scissors button to make your choice." +
                " then click the ''Go!!'' button to play. \n\nClick the ''Play Again'' button to play your next game. Best out of 5 wins!");


            // set focus to p1Name after form built
            this.Shown += (s, e) => p1Name.Focus();

            // Initialize player1 with the value from the p1Name TextBox
            player1 = new player(p1Name.Text);

            // Add player1 and player2 to the players list here
            players.Add(player1);
            players.Add(player2);

        }

        // create a list to hold player objects
        List<player> players = new List<player>();

        //create a global variable to hold user choice
        int userChoice = 0;

        player player1;
        player player2 = new player("Computer");
           

        public void rock_Click(object sender, EventArgs e)
        {
            // create new player objects for player1 and player2
            int userChoice = 1;

            player1.name = p1Name.Text;
            player1.choice = player1.getChoice(userChoice);
            player2.choice = player2.getChoice();
            // set p1Pic PictureBox image to rock image
            p1Pic.Image = Properties.Resources.Slide5;
        }
        public void paper_Click(object sender, EventArgs e)
        {
            int userChoice = 2;

            player1.name = p1Name.Text;
            player1.choice = player1.getChoice(userChoice);
            player2.choice = player2.getChoice();
            // set p1Pic PictureBox image to paper image
            p1Pic.Image = Properties.Resources.Slide6;
        }
        private void scissors_Click_1(object sender, EventArgs e)
        {
            int userChoice = 3;

            player1.name = p1Name.Text;
            player1.choice = player1.getChoice(userChoice);
            player2.choice = player2.getChoice();
            // set p1Pic PictureBox image to scissors image
            p1Pic.Image = Properties.Resources.Slide4;
        }

        public void go_Click(object sender, EventArgs e)
        {
            // play the game

            myGame game = new myGame();

            player player1 = players[0];
            player player2 = players[1];
            game.playGame(player1, player2);
            // call setP2Pic method to set p2Pic PictureBox image based on player2 choice
            setP2Pic(player2.choice);
            player1.displayStats();
        }

        // reset button to clear all stats and textboxes and start over
        private void reset_Click_1(object sender, EventArgs e)
        {
            if (player1.gamesPlayed < 5)
                {
                // clear  textboxes
                pName.Text = "";
                pGamesPlayed.Text = "";
                pGamesWon.Text = "";
                pGamesLost.Text = "";
                pGamesTied.Text = "";
                choice1.Text = "";
                choice2.Text = "";
                gResults.Text = "";
                // clear picture boxes
                p1Pic.Image = null;
                p2Pic.Image = null;

                // set focus to p1Name textbox
                p1Name.Focus();
            }
            // if player1 has played 5 games, display a message box with their final result
            else if (player1.gamesPlayed >= 5 && player1.gamesWon > 2)
            {
                MessageBox.Show("Congratulations " + player1.name + ", you are the champion!");
                clearStats();

            }
            // if player1 has played 5 games and won 2 or less, display a message box with a consolation message
            else if (player1.gamesPlayed >= 5 && player1.gamesWon <= 2)
            {
                MessageBox.Show("Sorry " + player1.name + ", Better luck next time!");
                clearStats();

            }
            

        }
        // create a method to choose picture for player2 based on their choice
        private void setP2Pic(string choice)
        {
            switch (choice)
            {
                case "rock":
                    p2Pic.Image = Properties.Resources.Slide2;
                    break;
                case "paper":
                    p2Pic.Image = Properties.Resources.Slide3;
                    break;
                case "scissors":
                    p2Pic.Image = Properties.Resources.Slide1;
                    break;
                default:
                    p2Pic.Image = null;
                    break;
            }
        }
        // create a method to clear all stats and textboxes and start over
        private void clearStats()
        {
            // clear  textboxes
            pName.Text = "";
            pGamesPlayed.Text = "";
            pGamesWon.Text = "";
            pGamesLost.Text = "";
            pGamesTied.Text = "";
            choice1.Text = "";
            choice2.Text = "";
            gResults.Text = "";
            // clear picture boxes
            p1Pic.Image = null;
            p2Pic.Image = null;
            // reset player1 stats
            player1.gamesPlayed = 0;
            player1.gamesWon = 0;
            player1.gamesLost = 0;
            player1.gamesTied = 0;
            // reset player2 stats
            player2.gamesPlayed = 0;
            player2.gamesWon = 0;
            player2.gamesLost = 0;
            player2.gamesTied = 0;
            // set focus to p1Name textbox
            p1Name.Focus();
        }

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

            // create a method to change text in Form1.pName textbox
            virtual public void displayStats()
            {
                Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (form != null)
                {
                    form.pName.Text = this.name;
                }
            }
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

                Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (form != null)
                {
                    form.pName.Text = name;
                    form.pGamesPlayed.Text = "" + gamesPlayed;
                    form.pGamesWon.Text = "" + gamesWon;
                    form.pGamesLost.Text = "" + gamesLost;
                    form.pGamesTied.Text = "" + gamesTied;
                }

            }
            // create a method to randomly returns a string rock, paper, or scissors
            public string getChoice()
            {
                Random rand = new Random();

                // generate a random number between 1 and 3 inclusive
                int choice = rand.Next(1, 4);

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

                Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (form != null)
                {
                    form.choice1.Text = "" + p1Choice;
                    form.choice2.Text = "" + p2Choice;

                }

                    // determine the winner
                    if (p1Choice == p2Choice)
                    {
                        form.gResults.Text = "It's a tie!";
                        p1.gamesTied++;
                        p2.gamesTied++;
                    }
                    else if ((p1Choice == "rock" && p2Choice == "scissors") || (p1Choice == "paper" && p2Choice == "rock") || (p1Choice == "scissors" && p2Choice == "paper"))
                    {
                        form.gResults.Text ="" + p1.name + " wins!";
                        p1.gamesWon++;
                        p2.gamesLost++;
                    }
                    else
                    {
                        form.gResults.Text = "" + p2.name + " wins!";   
                    p2.gamesWon++;
                        p1.gamesLost++;
                    }
                    // increment games played for both players
                    p1.gamesPlayed++;
                    p2.gamesPlayed++;
            }

        }

        private void exitAp_Click(object sender, EventArgs e)
        {
            // close the application
            Application.Exit();
        }
    }
}
