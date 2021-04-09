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
        private int speed = 350;
        private GameObject enemy;

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
        }

        public override void Update(GameTime gameTime)
        {
            position += velocity * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Base)
            {
                Base.hp--;
                Enemy.deadlaser.Add(this);
            }
            else if (other is Shield)
            {
                velocity *= -1;
            }
        }
    }
}