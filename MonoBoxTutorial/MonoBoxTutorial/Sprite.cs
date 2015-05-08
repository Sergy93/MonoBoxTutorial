using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBoxTutorial
{
    class Sprite
    {
        public Vector2 Position = new Vector2(0, 0);

        public Texture2D SpriteTexture;

        public Rectangle Size;
        public float Scale;

        public String SpriteFile;


        public Sprite(String filename, float scale = 1.0f)
        {
            SpriteFile = filename;
            Scale = scale;
        }

        //Main methods
        public void LoadContent(ContentManager contentmanager)
        {
            SpriteTexture = contentmanager.Load<Texture2D>(SpriteFile);

            Size = new Rectangle(0, 0, (int)(SpriteTexture.Width * Scale), (int)(SpriteTexture.Height * Scale));
        }

        public void LoadContent(ContentManager contentmanager, string assetName)
        {
            SpriteTexture = contentmanager.Load<Texture2D>(assetName);

            LoadContent(contentmanager);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Position, new Rectangle(0, 0, SpriteTexture.Width, SpriteTexture.Height),
                Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

    }


}
