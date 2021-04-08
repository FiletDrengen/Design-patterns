using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns.ObjectPool
{
    class EnemyPool : ObjectPool
    {
        private static EnemyPool instance;

        public static EnemyPool Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyPool();
                }
                return instance;
            }
        }
        protected override void Cleanup(GameObject gameObject)
        {

        }
        protected override GameObject Create()
        {
            return EnemyFactory.Instance.Create("Blue");
        }

    }


}
