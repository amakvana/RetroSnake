using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake_Game
{
    public class Snake
    {
        private int x, y, width, height;
        private Rectangle[] Rec;
        public Rectangle[] snakeRec
        {
            get { return Rec; }
        }

        public Snake()
        {
            //Draws snake on the board
            Rec = new Rectangle[3];
            Globals.SnakeBrush = new SolidBrush(Color.Red);
            x = 20;
            y = 25;
            width = 10;
            height = 10;
            for (int i = 0; i < Rec.Length; i++)
            {
                Rec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }

        public void createSnake(Graphics p)
        {
            //creates original snake shape when game starts 
            foreach (Rectangle rec in Rec)
            {
                p.FillRectangle(Globals.SnakeBrush, rec);
            }
        }

        public void draw()
        {
            for (int i = Rec.Length - 1; i > 0; i--)
            {
                Rec[i] = Rec[i - 1];
            }
        }

        public void down()
        {
            //key event down
            draw();
            Rec[0].Y += 10;
        }
        public void up()
        {
            //key event up
            draw();
            Rec[0].Y -= 10;
        }
        public void right()
        {
            //key event right
            draw();
            Rec[0].X += 10;
        }
        public void left()
        {
            //key event left
            draw();
            Rec[0].X -= 10;
        }

        public void growSnake()
        {
            //grows snake after eating food 
            List<Rectangle> rec = Rec.ToList();
            rec.Add(new Rectangle(Rec[Rec.Length - 1].X, Rec[Rec.Length - 1].Y, width, height));
            Rec = rec.ToArray();
        }
    }
}