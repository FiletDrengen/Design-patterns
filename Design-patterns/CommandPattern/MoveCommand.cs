using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns.CommandPattern
{
    class MoveCommand : ICommand
{
        private Vector2 velocity;
       
        public MoveCommand(Vector2 velocity)
        {
            this.velocity = velocity;
        }
       
        public void Execute(Shield shield)
        {
            shield.Move(velocity);
        }
}
}
