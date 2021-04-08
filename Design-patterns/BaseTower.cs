using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class BaseTower
    {
        private static BaseTower instance;
        private GameObject go = new GameObject();

        public static BaseTower Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BaseTower();
                }
                return instance;
            }
        }

        public GameObject CreatePlayer()
        {
            Base baseTower = new Base();
            baseTower.SetSprite("PlayerTower");
            return baseTower;
        }
    }
}