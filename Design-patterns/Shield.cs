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


        public Shield()
        {
            position = shieldPosition;
        }

        public void Rotate(float rotation)
        {
            rotation *= speed;

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
            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.Left))
            {
                rotation -= 0.1f;
            }
            else if (keystate.IsKeyDown(Keys.Right))
            {
                rotation += 0.1f;
            }
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
