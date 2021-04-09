using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class Laser : GameObject
    {
        private Vector2 velocity;
        private int speed = 650;
        private GameObject enemy;
        public static bool hasBounced;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        

        public Laser(GameObject enemy)
        {
            velocity = Base.PlayerPosition - enemy.position;
            velocity.Normalize();
            this.enemy = enemy;
            position = new Vector2(0, 0);
            hasBounced = false;
        }

        /// <summary>
        /// updates the position of the laser to enable it to move
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position += velocity * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// checks if the laser is colliding with a Base, Shield, Enemy
        /// if colliding with Base, adds the laser to (deadlaser list)
        /// if colliding with shield, sets has bounced to true and reverses lasers velocity
        /// if colliding with Enemy and hasBounced is true, adds the laser to (deadlaser list)
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(GameObject other)
        {
            if (other is Base)
            {
                Base.hp--;
                Enemy.deadlaser.Add(this);
               
            }
            else if (other is Shield)
            {
               
                if(!hasBounced)
                {
                    velocity *= -1;
                    hasBounced = true;
                }
            }
            if (other is Enemy && hasBounced == true)
            {
                Enemy.deadlaser.Add(this);
            }
        }
    }
}