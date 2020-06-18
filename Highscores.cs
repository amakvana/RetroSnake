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
    public partial class Highscores : Form
    {
        public Highscores()
        {
            InitializeComponent();
        }

        private void Highscores_Load(object sender, EventArgs e)
        {
            lblCurrentScore.Text = Globals.CurrentScore.ToString();
            lbl1Name.Text = Globals.Name1;
            lbl2Name.Text = Globals.Name2;
            lbl3Name.Text = Globals.Name3;
            lbl4Name.Text = Globals.Name4;
            lbl5Name.Text = Globals.Name5;
            lblTopScore.Text = Globals.Score1.ToString();
            lbl2ndPlace.Text = Globals.Score2.ToString();
            lbl3rdPlace.Text = Globals.Score3.ToString();
            lbl4thPlace.Text = Globals.Score4.ToString();
            lbl5thPlace.Text = Globals.Score5.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(textBox1.Text)) || (Globals.CurrentScore >= 20))
            {
                if (int.Parse(lblCurrentScore.Text) > int.Parse(lblTopScore.Text))
                {
                    //Applies new score
                    Globals.Score1 = Globals.CurrentScore;
                    Globals.Name1 = textBox1.Text.Trim();
                    MessageBox.Show("Congratulations " + textBox1.Text.Trim().ToString() +
                                    "!..." + Environment.NewLine + 
                                    "You have broken the current top score!" + Environment.NewLine + Environment.NewLine +
                                    "New top-score set", this.Text);
                    lbl1Name.Text = Globals.Name1;
                    lblTopScore.Text = Globals.Score1.ToString();
                }
                else if (int.Parse(lblCurrentScore.Text) > int.Parse(lbl2ndPlace.Text))
                {
                    //Applies new score
                    Globals.Score2 = Globals.CurrentScore;
                    Globals.Name2 = textBox1.Text.Trim();
                    MessageBox.Show("You have the 2nd highest score", this.Text);
                    lbl2Name.Text = Globals.Name2;
                    lbl2ndPlace.Text = Globals.Score2.ToString();
                }
                else if (int.Parse(lblCurrentScore.Text) > int.Parse(lbl3rdPlace.Text))
                {
                    //Applies new score
                    Globals.Score3 = Globals.CurrentScore;
                    Globals.Name3 = textBox1.Text.Trim();
                    MessageBox.Show("You have the 3rd highest score", this.Text);
                    lbl3Name.Text = Globals.Name3;
                    lbl3rdPlace.Text = Globals.Score3.ToString();
                }
                else if (int.Parse(lblCurrentScore.Text) > int.Parse(lbl4thPlace.Text))
                {
                    //Applies new score
                    Globals.Score4 = Globals.CurrentScore;
                    Globals.Name4 = textBox1.Text.Trim();
                    MessageBox.Show("You have the 4th highest score", this.Text);
                    lbl4Name.Text = Globals.Name4;
                    lbl4thPlace.Text = Globals.Score4.ToString();
                }
                else if (int.Parse(lblCurrentScore.Text) > int.Parse(lbl5thPlace.Text))
                {
                    //Applies new score
                    Globals.Score5 = Globals.CurrentScore;
                    Globals.Name5 = textBox1.Text.Trim();
                    MessageBox.Show("You have the 5th highest score", this.Text);
                    lbl5Name.Text = Globals.Name5;
                    lbl5thPlace.Text = Globals.Score5.ToString();
                }
                else
                {
                    MessageBox.Show("Sorry " + textBox1.Text.Trim().ToString() + 
                                    "!...Your score did not reach the top 5" + Environment.NewLine +
                                    "Better luck next time!", this.Text);
                }
                button1.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
                textBox1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(textBox1.Text)))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void Highscores_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globals.CurrentScore = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamWriter x = new StreamWriter("SnakeHighscores.txt"))
            {
                x.WriteLine("======== Snake =========");
                x.WriteLine("========================");
                x.WriteLine("Exported Highscore List");
                x.WriteLine("========================");
                x.WriteLine();
                x.WriteLine();
                x.WriteLine("Rank #1: " + Globals.Name1 + ", Score: " + Globals.Score1.ToString());
                x.WriteLine();
                x.WriteLine("Rank #2: " + Globals.Name2 + ", Score: " + Globals.Score2.ToString());
                x.WriteLine();
                x.WriteLine("Rank #3: " + Globals.Name3 + ", Score: " + Globals.Score3.ToString());
                x.WriteLine();
                x.WriteLine("Rank #4: " + Globals.Name4 + ", Score: " + Globals.Score4.ToString());
                x.WriteLine();
                x.WriteLine("Rank #5: " + Globals.Name5 + ", Score: " + Globals.Score5.ToString());
                x.Flush();
                x.Close();
                MessageBox.Show("Highscores successfully exported!", this.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
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