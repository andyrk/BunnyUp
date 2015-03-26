#region File Description
//-------------------------------
//  MainMenu.cs
//
//  The opening scene allowing the user to play the game or exit
//------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using BunnyUp.GameStateManagement;
using BunnyUp.Controls;
#endregion

namespace BunnyUp.Screens
{
    public class MainMenu : GameScreen
    {
        #region Fields

        private ContentManager content;
        private Texture2D backgroundTexture;

        private Button startButton;
        private Button quitButton;

        private Rectangle fullscreen;

        #endregion 

        #region Initialization

        /// <summary>
        /// Constructor for the screen
        /// </summary>
        public MainMenu()
            : base()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Loads the graphic content for the screen
        /// </summary>
        public override void LoadContent()
        {
            base.LoadContent();
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            backgroundTexture = content.Load<Texture2D>("opener");
            fullscreen = new Rectangle(0, 0, Globals.ScreenWidth, Globals.ScreenHeight);
            
            startButton = new Button() { Position = new Vector2(85, 80), Width = 110, Height = 60, Font = content.Load<SpriteFont>("gamefont"), Text = "Start", Tint = Color.White, TextColor = new Color(255, 255, 255) };
            quitButton = new Button() { Position = new Vector2(85, 140), Width = 110, Height = 60, Font = content.Load<SpriteFont>("gamefont"), Text = "Quit", Tint = Color.White, TextColor = new Color(255, 255, 255) };

            quitButton.Clicked += () =>
            {
                ScreenManager.Game.Exit();
            };

            startButton.Clicked += () =>
            {
                ExitScreen();
                ScreenManager.AddScreen(new GameplayScreen());
            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Allows the screen to handle the user input
        /// </summary>
        /// <param name="input"></param>
        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);

            if(input.LeftClick)
            {
                startButton.HandleClick(input.Position);

                quitButton.HandleClick(input.Position);
            }   

        }

        /// <summary>
        /// Draws the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            
            ScreenManager.GraphicsDevice.Clear(Color.Black);
            
            ScreenManager.SpriteBatch.Begin();

            ScreenManager.SpriteBatch.Draw(backgroundTexture, fullscreen, new Color(TransitionAlpha, TransitionAlpha, TransitionAlpha));
            startButton.Draw(ScreenManager.SpriteBatch);
            quitButton.Draw(ScreenManager.SpriteBatch);

            ScreenManager.SpriteBatch.DrawString(ScreenManager.Font, Globals.HighScore.ToString(), new Vector2(Globals.ScreenWidth / 2, 0), Color.White);

            ScreenManager.SpriteBatch.End();
        }
        #endregion


    }
}
