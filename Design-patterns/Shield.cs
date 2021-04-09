using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class Shield : GameObject
{
        public static Vector2 shieldPosition = new Vector2(960, 520);

        private GameObject go = new GameObject();

        private float speed;
        

        public Shield(Vector2 startPos)
        {
            this.speed = 1000;
            this.position = startPos;
        }

        public void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            velocity *= speed;

            position += (velocity * GameWorld.DeltaTime);
        }

        private static Shield instance;

        public static Shield Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Shield(new Vector2());
                }
                return instance;
            }
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void OnCollision(GameObject other)
        {
            
        }

        public GameObject CreateShield()
        {
            Shield shield = Shield.Instance;
            shield.SetSprite("shield3");
            return shield;

        }


    }
}
