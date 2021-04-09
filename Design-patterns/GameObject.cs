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
        protected float rotation;
        protected int sizeX;
        protected int sizeY;

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

        /// <summary>
        /// creates a rectangular collisionbox, and makes it possible to give an offset compared to the position / size of the sprite
        /// </summary>
        public virtual Rectangle Collision
        {
            get
            {
                return new Rectangle(
                       (int)position.X + offsetX,
                       (int)position.Y + offsetY,
                       (int)sprite.Width + sizeX,
                       (int)sprite.Height + sizeY
                   );
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void OnCollision(GameObject other)
        {
        }

        /// <summary>
        /// this is the method we use to see if we trigger a collision
        /// this method checks if 2 rectangles are intersecting(colides) with eachother
        /// then it uses the OnCollision method in the other classes we want to trigger something in
        /// </summary>
        /// <param name="other"></param>
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