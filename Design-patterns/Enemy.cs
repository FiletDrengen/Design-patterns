using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public class Enemy : GameObject
    {
        private Vector2 VenstreØversteHjørne = new Vector2(200, 200);
        private Vector2 HøjreØversteHjørne = new Vector2(1780, 200);
        private Vector2 VenstreNedersteHjørne = new Vector2(200, 800);
        private Vector2 HøjreNedersteHjørne = new Vector2(1780, 800);

        public static Vector2 CurrentPosition = new Vector2(200, 200);
        private int hp = 1;
        public List<Laser> bullets = new List<Laser>();
        public static List<Laser> deadlaser = new List<Laser>();


        public Texture2D bulletTexture;
        public Vector2 EnemyPosition;
        private int attackCooldown = 2;
        private float attackTime = 0;

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Enemy()
        {
            position = CurrentPosition;
        }
        /// <summary>
        /// creates a new laser
        /// makes the laser spawn in the center of the enemy sprite
        /// adds the laser to the (bullets) list 
        /// resets the attack timer
        /// </summary>
        public void ATTACK()
        {
            Laser laser = new Laser(this);
            laser.Position = position + new Vector2(this.sprite.Width/2, this.sprite.Height/2);
            laser.SetSprite("Laser");
            bullets.Add(laser);
            attackTime = 0;

        }

        private readonly Random random = new Random();

        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        /// <summary>
        /// compares attacktime to cooldown, to give the enemy an interval in shooting
        /// removes a bullet for every deadlaser in the list
        /// updates the Move method
        /// checks collision with laser on all gameobject instances
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            attackTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (attackCooldown < attackTime)
            {
                ATTACK();
            }
            foreach (Laser L in deadlaser)
            {
                bullets.Remove(L);
            }

            Move();

            foreach (Laser laser in bullets)
            {
                laser.Update(gameTime);
                foreach (GameObject item in GameWorld.Instance.gameobjects)
                {
                    laser.CheckCollision(item);
                    item.CheckCollision(laser);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Laser b in bullets)
            {
                b.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }

        /// <summary>
        /// creates a switch case for each position of the enemies
        /// gives the newly spawned enemy 1 hp
        /// calculates and uses the difference in enemy position, and player position, to rotate the enemy sprite towards the player(shield)
        /// </summary>
        public void Move()
        {
            if (hp != 1)
            {
                switch (RandomNumber(0, 4))
                {
                    case 0:
                        position = VenstreNedersteHjørne;
                        break;

                    case 1:
                        position = HøjreØversteHjørne;
                        break;

                    case 2:
                        position = VenstreØversteHjørne;
                        break;

                    case 3:
                        position = HøjreNedersteHjørne;
                        break;

                    case 4:
                        position = HøjreNedersteHjørne;
                        break;

                    default:
                        position = HøjreNedersteHjørne;
                        break;
                }
                Vector2 Distance = Base.PlayerPosition - position;
                hp += 1;
                rotation = (float)(Math.Atan2(Distance.Y, Distance.X) - Math.PI / 2);
            }
        }

        /// <summary>
        /// checks if the laser has bounced off of the shield, before coliding with the enemy
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(GameObject other)
        {
            if (other is Laser && Laser.hasBounced == true)
            {
                   hp -= 1;
                GameWorld.score++;
            }
        }
    }
}