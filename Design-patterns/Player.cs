using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class Player : GameObject
    {
        public static Vector2 PlayerPosition = new Vector2(960, 520);

        private int hp = 1;

        public Player()
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