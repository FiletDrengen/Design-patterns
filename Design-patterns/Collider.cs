using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class Collider : Component
    {
        public bool CheckCollisionEvents { get; set; }
        private Vector2 size;
        private Vector2 origin;
        private Texture2D texture;

        public Rectangle Collisionbox
        {
            get
            {
                return new Rectangle
                    (
                        (int)(GameObject.Position.X - origin.X),
                        (int)(GameObject.Position.Y - origin.Y),

                        (int)size.X,
                        (int)size.Y
                    );
            }
        }

        public Collider(SpriteRenderer spriteRenderer)
        {
            this.origin = spriteRenderer.Origin;
            this.size = new Vector2(spriteRenderer.Sprite.Width, spriteRenderer.Sprite.Height);
            texture = GameWorld.Instance.Content.Load<Texture2D>("Pixel");
        }

        public void OnCollisionEnter(Collider other)
        {
            if (CheckCollisionEvents)
            {
                if (other != this)
                {
                    if (Collisionbox.Intersects(other.Collisionbox))
                    {
                        //Trigger collision
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Collisionbox, null, Color.Red, 0, origin, SpriteEffects.None, 0);
        }

        public override string ToString()
        {
            return "Collider";
        }
    }
}