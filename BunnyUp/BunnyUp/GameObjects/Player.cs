#region File Description
//----------------------
//  Player.cs
//
//  container for player details
//----------------------
#endregion


#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion


namespace BunnyUp.GameObjects
{
    public class Player
    {
        #region Properties

        /// <summary>
        /// Gets the score of the object
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Gets the lives of the object
        /// </summary>
        public int Lives { get; set; }

        #endregion 

        #region Initialization

        /// <summary>
        /// Constructor for the player object
        /// </summary>
        public Player()
        {
            Score = 0;
            Lives = 3;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Increment the score by the passed in value whilst bound checking
        /// </summary>
        /// <param name="increase"></param>
        public void IncrementScore(int increase)
        {
            Score = (int)MathHelper.Clamp(Score + increase, 0, Int32.MaxValue);
        }
        #endregion
    }
}
