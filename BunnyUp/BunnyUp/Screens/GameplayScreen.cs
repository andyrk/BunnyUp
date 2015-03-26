#region File Description
//-------------------------------
//  GameplayScreen.cs
//
//  The gamescreen in which will be used for interactive gameplay.
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
using BunnyUp.GameObjects;
using System.Diagnostics;
#endregion

namespace BunnyUp.Screens
{
    public class GameplayScreen : GameScreen
    {
        #region Fields

        private ContentManager content; 

        private Bunny bunny;
        private Shark shark;
        private Waves frontWave;
        private Waves backWave;
        private BalloonLives balloons;

        private Player player = new Player();
        private Texture2D background;
        private Texture2D livesText;
        private Texture2D gameOverSharkImage;
        private Texture2D gameOverImage;
        private Texture2D scoreImage;

        #endregion

        #region Initialization
 
        /// <summary>
        /// Constructor for the class
        /// </summary>
        public GameplayScreen()
            : base()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Loads graphic content for the screen
        /// </summary>
        public override void LoadContent()
        {
            base.LoadContent();
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            //load interactive object
            Vector2 position = new Vector2(Globals.ScreenWidth/2 - 75, -190);
            bunny = new Bunny(position, content.Load<Texture2D>("bunny-start"), content.Load<Texture2D>("bunny-roll"));
            
            //load visual objects
            background = content.Load<Texture2D>("background");
            livesText = content.Load<Texture2D>("text-lives");
            balloons = new BalloonLives(content.Load<Texture2D>("lives1"), content.Load<Texture2D>("lives2"), content.Load<Texture2D>("lives3"), content.Load<Texture2D>("balloon-r3"), content.Load<Texture2D>("balloon-r2"), content.Load<Texture2D>("balloon-r1"));
            balloons.FloatingPosition = new Vector2(Globals.ScreenWidth, Globals.ScreenHeight);
            gameOverSharkImage = content.Load<Texture2D>("shark-end");
            gameOverImage = content.Load<Texture2D>("gameover");
            scoreImage = content.Load<Texture2D>("text-score");
            frontWave = new Waves(new Vector2(-50, Globals.ScreenHeight - 48), content.Load<Texture2D>("wave-front"), 1);
            backWave = new Waves(new Vector2(-50, Globals.ScreenHeight - 48), content.Load<Texture2D>("wave-back"), -1);
            shark = new Shark(new Vector2(10, Globals.ScreenHeight - 50), content.Load<Texture2D>("shark"));
        }

        #endregion

        #region Methods

        /// <summary>
        /// used to reset objects/variables to a new state. 
        /// </summary>
        public void Restart()
        {
            //restart variables.
            bunny.Reset();
            balloons.Update(player.Lives, bunny.Center);
            balloons.DrawFloating = true;
        }

        /// <summary>
        /// Allows the screen to handle user input
        /// </summary>
        /// <param name="input"></param>
        public override void HandleInput(InputState input)
        {
 	        base.HandleInput(input);

            if(input.LeftClick)
            {
                if (player.Lives > 0)
                {
                    if (bunny.CheckClicked(input.Position))
                    {
                        bunny.StartJumping(input.Position);
                        if (bunny.IsFloating)
                        {
                            bunny.StopFloating(input.Position);
                        }

                        // Assign point value depending on where they clicked
                        if (input.Position.Y < ScreenManager.GraphicsDevice.Viewport.Height / 4)
                        {
                            player.IncrementScore(20);
                        }
                        else if (input.Position.Y < ScreenManager.GraphicsDevice.Viewport.Height / 2)
                        {
                            player.IncrementScore(15);
                        }
                        else if (input.Position.Y < ScreenManager.GraphicsDevice.Viewport.Height / 4 * 3)
                        {
                            player.IncrementScore(10);
                        }
                        else
                        {
                            player.IncrementScore(5);
                        }
                    }
                    else
                    {
                        player.IncrementScore(-5);
                    }
                }
                else
                {
                    //Game over
                    Globals.HighScore = player.Score;
                    ExitScreen();
                    ScreenManager.AddScreen(new MainMenu());
                }
            }
        }

        /// <summary>
        /// Updates the logic on the screen
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="otherScreenHasFocus"></param>
        /// <param name="coveredByOtherScreen"></param>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
            bunny.Update();
            if (bunny.IsFloating)
            {
                balloons.Update(player.Lives, bunny.Center);
            }
            else
            {
                balloons.DrawFloating = false;
                bunny.Move();
            }

            frontWave.Update();
            shark.Update();
            backWave.Update();

            IsRoundOver();
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        public void IsRoundOver()
        {
            if (bunny.Position.Y > Globals.ScreenHeight)
            {
                player.Lives--; 
                Restart();
            }
        }

        /// <summary>
        /// Draws the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Rectangle fullscreen = new Rectangle(0, 0, Globals.ScreenWidth, Globals.ScreenHeight);
            
            ScreenManager.SpriteBatch.Begin();

            ScreenManager.SpriteBatch.Draw(background, fullscreen, Color.White);
            ScreenManager.SpriteBatch.Draw(scoreImage, new Vector2(450, 5), Color.White);
            ScreenManager.SpriteBatch.DrawString(ScreenManager.Font, player.Score.ToString(), new Vector2(Globals.ScreenWidth - 100, 25), Color.White);
            backWave.Draw(ScreenManager.SpriteBatch);

            if (player.Lives > 0)
            {
                ScreenManager.SpriteBatch.Draw(livesText, new Vector2(20, 5), Color.White);
                shark.Draw(ScreenManager.SpriteBatch);
                balloons.Draw(ScreenManager.SpriteBatch);
                bunny.Draw(ScreenManager.SpriteBatch);
                frontWave.Draw(ScreenManager.SpriteBatch);
            }
            else
            {
                ScreenManager.SpriteBatch.Draw(gameOverSharkImage, new Rectangle(Globals.ScreenWidth - gameOverSharkImage.Width, Globals.ScreenHeight - gameOverSharkImage.Height, gameOverSharkImage.Width, gameOverSharkImage.Height), Color.White);
                frontWave.Draw(ScreenManager.SpriteBatch);
                ScreenManager.SpriteBatch.Draw(gameOverImage, new Rectangle(0, 180, gameOverImage.Width, gameOverImage.Height), Color.White);
            }
            ScreenManager.SpriteBatch.End();
        }

        #endregion
    }
}
