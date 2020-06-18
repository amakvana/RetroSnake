using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class frmMain : Form
    {
        Random r = new Random();
        Graphics p;
        Snake snake = new Snake();
        Food food;
        bool left = false;
        bool right = false;
        bool down = false;
        bool up = false;

        public frmMain()
        {
            InitializeComponent();
            food = new Food(r);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            p = e.Graphics;
            food.createFood(p);
            snake.createSnake(p);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //key events

            //starts game when "Enter" is pressed
            if (e.KeyData == Keys.Return)
            {
                timer1.Enabled = true;
                spaceBarLabel.Text = "";
                down = false;
                up = false;
                right = true;
                left = false;
            }
            //key event down
            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }
            //key event up
            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            //key event right 
            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
            //key event left 
            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //updates score 
            lblSnakeScore.Text = Convert.ToString(Globals.CurrentScore);
            //keyboard events to make snake move
            if (down) { snake.down(); }
            if (up) { snake.up(); }
            if (right) { snake.right(); }
            if (left) { snake.left(); }

            for (int i = 0; i < snake.snakeRec.Length; i++)
            {
                //if snake eats the food then
                //add new block onto snake
                //else if food gets spawned inside snake then randomize location of food again until it doesnt spawn inside snake 

                if ((food.rec).IntersectsWith(snake.snakeRec[i]))
                {
                    food = new Food(r);
                    Globals.FoodBrush = new SolidBrush(foodColorDialog.Color);
                    Globals.CurrentScore += 10;
                    changeFoodLocation();
                }
                else if (snake.snakeRec[i].IntersectsWith(food.rec))
                {
                    Globals.CurrentScore += 10;
                    changeFoodLocation();
                }
            }
            //checks if snake has crashed 
            crash();
            this.Invalidate();
        }

        public void crash()
        {
            for (int i = 1; i < snake.snakeRec.Length; i++)
            {
                //if food gets spawned inside snake then 
                //randomize location of food again until it doesnt spawn inside snake 
                if ((food.rec).IntersectsWith(snake.snakeRec[i]))
                {
                    food = new Food(r);
                    Globals.FoodBrush = new SolidBrush(foodColorDialog.Color);
                    changeFoodLocation();
                }

                //if snake hits itself then game over
                if (snake.snakeRec[0].IntersectsWith(snake.snakeRec[i]))
                    restart();
            }

            //checks to see if snake has hit the boundaries 
            if (snake.snakeRec[0].X < 0 || snake.snakeRec[0].X > 290)
                restart();
            if (snake.snakeRec[0].Y <= 24 || snake.snakeRec[0].Y > 290)
                restart();
        }

        public void changeFoodLocation()
        {
            snake.growSnake();
            food.placeFood(r);
        }

        public void restart()
        {
            //restarts game
            timer1.Enabled = false;
            MessageBox.Show("Snake is dead. You scored: " + Globals.CurrentScore.ToString(), this.Text);
            if (Globals.CurrentScore >= 100)
            {
                //if the current score is higher than 100
                //then display option to submit score to scoreboard

                if (MessageBox.Show("Would you like to submit your highscores?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmHighscores h = new frmHighscores();
                    h.Show();
                    lblSnakeScore.Text = "0";
                    spaceBarLabel.Text = "Press 'Enter' to Begin";
                    snake = new Snake();
                }
                else
                    resetScore();
            }
            else
                resetScore();
        }

        public void resetScore()
        {
            lblSnakeScore.Text = "0";
            Globals.CurrentScore = 0;
            spaceBarLabel.Text = "Press 'Enter' to Begin";
            snake = new Snake();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmHighscores h = new frmHighscores();
            h.Close();
        }

        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHighscores h = new frmHighscores();
            h.Show();
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = String.Format("1. Press the 'Enter' to start the game{0}2. Use the arrow keys on your keyboard to control the snake to eat the food{0}3. Thats it...Enjoy!{0}{0}NOTE:   If you press any arrow keys together, it will automatically end the game!", Environment.NewLine);
            MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.Show();
        }

        private void foodColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foodColorDialog.ShowDialog();
            Globals.FoodBrush = new SolidBrush(foodColorDialog.Color);
        }

        private void snakeColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            snakeColorDialog.ShowDialog();
            Globals.SnakeBrush = new SolidBrush(snakeColorDialog.Color);
        }

        private void backgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bgColorDialog.ShowDialog();
            this.BackColor = bgColorDialog.Color;
            statusStrip1.BackColor = bgColorDialog.Color;
            menuStrip1.BackColor = bgColorDialog.Color;
        }

        private void foregroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fgColorDialog.ShowDialog();
            this.ForeColor = fgColorDialog.Color;
            menuStrip1.ForeColor = fgColorDialog.Color;
        }

        private void resetColoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = DefaultBackColor;
            statusStrip1.BackColor = DefaultBackColor;
            menuStrip1.BackColor = DefaultBackColor;
            Globals.FoodBrush = new SolidBrush(Color.Black);
            Globals.SnakeBrush = new SolidBrush(Color.Red);
            foodColorDialog.Color = Color.Black;
            snakeColorDialog.Color = Color.Red;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();     //save highscores
            frmHighscores h = new frmHighscores();
            h.Close();
        }
    }
}