﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Design_patterns
{
    public class GameWorld : Game
    {
        public GraphicsDeviceManager graphics;

        public SpriteBatch spriteBatch;
        private Texture2D sprite;
        private Texture2D Platform;
        private List<GameObject> gameobject = new List<GameObject>();
        public Vector2 spritePosition;
        private float rotation;
        private Texture2D Background;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
        }

        private static GameWorld instance;

        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }

                return instance;
            }
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            gameobject.Add(EnemyFactory.Instance.Create("Blue"));
            gameobject.Add(PlayerTower.Instance.CreatePlayer());
            gameobject.Add(PlatformPlayer.Instance.CreatePlatformPlayer());
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Background = Content.Load<Texture2D>("Background");
            sprite = Content.Load<Texture2D>("shield1");
            Platform = Content.Load<Texture2D>("platform");
            spritePosition = new Vector2(960, 520);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.Left))
            {
                rotation-= 0.1f;
            }
            else if (keystate.IsKeyDown(Keys.Right))
            {
                rotation += 0.1f;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, 1920, 1080), Color.White);
            foreach (GameObject go in gameobject)
            {
                go.Draw(spriteBatch);
            }
            spriteBatch.Draw(sprite, spritePosition, null, Color.White, rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(650, 350, 80, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(1250, 350, 80, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(650, 750, 80, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(1250, 750, 80, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);

            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}