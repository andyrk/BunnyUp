#region File Description
//----------------------
//  InputState.cs
//
//  Determines the state of inputs

//----------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
#endregion

namespace BunnyUp.GameStateManagement
{
    public class InputState
    {
        #region Fields

        private MouseState currentMouseState = new MouseState();
        private MouseState previousMouseState = new MouseState();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the position of the input in the form of a Vector
        /// </summary>
        public Vector2 Position
        {
            get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
        }

        /// <summary>
        /// Returns whether the left mouse button has been clicked
        /// </summary>
        public bool LeftClick
        {
            get { return (currentMouseState.LeftButton == ButtonState.Pressed) && (previousMouseState.LeftButton == ButtonState.Released); }
        }

        /// <summary>
        /// Returns whether the right mouse button has been clicked
        /// </summary>
        public bool RightClick
        {
            get { return (currentMouseState.RightButton == ButtonState.Pressed) && (previousMouseState.RightButton == ButtonState.Released); }
        }

        #endregion 

        #region Methods

        /// <summary>
        /// Reads the latest state of the keyboard and gamepad.
        /// </summary>
        public void Update()
        {
            previousMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
        }

        #endregion
    }
}
