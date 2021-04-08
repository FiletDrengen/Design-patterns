using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns.CommandPattern
{
    interface ICommand
{
        void Execute(Shield shield);
}
}
