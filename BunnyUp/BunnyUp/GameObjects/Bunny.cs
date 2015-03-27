#region File Description
//--------------------------------------
// Bunny.cs
//
// Main interactive object for gameplay
//--------------------------------------
#endregion 

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using BunnyUp;
#endregion 

namespace BunnyUp.GameObjects
{
    class Bunny : GameObject
    {
        #region Fields
        private Texture2D rollingImage;
        private Texture2D fallingImage;
        private Vector2 startPosition;
        private float fallingSpeed;
        private float jumpingDirection;
        private float deAccel;

        #endregion

        #region Properties
        /// <summary>
        /// Gets whether or not the object has been clicked yet
        /// </summary>
        public bool IsFloating { get; private set; }

        /// <summary>
        /// gets whether or not the object is completing its jump
        /// </summary>
        public bool IsJumping { get; private set; }

        /// <summary>
        /// gets the position of where the bunny initiated its jump
        /// </summary>
        public float PreJumpPosition { get; private set; }

        #endregion


        #region Initialization
        /// <summary>
        /// Constructor for the gameobject in which it sets required fields
        /// </summary>
        /// <param name="vectorPos"></param>
        /// <param name="picture1"></param>
        /// <param name="picture2"></param>
        public Bunny(Vector2 vectorPos, Texture2D picture1, Texture2D picture2)
            : base(vectorPos, picture1)
        {
            startPosition = vectorPos;
            fallingImage = picture1;
            rollingImage = picture2;
            IsFloating = true;
        }

        #endregion 

        #region Methods

        /// <summary>
        /// Resets variables to unclicked state;
        /// </summary>
        public override void Reset()
        {
            base.Reset();

            ImageToBeDrawn = fallingImage;
            Position = startPosition;
            IsFloating = true;
            IsJumping = false;
            fallingSpeed = 0;
            jumpingDirection = 0;
        }

        /// <summary>
        /// Updates the Bunny object's X coordinate 
        /// </summary>
        /// <param name="leftBound"></param>
        /// <param name="rightBound"></param>
        public void Move()
        {
            if ((Position.X <= 0) || (Position.X + ImageToBeDrawn.Width >= Globals.ScreenWidth))
            {
                jumpingDirection *= -1;
            }

            if (jumpingDirection == 0 && IsFloating)
            {
                Position += new Vector2(jumpingDirection + 1, 0);
            }
            else
            {
                Position += new Vector2(jumpingDirection / 3, 0);
            }
        }

        /// <summary>
        /// Updates the Bunny object's y coordinate upwards to mimic reaching a peak
        /// </summary>
        private void Jump()
        {
            if ((PreJumpPosition - Position.Y) < Constants.BunnyMaxHeight)
            {
                Position = new Vector2(Position.X, Position.Y - deAccel);
                if (deAccel > 2)
                {
                    deAccel /= 1.15f;
                }
                else
                {
                    deAccel = 1;
                }
            }
            else
            {
                IsJumping = false;
                fallingSpeed = 0;
            }
        }

        /// <summary>
        /// Updates the Bunny Object's Y coordinate downwards while increase
        /// downwards speed
        /// </summary>
        private void Fall()
        {
            fallingSpeed += Constants.BunnyAcceleration;
            Position = new Vector2(Position.X, Position.Y + fallingSpeed);
        }

        /// <summary>
        /// Prepares the Bunny Object to start jumping
        /// </summary>
        /// <param name="point"></param>
        public void StartJumping(Vector2 point)
        {
            PreJumpPosition = point.Y;
            deAccel = 35;
            IsJumping = true;
            jumpingDirection = Center.X - point.X;
        }

        /// <summary>
        /// Sets the Object in the state in which it
        /// has been clicked (no longer floating)
        /// </summary>
        /// <param name="point"></param>
        public void StopFloating(Vector2 point)
        {
            ImageToBeDrawn = rollingImage;
            Position = new Vector2(point.X - rollingImage.Width/2, point.Y - rollingImage.Height/2);
            IsFloating = false;
        }
        /// <summary>
        /// checks if point is within object bounds
        /// checks if object has started to roll
        /// </summary>
        /// <param name="point">mouse point</param>
        /// <returns>true if point intersects object bounds</returns>
        public bool CheckClicked(Vector2 point)
        {
            return Bounds.Intersects(point.ToRectangle());
        }

        /// <summary>
        /// Allows for the Bunny Object to update its logic
        /// </summary>
        public override void Update()
        {
            base.Update();
            if (IsFloating)
            {
                Position = new Vector2(Position.X, Position.Y + 2);
            }
            else
            {
                if (IsJumping)
                {
                    Jump();
                }
                else
                {
                    Fall();
                }
            }
        }

        /// <summary>
        /// Draw the Bunny 
        /// </summary>
        /// <param name="spritebatch"></param>
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(ImageToBeDrawn, Bounds, Color.White);   
        }
        #endregion 
    }

}
