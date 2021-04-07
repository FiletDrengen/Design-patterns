using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class PlayerTower
    {
        private static PlayerTower instance;
        private GameObject go = new GameObject();

        public static PlayerTower Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerTower();
                }
                return instance;
            }
        }

        public GameObject CreatePlayer()
        {
            Player player = new Player();
            player.SetSprite("PlayerTower");
            return player;
        }
    }
}