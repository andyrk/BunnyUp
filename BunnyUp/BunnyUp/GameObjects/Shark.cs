#region File Description
//----------------------
//  Shark.cs
//
//  A visual object of a shark that is to be drawn 
//  used for visuals
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
#endregion

namespace BunnyUp.GameObjects
{
    class Shark : GameObject
    {
        #region Fields

        private int direction = -1;
        private SpriteEffects spriteEffects;

        #endregion

        #region Initialization

        /// <summary>
        /// The constructor fo the object
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="picture"></param>
        /// <param name="screenLimit"></param>
        public Shark(Vector2 pos, Texture2D picture)
            : base(pos, picture)
        {
        }

        #endregion 

        #region Methods, Draw, and Update

        /// <summary>
        /// Updates the shark object's X position to move left and right
        /// </summary>
        public void Swim()
        {
            if (Position.X < 0 || Position.X + 98 > Globals.ScreenWidth)
            {
                direction *= -1;
                if (direction == 1)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    spriteEffects = SpriteEffects.None;
                }
            }
            Position = new Vector2(Position.X + 2 * (direction), Position.Y);
        }

        /// <summary>
        /// Allows for the object to update its object
        /// </summary>
        public override void Update()
        {
            base.Update();
            Swim();
        }

        /// <summary>
        /// Draw the shark object
        /// </summary>
        /// <param name="spritebatch"></param>
        public override void Draw(SpriteBatch spritebatch)
        {
            //base.Draw(spritebatch);
            spritebatch.Draw(ImageToBeDrawn, Bounds, null, Color.White, 0f, Vector2.Zero, spriteEffects, 0f);
        }

        #endregion
    }
}
