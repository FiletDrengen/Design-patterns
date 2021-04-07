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
        private List<GameObject> gameobject = new List<GameObject>();
        private Vector2 distance;
        public Vector2 spritePosition;
        private float rotation;


        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

            GameObject go = new GameObject();

            GameWorld GW = Instance;

            gameobject.Add(EnemyFactory.Instance.Create("Blue"));

            foreach (GameObject goList in gameobject)
            {
                goList.Awake();
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            sprite = Content.Load<Texture2D>("shield");
            spritePosition = new Vector2(200, 200);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //taking the location of the mouse
            MouseState mouse = Mouse.GetState();

            //using the location of the mouse to rotate the sprite
            distance.X = mouse.X - spritePosition.X;
            distance.Y = mouse.Y - spritePosition.Y;

            rotation = (float)Math.Atan2(distance.Y, distance.X);

            MouseState mouseState = Mouse.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (GameObject go in gameobject)
            {
                go.Draw(spriteBatch);
            }
            spriteBatch.Draw(sprite, spritePosition, null, Color.White, rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}