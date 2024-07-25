using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal abstract class GameObject:IDraw
    {
        public Position position;

        public abstract void Draw();
    }
}
