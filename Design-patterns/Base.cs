using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class Base : GameObject
    {
        public static Vector2 PlayerPosition = new Vector2(960, 520);

        public static int hp = 3;

        public Base()
        {
            position = PlayerPosition;
        }

        public override void Update(GameTime gameTime)
        {
            if (hp <= 0)
            {
                //GameOver
            }
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Laser)
            {
                hp -= 1;
            }
        }
    }
}