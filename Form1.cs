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
    public partial class Form1 : Form
    {
        Random r = new Random();
        Graphics p;
        Snake snake = new Snake();
        Food food;
        bool left = false;
        bool right = false;
        bool down = false;
        bool up = false;
        public Form1()
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
            if (e.KeyData == Keys.Return)
            {
                timer1.Enabled = true;
                spaceBarLabel.Text = "";
                down = false;
                up = false;
                right = true;
                left = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
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
            lblSnakeScore.Text = Convert.ToString(Globals.CurrentScore);
            if (down) { snake.down(); }
            if (up) { snake.up(); }
            if (right) { snake.right(); }
            if (left) { snake.left(); }
            for (int i = 0; i < snake.snakeRec.Length; i++)
            {
                if ((food.rec).IntersectsWith(snake.snakeRec[i]))
                {
                    food = new Food(r);
                    Globals.FoodBrush = new SolidBrush(colorDialog1.Color);
                    Globals.CurrentScore += 10;
                    changeFoodLocation();
                }
                else if (snake.snakeRec[i].IntersectsWith(food.rec))
                {
                    Globals.CurrentScore += 10;
                    changeFoodLocation();
                }
            }
            crash();
            this.Invalidate();
        }

        public void crash()
        {
            for (int i = 1; i < snake.snakeRec.Length; i++)
            {
                if ((food.rec).IntersectsWith(snake.snakeRec[i]))
                {
                    food = new Food(r);
                    Globals.FoodBrush = new SolidBrush(colorDialog1.Color);
                    changeFoodLocation();
                }
                if (snake.snakeRec[0].IntersectsWith(snake.snakeRec[i]))
                    restart();
            }
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
            timer1.Enabled = false;
            MessageBox.Show("Snake is dead. You scored: " + Globals.CurrentScore.ToString(), this.Text);
            if (Globals.CurrentScore >= 100)
            {
                if (MessageBox.Show("Would you like to submit your highscores?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Highscores h = new Highscores();
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
            Highscores h = new Highscores();
            h.Close();
        }

        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Highscores h = new Highscores();
            h.Show();
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg;
            msg = "1. Press the 'Enter' to start the game" + Environment.NewLine +
                  "2. Use the arrow keys on your keyboard to control the snake to eat the food" + Environment.NewLine + 
                  "3. Thats it...Enjoy!" + Environment.NewLine + Environment.NewLine +
                  "NOTE:   If you press any arrow keys together, it will automatically end the game!";
            MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg;
            msg = "A simple snake game to play when bored" + Environment.NewLine + Environment.NewLine +
                  "Made by Akash" + Environment.NewLine +
                  "Copyright© 2011";
            MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void foodColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Globals.FoodBrush = new SolidBrush(colorDialog1.Color);
        }

        private void snakeColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Globals.SnakeBrush = new SolidBrush(colorDialog1.Color);
        }

        private void backgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.BackColor = colorDialog1.Color;
            statusStrip1.BackColor = colorDialog1.Color;
            menuStrip1.BackColor = colorDialog1.Color;
        }

        private void foregroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.ForeColor = colorDialog1.Color;
            menuStrip1.ForeColor = colorDialog1.Color;
        }

        private void resetColoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = DefaultBackColor;
            statusStrip1.BackColor = DefaultBackColor;
            menuStrip1.BackColor = DefaultBackColor;
            Globals.FoodBrush = new SolidBrush(Color.Black);
            Globals.SnakeBrush = new SolidBrush(Color.Red);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Highscores h = new Highscores();
            h.Close();
        }
    }
}