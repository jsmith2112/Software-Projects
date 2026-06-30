namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerStats = new System.Windows.Forms.GroupBox();
            this.pGamesTied = new System.Windows.Forms.TextBox();
            this.pGamesLost = new System.Windows.Forms.TextBox();
            this.pGamesWon = new System.Windows.Forms.TextBox();
            this.pGamesPlayed = new System.Windows.Forms.TextBox();
            this.pName = new System.Windows.Forms.TextBox();
            this.gamesTied = new System.Windows.Forms.Label();
            this.gamesLost = new System.Windows.Forms.Label();
            this.gamesWon = new System.Windows.Forms.Label();
            this.gamesPlayed = new System.Windows.Forms.Label();
            this.playerName = new System.Windows.Forms.Label();
            this.buttonBox = new System.Windows.Forms.GroupBox();
            this.go = new System.Windows.Forms.Button();
            this.scissors = new System.Windows.Forms.Button();
            this.paper = new System.Windows.Forms.Button();
            this.rock = new System.Windows.Forms.Button();
            this.gameResults = new System.Windows.Forms.GroupBox();
            this.gResults = new System.Windows.Forms.TextBox();
            this.choice2 = new System.Windows.Forms.TextBox();
            this.choice1 = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.Label();
            this.p2Choice = new System.Windows.Forms.Label();
            this.p1Choice = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.GroupBox();
            this.p1Name = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.p1Pic = new System.Windows.Forms.PictureBox();
            this.p2Pic = new System.Windows.Forms.PictureBox();
            this.exitAp = new System.Windows.Forms.Button();
            this.playerStats.SuspendLayout();
            this.buttonBox.SuspendLayout();
            this.gameResults.SuspendLayout();
            this.userName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // playerStats
            // 
            this.playerStats.Controls.Add(this.pGamesTied);
            this.playerStats.Controls.Add(this.pGamesLost);
            this.playerStats.Controls.Add(this.pGamesWon);
            this.playerStats.Controls.Add(this.pGamesPlayed);
            this.playerStats.Controls.Add(this.pName);
            this.playerStats.Controls.Add(this.gamesTied);
            this.playerStats.Controls.Add(this.gamesLost);
            this.playerStats.Controls.Add(this.gamesWon);
            this.playerStats.Controls.Add(this.gamesPlayed);
            this.playerStats.Controls.Add(this.playerName);
            this.playerStats.Location = new System.Drawing.Point(281, 416);
            this.playerStats.Name = "playerStats";
            this.playerStats.Size = new System.Drawing.Size(618, 246);
            this.playerStats.TabIndex = 0;
            this.playerStats.TabStop = false;
            this.playerStats.Text = "Player Stats";
            // 
            // pGamesTied
            // 
            this.pGamesTied.Location = new System.Drawing.Point(143, 205);
            this.pGamesTied.Name = "pGamesTied";
            this.pGamesTied.Size = new System.Drawing.Size(363, 26);
            this.pGamesTied.TabIndex = 10;
            // 
            // pGamesLost
            // 
            this.pGamesLost.Location = new System.Drawing.Point(143, 164);
            this.pGamesLost.Name = "pGamesLost";
            this.pGamesLost.Size = new System.Drawing.Size(363, 26);
            this.pGamesLost.TabIndex = 9;
            // 
            // pGamesWon
            // 
            this.pGamesWon.Location = new System.Drawing.Point(143, 123);
            this.pGamesWon.Name = "pGamesWon";
            this.pGamesWon.Size = new System.Drawing.Size(363, 26);
            this.pGamesWon.TabIndex = 8;
            // 
            // pGamesPlayed
            // 
            this.pGamesPlayed.Location = new System.Drawing.Point(143, 82);
            this.pGamesPlayed.Name = "pGamesPlayed";
            this.pGamesPlayed.Size = new System.Drawing.Size(363, 26);
            this.pGamesPlayed.TabIndex = 7;
            // 
            // pName
            // 
            this.pName.Location = new System.Drawing.Point(143, 41);
            this.pName.Name = "pName";
            this.pName.Size = new System.Drawing.Size(363, 26);
            this.pName.TabIndex = 6;
            // 
            // gamesTied
            // 
            this.gamesTied.AutoSize = true;
            this.gamesTied.Location = new System.Drawing.Point(23, 211);
            this.gamesTied.Name = "gamesTied";
            this.gamesTied.Size = new System.Drawing.Size(99, 20);
            this.gamesTied.TabIndex = 5;
            this.gamesTied.Text = "Games Tied:";
            // 
            // gamesLost
            // 
            this.gamesLost.AutoSize = true;
            this.gamesLost.Location = new System.Drawing.Point(23, 170);
            this.gamesLost.Name = "gamesLost";
            this.gamesLost.Size = new System.Drawing.Size(100, 20);
            this.gamesLost.TabIndex = 4;
            this.gamesLost.Text = "Games Lost:";
            // 
            // gamesWon
            // 
            this.gamesWon.AutoSize = true;
            this.gamesWon.Location = new System.Drawing.Point(23, 129);
            this.gamesWon.Name = "gamesWon";
            this.gamesWon.Size = new System.Drawing.Size(102, 20);
            this.gamesWon.TabIndex = 3;
            this.gamesWon.Text = "Games Won:";
            // 
            // gamesPlayed
            // 
            this.gamesPlayed.AutoSize = true;
            this.gamesPlayed.Location = new System.Drawing.Point(23, 88);
            this.gamesPlayed.Name = "gamesPlayed";
            this.gamesPlayed.Size = new System.Drawing.Size(116, 20);
            this.gamesPlayed.TabIndex = 1;
            this.gamesPlayed.Text = "Games Played:";
            // 
            // playerName
            // 
            this.playerName.AutoSize = true;
            this.playerName.Location = new System.Drawing.Point(23, 47);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(102, 20);
            this.playerName.TabIndex = 0;
            this.playerName.Text = "Player Name:";
            // 
            // buttonBox
            // 
            this.buttonBox.Controls.Add(this.go);
            this.buttonBox.Controls.Add(this.scissors);
            this.buttonBox.Controls.Add(this.paper);
            this.buttonBox.Controls.Add(this.rock);
            this.buttonBox.Location = new System.Drawing.Point(927, 425);
            this.buttonBox.Name = "buttonBox";
            this.buttonBox.Size = new System.Drawing.Size(207, 236);
            this.buttonBox.TabIndex = 1;
            this.buttonBox.TabStop = false;
            this.buttonBox.Text = "Choose and Play";
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(25, 183);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 39);
            this.go.TabIndex = 3;
            this.go.Text = "Go!!!";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // scissors
            // 
            this.scissors.Location = new System.Drawing.Point(25, 135);
            this.scissors.Name = "scissors";
            this.scissors.Size = new System.Drawing.Size(75, 39);
            this.scissors.TabIndex = 2;
            this.scissors.Text = "Scissors";
            this.scissors.UseVisualStyleBackColor = true;
            this.scissors.Click += new System.EventHandler(this.scissors_Click_1);
            // 
            // paper
            // 
            this.paper.Location = new System.Drawing.Point(25, 87);
            this.paper.Name = "paper";
            this.paper.Size = new System.Drawing.Size(75, 39);
            this.paper.TabIndex = 1;
            this.paper.Text = "Paper";
            this.paper.UseVisualStyleBackColor = true;
            this.paper.Click += new System.EventHandler(this.paper_Click);
            // 
            // rock
            // 
            this.rock.Location = new System.Drawing.Point(25, 39);
            this.rock.Name = "rock";
            this.rock.Size = new System.Drawing.Size(75, 39);
            this.rock.TabIndex = 0;
            this.rock.Text = "Rock";
            this.rock.UseVisualStyleBackColor = true;
            this.rock.Click += new System.EventHandler(this.rock_Click);
            // 
            // gameResults
            // 
            this.gameResults.Controls.Add(this.gResults);
            this.gameResults.Controls.Add(this.choice2);
            this.gameResults.Controls.Add(this.choice1);
            this.gameResults.Controls.Add(this.result);
            this.gameResults.Controls.Add(this.p2Choice);
            this.gameResults.Controls.Add(this.p1Choice);
            this.gameResults.Location = new System.Drawing.Point(281, 163);
            this.gameResults.Name = "gameResults";
            this.gameResults.Size = new System.Drawing.Size(618, 221);
            this.gameResults.TabIndex = 2;
            this.gameResults.TabStop = false;
            this.gameResults.Text = "Game Results";
            // 
            // gResults
            // 
            this.gResults.Location = new System.Drawing.Point(172, 139);
            this.gResults.Name = "gResults";
            this.gResults.Size = new System.Drawing.Size(311, 26);
            this.gResults.TabIndex = 5;
            // 
            // choice2
            // 
            this.choice2.Location = new System.Drawing.Point(172, 85);
            this.choice2.Name = "choice2";
            this.choice2.Size = new System.Drawing.Size(311, 26);
            this.choice2.TabIndex = 4;
            // 
            // choice1
            // 
            this.choice1.Location = new System.Drawing.Point(172, 39);
            this.choice1.Name = "choice1";
            this.choice1.Size = new System.Drawing.Size(311, 26);
            this.choice1.TabIndex = 3;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(21, 139);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(137, 20);
            this.result.TabIndex = 2;
            this.result.Text = "Results of Round:";
            // 
            // p2Choice
            // 
            this.p2Choice.AutoSize = true;
            this.p2Choice.Location = new System.Drawing.Point(21, 91);
            this.p2Choice.Name = "p2Choice";
            this.p2Choice.Size = new System.Drawing.Size(119, 20);
            this.p2Choice.TabIndex = 1;
            this.p2Choice.Text = "Player 2 Chose:";
            // 
            // p1Choice
            // 
            this.p1Choice.AutoSize = true;
            this.p1Choice.Location = new System.Drawing.Point(21, 43);
            this.p1Choice.Name = "p1Choice";
            this.p1Choice.Size = new System.Drawing.Size(119, 20);
            this.p1Choice.TabIndex = 0;
            this.p1Choice.Text = "Player 1 Chose:";
            // 
            // userName
            // 
            this.userName.Controls.Add(this.p1Name);
            this.userName.Controls.Add(this.nameLabel);
            this.userName.Location = new System.Drawing.Point(281, 71);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(618, 73);
            this.userName.TabIndex = 3;
            this.userName.TabStop = false;
            this.userName.Text = "Enter Your Name";
            // 
            // p1Name
            // 
            this.p1Name.Location = new System.Drawing.Point(166, 34);
            this.p1Name.Name = "p1Name";
            this.p1Name.Size = new System.Drawing.Size(317, 26);
            this.p1Name.TabIndex = 1;
            this.p1Name.Text = "Enter Your Name to Get Started.";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(22, 41);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(115, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Player 1 Name:";
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(78, 425);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(103, 103);
            this.reset.TabIndex = 6;
            this.reset.Text = "Play Again";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click_1);
            // 
            // p1Pic
            // 
            this.p1Pic.Location = new System.Drawing.Point(927, 71);
            this.p1Pic.Name = "p1Pic";
            this.p1Pic.Size = new System.Drawing.Size(219, 323);
            this.p1Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1Pic.TabIndex = 5;
            this.p1Pic.TabStop = false;
            // 
            // p2Pic
            // 
            this.p2Pic.BackColor = System.Drawing.Color.Black;
            this.p2Pic.Location = new System.Drawing.Point(41, 71);
            this.p2Pic.Name = "p2Pic";
            this.p2Pic.Size = new System.Drawing.Size(219, 323);
            this.p2Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2Pic.TabIndex = 4;
            this.p2Pic.TabStop = false;
            // 
            // exitAp
            // 
            this.exitAp.Location = new System.Drawing.Point(78, 544);
            this.exitAp.Name = "exitAp";
            this.exitAp.Size = new System.Drawing.Size(103, 103);
            this.exitAp.TabIndex = 7;
            this.exitAp.Text = "Exit";
            this.exitAp.UseVisualStyleBackColor = true;
            this.exitAp.Click += new System.EventHandler(this.exitAp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 684);
            this.Controls.Add(this.exitAp);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.p1Pic);
            this.Controls.Add(this.p2Pic);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.gameResults);
            this.Controls.Add(this.buttonBox);
            this.Controls.Add(this.playerStats);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rock Paper Scissors";
            this.playerStats.ResumeLayout(false);
            this.playerStats.PerformLayout();
            this.buttonBox.ResumeLayout(false);
            this.gameResults.ResumeLayout(false);
            this.gameResults.PerformLayout();
            this.userName.ResumeLayout(false);
            this.userName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox playerStats;
        private System.Windows.Forms.Label gamesPlayed;
        private System.Windows.Forms.Label playerName;
        private System.Windows.Forms.Label gamesTied;
        private System.Windows.Forms.Label gamesLost;
        private System.Windows.Forms.Label gamesWon;
        private System.Windows.Forms.GroupBox buttonBox;
        private System.Windows.Forms.TextBox pGamesTied;
        private System.Windows.Forms.TextBox pGamesLost;
        private System.Windows.Forms.TextBox pGamesWon;
        private System.Windows.Forms.TextBox pGamesPlayed;
        private System.Windows.Forms.TextBox pName;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.Button scissors;
        private System.Windows.Forms.Button paper;
        private System.Windows.Forms.Button rock;
        private System.Windows.Forms.GroupBox gameResults;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Label p2Choice;
        private System.Windows.Forms.Label p1Choice;
        private System.Windows.Forms.TextBox gResults;
        private System.Windows.Forms.TextBox choice2;
        private System.Windows.Forms.TextBox choice1;
        private System.Windows.Forms.GroupBox userName;
        private System.Windows.Forms.TextBox p1Name;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox p2Pic;
        private System.Windows.Forms.PictureBox p1Pic;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button exitAp;
    }
}

