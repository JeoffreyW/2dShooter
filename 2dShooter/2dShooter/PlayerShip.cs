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
    class PlayerShip
    {

        #region Variables
        private ContentManager content;
        private SpriteBatch sprite;
        KeyboardState currentState, prevState;

        public int shipWidth;
        public int shipHeight;
        public int shipX;
        public int shipY;

        private Texture2D ship;
        private Rectangle shipRect;
        private Color shipColor;

        private Texture2D shot;
        private Rectangle shotRect;
        private Color shotColor;

        private List<PlayerShot> playerShots = new List<PlayerShot>();
        #endregion        

        public PlayerShip(ContentManager manger, SpriteBatch batch)
        {
            this.content = manger;
            this.sprite = batch;
        }

        public void LoadPlayerShip(String assetName, Rectangle shipStartingPos, Color shipStartingColor)
        {
            ship = content.Load<Texture2D>(assetName);
            this.shipColor = shipStartingColor;
            this.shipRect = shipStartingPos;
            shipWidth = ship.Width;
            shipHeight = ship.Height;            
            shipX = shipRect.X;
            shipY = shipRect.Y;
        }

        public void DrawPlayerShip()
        {

            sprite.Begin();
            sprite.Draw(ship, shipRect, shipColor);
            sprite.End();
        }

        public void MovePlayerShip(Keys up, Keys down, Keys right, Keys left)
        {
            if (Keyboard.GetState().IsKeyDown(up))
            {
                this.shipRect.Y -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(down))
            {
                this.shipRect.Y += 1;
            }
            if (Keyboard.GetState().IsKeyDown(right))
            {
                this.shipRect.X += 1;
            }
            if (Keyboard.GetState().IsKeyDown(left))
            {
                this.shipRect.X -= 1;
            }
            shipX = shipRect.X;
            shipY = shipRect.Y;
        }

        public void LoadPlayerShot(String assetName, Color shotStartingColor)
        {
            this.shot = content.Load<Texture2D>(assetName);
            this.shotColor = shotStartingColor;
        }

        public void PlayerShoot()
        {
            currentState = Keyboard.GetState();
            if(currentState.IsKeyDown(Keys.Space) && prevState.IsKeyUp(Keys.Space))
            {
                this.shotRect = new Rectangle(shipX - 2 + (shipWidth / 2), shipY, 4, 5);
                PlayerShot shot = new PlayerShot(this.shot, this.shotRect, this.shotColor);

                playerShots.Add(shot);
            }
            prevState = currentState;
        }

        public void UpdateShots()
        {
            foreach (PlayerShot shot in playerShots)
	        {
                shot.Update();
	        }
        }

        public void DrawShots()
        {
            foreach (PlayerShot shot in playerShots)
	        {
                shot.Draw(this.sprite);
	        }
        }
    }
}
