using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns.CommandPattern
{
    class MoveCommand : ICommand
{
        //private float rotation;
        private Vector2 velocity;
       
        public MoveCommand(Vector2 velocity)
        {
            this.velocity = velocity;
            //this.rotation = rotation;
        }
       
        public void Execute(Shield shield)
        {
            shield.Move(velocity);
            //shield.Rotate(rotation);
        }
}
}
