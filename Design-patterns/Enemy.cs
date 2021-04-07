using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class Enemy : Component
    {
        private Vector2 VenstreØversteHjørne = new Vector2(0, 0);
        private Vector2 HøjreØversteHjørne = new Vector2(1980, 0);
        private Vector2 VenstreNedersteHjørne = new Vector2(0, 1080);
        private Vector2 HøjreNedersteHjørne = new Vector2(1980, 1080);

        private int hp = 1;

        public Enemy()
        {
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
                        GameObject.Position = VenstreNedersteHjørne;
                        hp += 1;
                        break;

                    case 1:
                        GameObject.Position = HøjreØversteHjørne;
                        hp += 1;
                        break;

                    case 2:
                        GameObject.Position = VenstreØversteHjørne;
                        hp += 1;
                        break;

                    case 3:
                        GameObject.Position = HøjreNedersteHjørne;
                        hp += 1;
                        break;

                    default:
                        GameObject.Position = HøjreNedersteHjørne;
                        hp += 1;
                        break;
                }
            }
        }
    }
}