using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns.CommandPattern
{
    public class InputHandler
{
     private Dictionary<Keys, ICommand> keybinds = new Dictionary<Keys, ICommand>();
    /// <summary>
    /// adds the specific keybinds to the dictionary
    /// </summary>
     public InputHandler()
     {
         keybinds.Add(Keys.Left, new MoveCommand(new Vector2(-1, 0)));
         keybinds.Add(Keys.Right, new MoveCommand(new Vector2(1, 0)));
         keybinds.Add(Keys.Up, new MoveCommand(new Vector2(0, -1)));
         keybinds.Add(Keys.Down, new MoveCommand(new Vector2(0, 1)));
     }
    
        /// <summary>
        /// checks if the key has been pressed, and executes the action for that key
        /// </summary>
        /// <param name="shield"></param>
     public void Execute(Shield shield)
     {
         KeyboardState keyState = Keyboard.GetState();
    
         foreach (Keys key in keybinds.Keys)
         {
             if (keyState.IsKeyDown(key))
             {
                 keybinds[key].Execute(shield);
             }
         }
     }
}
}
