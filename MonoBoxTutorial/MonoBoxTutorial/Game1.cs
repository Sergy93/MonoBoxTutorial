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

        private Sprite MainCharacter;

        KeyValuePair<String, Sprite>
            mBackgroundOne,
            mBackgroundTwo,
            mBackgroundThree,
            mBackgroundFour,
            mBackgroundFive;


        private Dictionary<String, Sprite> SpritesList = new Dictionary<String, Sprite>();
        private Dictionary<String, Sprite> BackgroundElements = new Dictionary<String, Sprite>();

        public Game1()
        {
            GraphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }
        protected override void Initialize()
        {

            mBackgroundOne = new KeyValuePair<string, Sprite>("Background01", new Sprite("Background01", 2.0f));
            mBackgroundTwo = new KeyValuePair<string, Sprite>("Background02", new Sprite("Background02", 2.0f));
            mBackgroundThree = new KeyValuePair<string, Sprite>("Background03", new Sprite("Background03", 2.0f));
            mBackgroundFour = new KeyValuePair<string, Sprite>("Background04", new Sprite("Background04", 2.0f));
            mBackgroundFive = new KeyValuePair<string, Sprite>("Background05", new Sprite("Background05", 2.0f));



            base.Initialize();
        }


        protected override void LoadContent()
        {

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            SpritesList.Add("Character", MainCharacter = new Sprite("SquareGuy"));

            mBackgroundOne.Position = new Vector2(0, 0);
            mBackgroundTwo.Position = new Vector2(mBackgroundOne.Position.X + mBackgroundOne.Size.Width, 0);
            mBackgroundThree.Position = new Vector2(mBackgroundTwo.Position.X + mBackgroundTwo.Size.Width, 0);
            mBackgroundFour.Position = new Vector2(mBackgroundThree.Position.X + mBackgroundThree.Size.Width, 0);
            mBackgroundFive.Position = new Vector2(mBackgroundFour.Position.X + mBackgroundFour.Size.Width, 0);



            foreach (var entry in SpritesList)
            {
                entry.Value.LoadContent(Content);
            }

        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();



            if (mBackgroundOne.Position.X < -mBackgroundOne.Size.Width)
            {
                mBackgroundFive.Position.X += mBackgroundFive.Size.Width;
            }

            if (mBackgroundTwo.Position.X < -mBackgroundTwo.Size.Width)
            {
                mBackgroundOne.Position.X += mBackgroundOne.Size.Width;
            }

            if (mBackgroundThree.Position.X < -mBackgroundThree.Size.Width)
            {
                mBackgroundTwo.Position.X += mBackgroundTwo.Size.Width;
            }

            if (mBackgroundFour.Position.X < -mBackgroundFour.Size.Width)
            {
                mBackgroundThree.Position.X += mBackgroundThree.Size.Width;
            }

            if (mBackgroundFive.Position.X < -mBackgroundFive.Size.Width)
            {
                mBackgroundFour.Position.X += mBackgroundFour.Size.Width;
            }

            var aDirection = new Vector2(-1, 0);
            var aSpeed = new Vector2(160, 0);

            mBackgroundOne.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            mBackgroundTwo.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            mBackgroundThree.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            mBackgroundFour.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            mBackgroundFive.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);


        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();

            foreach (var entry in SpritesList)
            {
                entry.Value.Draw(SpriteBatch);
            }


            SpriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
