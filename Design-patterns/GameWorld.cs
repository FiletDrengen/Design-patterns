using Microsoft.Xna.Framework;
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
        public List<GameObject> gameobject = new List<GameObject>();
        private Vector2 distance;
        private Texture2D Platform;
        private SpriteFont font;

        public Vector2 spritePosition;
        private float rotation;
        private Texture2D Background;
        private Texture2D collisionTexture;

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
            collisionTexture = Content.Load<Texture2D>("Pixel");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Background = Content.Load<Texture2D>("Background");
            sprite = Content.Load<Texture2D>("shield1");
            Platform = Content.Load<Texture2D>("platform");
            font = Content.Load<SpriteFont>("font");
            spritePosition = new Vector2(960, 520);
        }

        public void DrawCollisionBox(GameObject go)
        {
            //Der laves en streg med tykkelsen 1 for hver side af Collision.
            Rectangle topLine = new Rectangle(go.Collision.X, go.Collision.Y, go.Collision.Width, 1);
            Rectangle bottomLine = new Rectangle(go.Collision.X, go.Collision.Y + go.Collision.Height, go.Collision.Width, 1);
            Rectangle rightLine = new Rectangle(go.Collision.X + go.Collision.Width, go.Collision.Y, 1, go.Collision.Height);
            Rectangle leftLine = new Rectangle(go.Collision.X, go.Collision.Y, 1, go.Collision.Height);
            //Der tegnes en streg med tykkelsen 1 for hver side af Collision med collsionTexture med farven rød.
            spriteBatch.Draw(collisionTexture, topLine, Color.Red);
            spriteBatch.Draw(collisionTexture, bottomLine, Color.Red);
            spriteBatch.Draw(collisionTexture, rightLine, Color.Red);
            spriteBatch.Draw(collisionTexture, leftLine, Color.Red);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.Left))
            {
                rotation -= 0.1f;
            }
            else if (keystate.IsKeyDown(Keys.Right))
            {
                rotation += 0.1f;
            }

            foreach (GameObject gameob in gameobject)
            {
                gameob.Update(gameTime);
                foreach (GameObject item in gameobject)
                {
                    gameob.CheckCollision(item);
                }
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
                DrawCollisionBox(go);
                go.Draw(spriteBatch);
            }

            foreach (GameObject go in gameobject)
            {
                go.Draw(spriteBatch);
            }
            spriteBatch.Draw(sprite, spritePosition, null, Color.White, rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(650, 350, 80, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(1250, 350, 80, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(650, 750, 80, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(1250, 750, 80, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, $"Player Health = {Player.hp}", new Vector2(1750, 20), Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}