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

        public String SpriteFile;
        //Constructor
        public Sprite(String filename)
        {
            SpriteFile = filename;
        }

        //Main methods
        public void LoadContent(ContentManager contentmanager)
        {
            SpriteTexture = contentmanager.Load<Texture2D>(SpriteFile);
        }

        public void LoadContent(ContentManager contentmanager, string assetName)
        {
            SpriteTexture = contentmanager.Load<Texture2D>(assetName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Position, Color.White);

        }

    }


}
