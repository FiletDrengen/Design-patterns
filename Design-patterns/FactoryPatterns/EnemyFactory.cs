using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Design_patterns
{
    internal class EnemyFactory : Factory
    {
        private static EnemyFactory instance;

        public static EnemyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyFactory();
                }
                return instance;
            }
        }

        public override GameObject Create(string type)
        {
            

            Enemy enemy = new Enemy();

            switch (type)
            {
                case "Blue":
                    enemy.SetSprite("enemyBlue1");
                    break;

                case "Black":
                    enemy.SetSprite("BlackEnemy");
                    break;

                default:
                    enemy.SetSprite("Mr.Unknown");
                    break;
            }

            enemy.origin = new Vector2(enemy.sprite.Width / 2, enemy.sprite.Height / 2);

            Vector2 Distance = Base.PlayerPosition - enemy.position;

            enemy.rotation = (float)(Math.Atan2(Distance.Y, Distance.X) - Math.PI / 2);
            return enemy;
        }
    }
}