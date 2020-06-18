using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake_Game
{
    public class Food
    {
        private int x, y, width, height;        // declare location and dimensions for the food 
        public Rectangle rec;       // declare the food object 
        public Food(Random r)
        {
            x = r.Next(0, 29) * 10;
            y = r.Next(3, 29) * 10;
            Globals.FoodBrush = new SolidBrush(Color.Black);
            width = 10;
            height = 10;
            rec = new Rectangle(x, y, width, height);
        }

        public void placeFood(Random r)
        {
            x = r.Next(0, 29) * 10;
            y = r.Next(3, 29) * 10;
        }

        public void createFood(Graphics p)
        {
            rec.X = x;
            rec.Y = y;
            p.FillRectangle(Globals.FoodBrush, rec);
        }
    }
}