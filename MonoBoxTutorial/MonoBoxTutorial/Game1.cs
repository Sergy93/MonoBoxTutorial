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

namespace MonoBoxTutorial
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager GraphicsManager;
        SpriteBatch SpriteBatch;

        Sprite CharacterSprite = new Sprite("SquareGuy");

        Rectangle Size;
        float Scale = 1.0f;

        public Game1()
        {
            GraphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            CharacterSprite.LoadContent(Content);

            Size = new Rectangle(0, 0, (int)(CharacterSprite.SpriteTexture.Width * Scale), (int)(CharacterSprite.SpriteTexture.Height * Scale));

        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            CharacterSprite.Position = new Vector2(125, 250);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();


            CharacterSprite.Draw(SpriteBatch);


            SpriteBatch.Draw(CharacterSprite.SpriteTexture, CharacterSprite.Position,
               new Rectangle(0, 0, CharacterSprite.SpriteTexture.Width, CharacterSprite.SpriteTexture.Height), Color.Transparent,
               0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);

            SpriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
