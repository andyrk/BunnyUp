#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BunnyUp;
#endregion 

namespace BunnyUp.GameObjects
{
    public abstract class GameObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the position of object
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Returns the gameobjects origin(center) based on its current position and image size.
        /// </summary>
        public Vector2 Center
        {
            get
            {
                return new Vector2(Position.X + ImageToBeDrawn.Width / 2, Position.Y + ImageToBeDrawn.Height / 2);
            }
        }

        /// <summary>
        /// Gets or sets the image that is expected to be drawn
        /// </summary>
        public Texture2D ImageToBeDrawn { get; set; }


        /// <summary>
        /// gets the rectangular bounds of the game object based on the width and height
        /// </summary>
        public Rectangle Bounds
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, ImageToBeDrawn.Width, ImageToBeDrawn.Height); }
        }

        #endregion 

        #region Initialization

        /// <summary>
        /// constructs a new gameobject component
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="texture"></param>
        public GameObject(Vector2 pos, Texture2D texture)
        {
            Position = pos;
            ImageToBeDrawn = texture;
        }

        #endregion 

        #region Methods

        #endregion

        #region Update and Draw

        /// <summary>
        /// Primarily used to reset variables to its initial state
        /// </summary>
        public virtual void Reset()
        { 

        }

        /// <summary>
        /// Allows for the object to run update its logic
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// Draws the GameObject
        /// </summary>
        /// <param name="spritebatch"></param>
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(ImageToBeDrawn, Position, Color.White);
        }

        #endregion
    }
}
