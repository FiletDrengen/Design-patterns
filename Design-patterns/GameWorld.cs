using Design_patterns.CommandPattern;
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
        public List<GameObject> gameobjects = new List<GameObject>();
        
        private Texture2D Platform;
        private SpriteFont font;

        public float rotation;
        private Texture2D Background;
        private Texture2D collisionTexture;

        private InputHandler inputHandler;

        public static int score = 0;

        public static float DeltaTime { get; set; }

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
            inputHandler = new InputHandler();
            gameobjects.Add(EnemyFactory.Instance.Create("Blue"));
            gameobjects.Add(BaseTower.Instance.CreatePlayer());
            gameobjects.Add(PlatformBase.Instance.CreatePlatformPlayer());
            gameobjects.Add(Shield.Instance.CreateShield());
            base.Initialize();
        }

        protected override void LoadContent()
        {
            collisionTexture = Content.Load<Texture2D>("Pixel");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Background = Content.Load<Texture2D>("Background");
            Platform = Content.Load<Texture2D>("platform");
            font = Content.Load<SpriteFont>("font");
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
            if (Base.hp < 1)
            {
                Exit();
            }

            foreach (GameObject gameob in gameobjects)
            {
                gameob.Update(gameTime);
                foreach (GameObject item in gameobjects)
                {
                    gameob.CheckCollision(item);
                }
            }

            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            inputHandler.Execute(Shield.Instance);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, 1920, 1080), Color.White);
            foreach (GameObject go in gameobjects)
            {
#if DEBUG
 DrawCollisionBox(go);
#endif
                go.Draw(spriteBatch);
            }

            foreach (GameObject go in gameobjects)
            {
                go.Draw(spriteBatch);
            }
            spriteBatch.Draw(Platform, new Rectangle(185, 285, 120, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(1760, 285, 120, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(185, 885, 120, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Platform, new Rectangle(1770, 885, 120, 30), null, Color.White, 0, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, $"Player Health = {Base.hp}", new Vector2(1750, 20), Color.Black);
            spriteBatch.DrawString(font, $"Current score = {GameWorld.score}", new Vector2(1600, 20), Color.Black);


            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }

         
        public void RemoveGameObject(GameObject go)
        {
           gameobjects.Remove(go);
        }

    }
}