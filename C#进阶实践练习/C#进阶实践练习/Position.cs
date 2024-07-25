using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    public  struct Position
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Position(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
