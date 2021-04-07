using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    class PlatformsEnemies : GameObject
    {
        private Vector2 Left = new Vector2(0, 0);
        private Vector2 Up = new Vector2(1980, 0);
        private Vector2 Down = new Vector2(0, 1080);
        private Vector2 Right = new Vector2(1980, 1080);
    }
}
