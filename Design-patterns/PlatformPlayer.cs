using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class PlatformPlayer : GameObject
    {
        public Vector2 PlayerPlatformPosition = new Vector2(890, 570);

        public PlatformPlayer()
        {
            position = PlayerPlatformPosition;
        }

        private static PlatformPlayer instance;

        public static PlatformPlayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlatformPlayer();
                }
                return instance;
            }
        }

        public GameObject CreatePlatformPlayer()
        {
            PlatformPlayer platformPlayer = new PlatformPlayer();
            platformPlayer.SetSprite("platform");
            return platformPlayer;
        }

        
    }
}
