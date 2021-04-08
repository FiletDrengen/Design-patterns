using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Design_patterns
{
    public class GameObject
    {
        public Texture2D sprite;
        public Vector2 position;
        protected Color color;
        public Vector2 origin;
        protected Vector2 scale;
        protected int offsetX;
        protected int offsetY;
        public float rotation;

        public GameObject()
        {
            rotation = 0;
            color = Color.White;
            scale = new Vector2(1, 1);
        }

        public void SetSprite(string spriteName)
        {
            sprite = GameWorld.Instance.Content.Load<Texture2D>(spriteName);
        }

        public virtual Rectangle Collision
        {
            get
            {
                return new Rectangle(
                       (int)position.X + offsetX,
                       (int)position.Y,
                       (int)sprite.Width,
                       (int)sprite.Height + offsetY
                   );
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void OnCollision(GameObject other)
        {
        }

        public void CheckCollision(GameObject other)
        {
            if (Collision.Intersects(other.Collision) && this != other)
            {
                OnCollision(other);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
               spriteBatch.Draw(sprite, position, null, color, rotation, Vector2.Zero, scale, SpriteEffects.None, 1);
        }
    }
}