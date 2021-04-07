using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class PlayerTower : Component
    {
        private Texture2D Sprite;
        private Vector2 Position;
        private int Health;

        public PlayerTower(Vector2 Position)
        {
            this.Position = Position;
            Sprite = GameWorld.Instance.Content.Load<Texture2D>("PlayerTower");
        }

        public override void Update(GameTime gameTime)
        {
            if (Health <= 0)
            {
                //GameOver
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}