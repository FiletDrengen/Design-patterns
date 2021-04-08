using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns.CommandPattern
{
    public class InputHandler
{
     // private Dictionary<Keys, ICommand> keybinds = new Dictionary<Keys, ICommand>();
     //
     // public InputHandler()
     // {
     //     keybinds.Add(Keys.Left, new MoveCommand(new float ()));
     //     keybinds.Add(Keys.Right, new MoveCommand(new float ()));
     // }
     //
     // public void Execute(Shield shield)
     // {
     //     KeyboardState keyState = Keyboard.GetState();
     //
     //     foreach (Keys key in keybinds.Keys)
     //     {
     //         if (keyState.IsKeyDown(key))
     //         {
     //             keybinds[key].Execute(shield);
     //         }
     //     }
     // }
}
}
