using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Design_patterns
{
    public class GameObject
    {
        private Dictionary<string, Component> components = new Dictionary<string, Component>();
        public static Vector2 Position { get; set; }
        public Texture2D Sprite { get; set; }
        public Vector2 Origin { get; set; } 

        public void AddComponent(Component component)
        {
            components.Add(component.ToString(), component);
            component.GameObject = this;
        }

        public void Update(GameTime gameTime)
        {
            foreach (Component component in components.Values)
            {
                component.Update(gameTime);
            }
        }

        public void Awake()
        {
            foreach (Component component in components.Values)
            {
                component.Awake();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in components.Values)
            {
                component.Draw(spriteBatch);
            }
        }
    }
}