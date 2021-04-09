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

        /// <summary>
        /// creates a base
        /// gives the base a sprite
        /// </summary>
        /// <returns></returns>
        public GameObject CreatePlayer()
        {
            Base baseTower = new Base();
            baseTower.SetSprite("PlayerTower");
            return baseTower;
        }
    }
}