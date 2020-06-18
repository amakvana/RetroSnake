using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake_Game
{
    class Globals
    {
        //HIGHSCORE NAME & VALUES ARE FETCHED FROM APP SETTINGS

        //MAIN SCORE
        private static int _currentScore = 0;
        public static int CurrentScore
        {
            get { return _currentScore; }
            set { _currentScore = value; }
        }

        //BRUSH (Colouring the Snake)
        private static SolidBrush _snakeBrush;
        public static SolidBrush SnakeBrush
        {
            get { return _snakeBrush; }
            set { _snakeBrush = value; }
        }

        //BRUSH (Colouring the Food)
        private static SolidBrush _foodBrush;
        public static SolidBrush FoodBrush
        {
            get { return _foodBrush; }
            set { _foodBrush = value; }
        }
    }
}