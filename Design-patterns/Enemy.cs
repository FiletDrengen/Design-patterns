using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class Enemy : GameObject
    {
        private Vector2 VenstreØversteHjørne = new Vector2(0, 0);
        private Vector2 HøjreØversteHjørne = new Vector2(1980, 0);
        private Vector2 VenstreNedersteHjørne = new Vector2(0, 1080);
        private Vector2 HøjreNedersteHjørne = new Vector2(1980, 1080);

        public Vector2 CurrentPosition = new Vector2(200, 200);
        private int hp = 1;

        public Enemy()
        {
            position = CurrentPosition;
        }

        private readonly Random random = new Random();

        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        public override void Update(GameTime gameTime)
        {
            Move();
        }

        private void Move()
        {
            if (hp != 1)
            {
                switch (RandomNumber(0, 3))
                {
                    case 0:
                        CurrentPosition = VenstreNedersteHjørne;
                        hp += 1;
                        break;

                    case 1:
                        CurrentPosition = HøjreØversteHjørne;
                        hp += 1;
                        break;

                    case 2:
                        CurrentPosition = VenstreØversteHjørne;
                        hp += 1;
                        break;

                    case 3:
                        CurrentPosition = HøjreNedersteHjørne;
                        hp += 1;
                        break;

                    default:
                        CurrentPosition = HøjreNedersteHjørne;
                        hp += 1;
                        break;
                }
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