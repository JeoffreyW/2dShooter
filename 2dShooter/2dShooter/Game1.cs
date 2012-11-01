using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2dShooter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlayerShip playerShip;
        PlayerShot playerShot;
        SpriteFont font1;              

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }  

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font1 = Content.Load<SpriteFont>("Font1");

            playerShip = new PlayerShip(Content, spriteBatch);
            playerShip.LoadPlayerShip("playerShip", new Rectangle(385, 450, 28, 21), Color.White);
            playerShip.LoadPlayerShot("playerShot", Color.Red);
           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            playerShip.MovePlayerShip(Keys.Up, Keys.Down, Keys.Right, Keys.Left);
            playerShip.PlayerShoot();
            playerShip.UpdateShots();
            

            GameUtilities.UpdateFPS(gameTime);
         
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            playerShip.DrawPlayerShip();

            playerShip.DrawShots();

            GameUtilities.DrawFPS(spriteBatch, font1, new Vector2(10, 10), Color.Red);
            GameUtilities.Draw3DText(spriteBatch, font1, "ShipX: " + playerShip.shipX, new Vector2(10, 30), Color.Red);
            GameUtilities.Draw3DText(spriteBatch, font1, "ShipY: " + playerShip.shipY, new Vector2(10, 50), Color.Red);

            //Take a Screeshoot
            GameUtilities.TakeScreenShot(GraphicsDevice, Keys.PrintScreen);

            
            base.Draw(gameTime);
        }
    }
}
