#region File Description
//-------------------------------
//  Extensions.cs
//
//  Represents extensions
//------------------------------
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BunnyUp
{
    public static class Extensions
    {
        /// <summary>
        /// An extension to the Rectangle class in which this returns a rectangle based on the vector point
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Rectangle ToRectangle(this Vector2 vector)
        {
            return new Rectangle((int)vector.X, (int)vector.Y, 1, 1);
        }
    }
}
