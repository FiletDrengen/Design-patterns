﻿using Microsoft.Xna.Framework;
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
        private Vector2 VenstreNedersteHjørne = new Vector2(200, 880);
        private Vector2 HøjreNedersteHjørne = new Vector2(1780, 880);

        public static Vector2 CurrentPosition = new Vector2(200, 200);
        private int hp = 1;
        public List<Laser> bullets = new List<Laser>();

        public Texture2D bulletTexture;
        public Vector2 EnemyPosition;
        private int Cooldown = 5;
        private float Time;

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

        public void ATTACK()
        {
            Laser laser = new Laser(this);
            laser.Position = position + new Vector2(this.sprite.Width / 2, this.sprite.Height / 2);
            laser.SetSprite("Laser");
            bullets.Add(laser);
        }

        private readonly Random random = new Random();

        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        public override void Update(GameTime gameTime)
        {
            Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Cooldown < Time)
            {
                hp -= 1;
                ATTACK();
                Time = 0;
            }

            Move();

            foreach (Laser laser in bullets)
            {
                laser.Update(gameTime);
                foreach (GameObject item in GameWorld.Instance.gameobject)
                {
                    laser.CheckCollision(item);
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

        public void Move()
        {
            if (hp != 1)
            {
                switch (RandomNumber(0, 3))
                {
                    case 0:
                        position = VenstreNedersteHjørne;
                        hp += 1;
                        break;

                    case 1:
                        position = HøjreØversteHjørne;
                        hp += 1;
                        break;

                    case 2:
                        position = VenstreØversteHjørne;
                        hp += 1;
                        break;

                    case 3:
                        position = HøjreNedersteHjørne;
                        hp += 1;
                        break;

                    default:
                        position = HøjreNedersteHjørne;
                        hp += 1;
                        break;
                }
                Vector2 Distance = Player.PlayerPosition - position;

                rotation = (float)(Math.Atan2(Distance.Y, Distance.X) - Math.PI / 2);
            }
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Laser)
            {
                hp -= 1;
            }
        }
    }
}