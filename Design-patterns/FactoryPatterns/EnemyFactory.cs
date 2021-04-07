using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
     class EnemyFactory : Factory
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
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();
            go.AddComponent(sr);

            switch (type)
            {
                case "Blue":
                    sr.SetSprite("enemyBlue1");
                    go.AddComponent(new Collider(sr));
                    go.AddComponent(new Enemy());
                    break;

                case "Black":
                    sr.SetSprite("BlackEnemy");
                    go.AddComponent(new Collider(sr));
                    go.AddComponent(new Enemy());
                    break;

                default:
                    sr.SetSprite("Mr.Unknown");
                    go.AddComponent(new Collider(sr));
                    go.AddComponent(new Enemy());
                    break;
            }

            return go;
        }
    }
}