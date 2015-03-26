#region File Description
//--------------------------
// Control.cs
//
// abstract class that contains the skeleton structure of controls
//--------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace BunnyUp.Controls
{
    public abstract class Control
    {
        #region Fields

        private int width;
        private int height;

        #endregion 

        #region Properties
        /// <summary>
        /// Gets or sets the controls positions in pixels
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the color overlay to be drawn on the control
        /// </summary>
        public Color Tint { get; set; }

        /// <summary>
        /// Gets or sets the opacity of the control
        /// </summary>
        public float Alpha = 1f;

        /// <summary>
        /// Gets or sets the rotation of the control
        /// </summary>
        public float Rotation { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets or sets the width in pixels of control
        /// </summary>
        public virtual int Width
        {
            get { return width; }
            set
            {
                if (width != value)
                    width = (int)MathHelper.Clamp(value, 0, Int32.MaxValue);
            }
        }

        /// <summary>
        /// Gets or sets the height in pixels of control
        /// </summary>
        public virtual int Height
        {
            get { return height; }
            set
            {
                if (height != value)
                    height = (int)MathHelper.Clamp(value, 0, Int32.MaxValue);
            }
        }

        /// <summary>
        /// Gets the rectangular bounds of the controls based off width and height
        /// </summary>
        public virtual Rectangle Bounds
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Width, Height); }
        }

        /// <summary>
        /// Draws control to screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch) { }

        #endregion
    }
}
