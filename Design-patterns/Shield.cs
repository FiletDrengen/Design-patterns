using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class Shield : GameObject
{
        public static Vector2 shieldPosition = new Vector2(960, 520);

        private GameObject go = new GameObject();

        public Shield()
        {
            position = shieldPosition;
        }

        private static Shield instance;

        public static Shield Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Shield();
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
            Shield shield = new Shield();
            shield.SetSprite("shield1");
            return shield;
        }
    }
}
