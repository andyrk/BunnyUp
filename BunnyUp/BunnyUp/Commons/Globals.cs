#region File Description
//-------------------------------
//  GlobalVar.cs
//
//  Represents the global variables
//------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace BunnyUp
{
    public static class Globals
    {
        #region Properties
        public static int HighScore { get; set; }

        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }

        #endregion
    }
}
