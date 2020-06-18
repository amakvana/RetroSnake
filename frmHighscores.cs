using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class frmHighscores : Form
    {


        int[] currentScores;




        public frmHighscores()
        {
            InitializeComponent();
        }

        private void Highscores_Load(object sender, EventArgs e)
        {
            //used for debug purpose only
            //Properties.Settings.Default.Reset();

            //loads all scores up onto leaderboard
            //fetched from application settings

            //import current score
            lblCurrentScore.Text = Globals.CurrentScore.ToString();

            //import names 
            lbl1Name.Text = Properties.Settings.Default.Name1;
            lbl2Name.Text = Properties.Settings.Default.Name2;
            lbl3Name.Text = Properties.Settings.Default.Name3;
            lbl4Name.Text = Properties.Settings.Default.Name4;
            lbl5Name.Text = Properties.Settings.Default.Name5;

            //import scores for each name
            lblTopScore.Text = Properties.Settings.Default.Score1.ToString();
            lbl2ndPlace.Text = Properties.Settings.Default.Score2.ToString();
            lbl3rdPlace.Text = Properties.Settings.Default.Score3.ToString();
            lbl4thPlace.Text = Properties.Settings.Default.Score4.ToString();
            lbl5thPlace.Text = Properties.Settings.Default.Score5.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(textBox1.Text)) || (Globals.CurrentScore >= 100))
            {
                if (int.Parse(lblCurrentScore.Text) > int.Parse(lblTopScore.Text))
                {
                    //edits score so that the old scores move down
                    //and not get overwritten

                    //edits visible name
                    lbl5Name.Text = Properties.Settings.Default.Name4;
                    lbl4Name.Text = Properties.Settings.Default.Name3;
                    lbl3Name.Text = Properties.Settings.Default.Name2;
                    lbl2Name.Text = Properties.Settings.Default.Name1;
                    //permanently stores new name
                    Properties.Settings.Default.Name5 = Properties.Settings.Default.Name4;
                    Properties.Settings.Default.Name4 = Properties.Settings.Default.Name3;
                    Properties.Settings.Default.Name3 = Properties.Settings.Default.Name2;
                    Properties.Settings.Default.Name2 = Properties.Settings.Default.Name1;
                    //edits visible score
                    lbl5thPlace.Text = Properties.Settings.Default.Score4.ToString();
                    lbl4thPlace.Text = Properties.Settings.Default.Score3.ToString();
                    lbl3rdPlace.Text = Properties.Settings.Default.Score2.ToString();
                    lbl2ndPlace.Text = Properties.Settings.Default.Score1.ToString();
                    //permanently stores new scores 
                    Properties.Settings.Default.Score5 = Properties.Settings.Default.Score4;
                    Properties.Settings.Default.Score4 = Properties.Settings.Default.Score3;
                    Properties.Settings.Default.Score3 = Properties.Settings.Default.Score2;
                    Properties.Settings.Default.Score2 = Properties.Settings.Default.Score1;


                    //Applies new score
                    //top score
                    Properties.Settings.Default.Score1 = Globals.CurrentScore;
                    Properties.Settings.Default.Name1 = textBox1.Text.Trim();
                    MessageBox.Show(String.Format("Congratulations {0}!...{1}You have broken the current top score!{1}{1}New top-score set", textBox1.Text, Environment.NewLine), this.Text);
                    lbl1Name.Text = Properties.Settings.Default.Name1;
                    lblTopScore.Text = Properties.Settings.Default.Score1.ToString();
                }
                else if (int.Parse(lblCurrentScore.Text) > int.Parse(lbl2ndPlace.Text))
                {
                    //edits score so that the old scores move down
                    //and not get overwritten

                    //edits visible name
                    lbl5Name.Text = Properties.Settings.Default.Name4;
                    lbl4Name.Text = Properties.Settings.Default.Name3;
                    lbl3Name.Text = Properties.Settings.Default.Name2;
                    //permanently stores new name
                    Properties.Settings.Default.Name5 = Properties.Settings.Default.Name4;
                    Properties.Settings.Default.Name4 = Properties.Settings.Default.Name3;
                    Properties.Settings.Default.Name3 = Properties.Settings.Default.Name2;
                    //edits visible score
                    lbl5thPlace.Text = Properties.Settings.Default.Score4.ToString();
                    lbl4thPlace.Text = Properties.Settings.Default.Score3.ToString();
                    lbl3rdPlace.Text = Properties.Settings.Default.Score2.ToString();
                    //permanently stores new scores 
                    Properties.Settings.Default.Score5 = Properties.Settings.Default.Score4;
                    Properties.Settings.Default.Score4 = Properties.Settings.Default.Score3;
                    Properties.Settings.Default.Score3 = Properties.Settings.Default.Score2;


                    //Applies new score
                    //2nd place
                    Properties.Settings.Default.Score2 = Globals.CurrentScore;
                    Properties.Settings.Default.Name2 = textBox1.Text.Trim();
                    MessageBox.Show("You have the 2nd highest score", this.Text);
                    lbl2Name.Text = Properties.Settings.Default.Name2;
                    lbl2ndPlace.Text = Properties.Settings.Default.Score2.ToString();
                }
                else if (int.Parse(lblCurrentScore.Text) > int.Parse(lbl3rdPlace.Text))
                {
                    //edits score so that the old scores move down
                    //and not get overwritten

                    //edits visible name
                    lbl5Name.Text = Properties.Settings.Default.Name4;
                    lbl4Name.Text = Properties.Settings.Default.Name3;
                    //permanently stores new name
                    Properties.Settings.Default.Name5 = Properties.Settings.Default.Name4;
                    Properties.Settings.Default.Name4 = Properties.Settings.Default.Name3;
                    //edits visible score
                    lbl5thPlace.Text = Properties.Settings.Default.Score4.ToString();
                    lbl4thPlace.Text = Properties.Settings.Default.Score3.ToString();
                    //permanently stores new scores 
                    Properties.Settings.Default.Score5 = Properties.Settings.Default.Score4;
                    Properties.Settings.Default.Score4 = Properties.Settings.Default.Score3;


                    //Applies new score
                    //3rd place
                    Properties.Settings.Default.Score3 = Globals.CurrentScore;
                    Properties.Settings.Default.Name3 = textBox1.Text.Trim();
                    MessageBox.Show("You have the 3rd highest score", this.Text);
                    lbl3Name.Text = Properties.Settings.Default.Name3;
                    lbl3rdPlace.Text = Properties.Settings.Default.Score3.ToString();
                }
                else if (int.Parse(lblCurrentScore.Text) > int.Parse(lbl4thPlace.Text))
                {
                    //edits score so that the old scores move down
                    //and not get overwritten

                    //edits visible name
                    lbl5Name.Text = Properties.Settings.Default.Name4;
                    //permanently stores new name
                    Properties.Settings.Default.Name5 = Properties.Settings.Default.Name4;
                    //edits visible score
                    lbl5thPlace.Text = Properties.Settings.Default.Score4.ToString();
                    //permanently stores new scores 
                    Properties.Settings.Default.Score5 = Properties.Settings.Default.Score4;


                    //Applies new score
                    //4th place
                    Properties.Settings.Default.Score4 = Globals.CurrentScore;
                    Properties.Settings.Default.Name4 = textBox1.Text.Trim();
                    MessageBox.Show("You have the 4th highest score", this.Text);
                    lbl4Name.Text = Properties.Settings.Default.Name4;
                    lbl4thPlace.Text = Properties.Settings.Default.Score4.ToString();
                }
                else if (int.Parse(lblCurrentScore.Text) > int.Parse(lbl5thPlace.Text))
                {
                    //Applies new score
                    //5th place
                    Properties.Settings.Default.Score5 = Globals.CurrentScore;
                    Properties.Settings.Default.Name5 = textBox1.Text.Trim();
                    MessageBox.Show("You have the 5th highest score", this.Text);
                    lbl5Name.Text = Properties.Settings.Default.Name5;
                    lbl5thPlace.Text = Properties.Settings.Default.Score5.ToString();
                }
                else
                {
                    //not make it to top #5 scores
                    MessageBox.Show(String.Format("Sorry {0}!...Your score did not reach the top 5{1}Better luck next time!", textBox1.Text, Environment.NewLine), this.Text);
                }
                button1.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
                textBox1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //checks if name field is blank
            //if blank, then disable submit button
            //otherwise enable it

            if (!(string.IsNullOrWhiteSpace(textBox1.Text)))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void Highscores_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();     //save highscores
            //changes current score back to 0 when closing highscore form
            Globals.CurrentScore = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();     //save highscores
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //writes all highscores to textfile 
            //located in same directory as game

            using (StreamWriter x = new StreamWriter("SnakeHighscores.txt"))
            {
                x.WriteLine("======== Snake =========");
                x.WriteLine("========================");
                x.WriteLine("Exported Highscore List");
                x.WriteLine("========================");
                x.WriteLine();
                x.WriteLine();
                x.WriteLine("Rank #1: " + Properties.Settings.Default.Name1 + ", Score: " + Properties.Settings.Default.Score1.ToString());
                x.WriteLine();
                x.WriteLine("Rank #2: " + Properties.Settings.Default.Name2 + ", Score: " + Properties.Settings.Default.Score2.ToString());
                x.WriteLine();
                x.WriteLine("Rank #3: " + Properties.Settings.Default.Name3 + ", Score: " + Properties.Settings.Default.Score3.ToString());
                x.WriteLine();
                x.WriteLine("Rank #4: " + Properties.Settings.Default.Name4 + ", Score: " + Properties.Settings.Default.Score4.ToString());
                x.WriteLine();
                x.WriteLine("Rank #5: " + Properties.Settings.Default.Name5 + ", Score: " + Properties.Settings.Default.Score5.ToString());
                x.Flush();
                x.Close();
                MessageBox.Show("Highscores successfully exported!", this.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //checks if exported highscores exist
            //if so, then delete
            //otherwise file doesnt exist

            string path = "SnakeHighscores.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
                MessageBox.Show("SnakeHighscores.txt has been deleted!", this.Text);
            }
            else
                MessageBox.Show("File doesnt exist!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}