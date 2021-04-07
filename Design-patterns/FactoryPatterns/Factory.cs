using System;
using System.Collections.Generic;
using System.Text;

namespace Design_patterns
{
    public abstract class Factory
    {
        public abstract GameObject Create(string type);

    }

}

