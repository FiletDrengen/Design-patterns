using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class PlatformBase : GameObject
    {
        public Vector2 BasePlatformPosition = new Vector2(890, 570);

        public PlatformBase()
        {
            position = BasePlatformPosition;
        }

        private static PlatformBase instance;

        public static PlatformBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlatformBase();
                }
                return instance;
            }
        }

        /// <summary>
        /// creates a platformbase
        /// gives the platformbase a sprite
        /// </summary>
        /// <returns></returns>
        public GameObject CreatePlatformPlayer()
        {
            PlatformBase platformPlayer = new PlatformBase();
            platformPlayer.SetSprite("platform");
            return platformPlayer;
        }

        
    }
}
