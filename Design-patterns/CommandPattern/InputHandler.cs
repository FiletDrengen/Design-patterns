﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns.CommandPattern
{
    public class InputHandler
{
     private Dictionary<Keys, ICommand> keybinds = new Dictionary<Keys, ICommand>();
    
     public InputHandler()
     {
         keybinds.Add(Keys.Left, new MoveCommand(new Vector2(-1, 0)));
         keybinds.Add(Keys.Right, new MoveCommand(new Vector2(1, 0)));
         keybinds.Add(Keys.Up, new MoveCommand(new Vector2(0, -1)));
         keybinds.Add(Keys.Down, new MoveCommand(new Vector2(0, 1)));
        }
    
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
