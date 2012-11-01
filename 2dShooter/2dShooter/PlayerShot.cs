using System;
using System.IO;
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
    class PlayerShot
    {
        private Texture2D playerShot;
        private Rectangle playerShotRect;
        private Color playerShotColor;

        public int playerShotWidth;
        public int playerShotHeight;
        

        public PlayerShot(Texture2D shot, Rectangle shotRect, Color shotColor)
        {
            this.playerShot = shot;
            this.playerShotRect = shotRect;
            this.playerShotColor = shotColor;
        }

        public void Update()
        {
            playerShotRect.Y -= 1;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(playerShot, playerShotRect, playerShotColor);
            sprite.End();
        }
    }
}
