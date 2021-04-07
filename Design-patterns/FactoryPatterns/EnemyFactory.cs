using System;
using System.Collections.Generic;
using System.Text;

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
                    go.AddComponent(new Enemy());
                    break;

                    enemy.SetSprite("BlackEnemy");
                    go.AddComponent(new Enemy());
                    go.AddComponent(new Enemy());
                    break;
                    enemy.SetSprite("Mr.Unknown");
                    go.AddComponent(new Enemy());
                    sr.SetSprite("Mr.Unknown");
                    go.AddComponent(new Enemy());
                    break;
            }

            return enemy;
        }
    }
}