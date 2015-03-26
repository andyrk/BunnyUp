#region Description
//------------------------------
//  BalloonLives.cs
//
//  Container class for Balloons to be drawn
//------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace BunnyUp.GameObjects
{
    class BalloonLives
    {
        #region Fields

        private int remainingLives;
        private Texture2D livesLeft1;
        private Texture2D livesLeft2;
        private Texture2D livesLeft3;

        private Texture2D balloonsLeft1;
        private Texture2D balloonsLeft2;
        private Texture2D balloonsLeft3;

        private Texture2D FloatingBalloon;

        #endregion 

        #region Properties

        /// <summary>
        /// Get or sets where the balloons(on string) will be drawn
        /// </summary>
        public Vector2 FloatingPosition { get;  set; }

        /// <summary>
        /// Get or Set whether to draw the balloons(on strong)
        /// </summary>
        public bool DrawFloating { get; set; }

        #endregion

        #region Initialization

        /// <summary>
        /// constructor for class
        /// </summary>
        /// <param name="image for one life"></param>
        /// <param name="image for two lives"></param>
        /// <param name="image for three lives"></param>
        /// <param name="image for one life (balloon w/ string)"></param>
        /// <param name="image for two lives (balloon w/ string)"></param>
        /// <param name="image for three lives (balloon w/ string)"></param>
        public BalloonLives(Texture2D life1, Texture2D life2, Texture2D life3, Texture2D ball1, Texture2D ball2, Texture2D ball3)
        {
            livesLeft1 = life1;
            livesLeft2 = life2;
            livesLeft3 = life3;
            balloonsLeft1 = ball1;
            balloonsLeft2 = ball2;
            balloonsLeft3 = ball3;
            FloatingBalloon = ball3;
            DrawFloating = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Allows for the objects logic to update.
        /// </summary>
        /// <param name="lives"></param>
        /// <param name="position"></param>
        public void Update(int lives, Vector2 position)
        {
            remainingLives = lives;

            if (remainingLives == 3 && FloatingBalloon != balloonsLeft3)
            {
                FloatingBalloon = balloonsLeft3;
            }
            else if (remainingLives == 2 && FloatingBalloon != balloonsLeft2)
            {
                FloatingBalloon = balloonsLeft2;
            }
            else if (remainingLives == 1 && FloatingBalloon != balloonsLeft1)
            {
                FloatingBalloon = balloonsLeft1;
            }

            FloatingPosition = new Vector2(position.X - FloatingBalloon.Width/2 - 25, position.Y - FloatingBalloon.Height/1.5f);
        }

        /// <summary>
        /// Draws the balloons
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if(DrawFloating)
            {
                spriteBatch.Draw(FloatingBalloon, FloatingPosition, Color.White);
            }
            spriteBatch.Draw(livesLeft1, new Vector2(0, 25), Color.White);
            if (remainingLives >= 2)
            {
                spriteBatch.Draw(livesLeft2, new Vector2(40, 25), Color.White);
                if (remainingLives >= 3)
                {
                    spriteBatch.Draw(livesLeft3, new Vector2(80, 25), Color.White);
                }
            }
        }
        #endregion
    }
}
