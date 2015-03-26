#region File Description
//----------------------
//  Waves.cs
//
//  A visual object of a wave to be drawn
//  using for visuals
//----------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
#endregion

namespace BunnyUp.GameObjects
{
    class Waves : GameObject
    {
        #region Fields

        private int waveCounter;
        private int direction;

        #endregion 
        #region Initialization

        /// <summary>
        /// Constructor for the wave object
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="picture"></param>
        /// <param name="wavingDirection"></param>
        public Waves(Vector2 pos, Texture2D picture, int wavingDirection)
            : base(pos, picture)
        {
            waveCounter = 0;
            direction = wavingDirection;
        }

        #endregion

        #region Methods, Update, and Draw

        /// <summary>
        /// Updates the wave object's x.position to "sway" left and right
        /// </summary>
        public void Sway()
        {
            if (waveCounter < 25)
            {
                Position = new Vector2(Position.X + direction, Position.Y);
                waveCounter++;
            }
            else
            {
                direction *= -1;
                waveCounter = 0;
            }
        }

        /// <summary>
        /// Allows for the wave object to update its logic
        /// </summary>
        public override void Update()
        {
            base.Update();
            Sway();
        }

        /// <summary>
        /// Draws the wave object
        /// </summary>
        /// <param name="spritebatch"></param>
        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }

        #endregion
    }
}
