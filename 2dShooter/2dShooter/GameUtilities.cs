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
    static class GameUtilities
    {
        #region Variables
        private static int counter = 1;
        private static KeyboardState currentState, preState;

        private static int frameRate = 0;
        private static int frameCounter = 0;
        private static TimeSpan elapsedTime = TimeSpan.Zero; 
        #endregion
 
        public static void TakeScreenShot(GraphicsDevice device, Keys theKey)
        {
             currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(theKey) && preState.IsKeyUp(theKey))
            {
                byte[] screenData;

                screenData = new byte[device.PresentationParameters.BackBufferWidth * device.PresentationParameters.BackBufferHeight * 4];

                device.GetBackBufferData<byte>(screenData);

                Texture2D Screenshot = new Texture2D(device, device.PresentationParameters.BackBufferWidth, device.PresentationParameters.BackBufferHeight, false, device.PresentationParameters.BackBufferFormat);

                Screenshot.SetData<byte>(screenData);

                string name = "Screenshot_" + counter + ".jpeg";
                while (File.Exists(name))
                {
                    counter += 1;
                    name = "Screenshot_" + counter + ".jpeg";

                }

                Stream stream = new FileStream(name, FileMode.Create);

                Screenshot.SaveAsJpeg(stream, Screenshot.Width, Screenshot.Height);

                stream.Close();

                Screenshot.Dispose();
            }

            preState = currentState;
        }

        public static void UpdateFPS(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }
        }

        public static void DrawFPS(SpriteBatch sprite, SpriteFont font, Vector2 fpsPos, Color color)
        {
            frameCounter++;
            sprite.Begin();
            sprite.DrawString(font, "FPS: " + frameRate, fpsPos + new Vector2(1, 1), Color.White);
            sprite.DrawString(font, "FPS: " + frameRate, fpsPos , color);
            sprite.End();
        }

        public static void Draw3DText(SpriteBatch sprite, SpriteFont font, String text, Vector2 textPos, Color fontColor)
        {
            sprite.Begin();
            sprite.DrawString(font, text, textPos + new Vector2(1, 1), Color.White);
            sprite.DrawString(font, text, textPos, fontColor);
            sprite.End();
        }
    }
}
