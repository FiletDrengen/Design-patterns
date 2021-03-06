using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Design_patterns
{
    internal class EnemyFactory : Factory
    {
        private static EnemyFactory instance;
        private float rotation;

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

        /// <summary>
        /// A function that makes an enemy gameobject, depending on what's in the string "type"
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
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


            Vector2 Distance = Base.PlayerPosition - enemy.position;
            return enemy;
        }
    }
}