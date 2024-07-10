using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    internal struct Position
    {


        public int x { get; }
        public int y { get; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Position a, Position b)
        {
            if (a.x == b.x && a.y == b.y)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool operator !=(Position a, Position b)
        {
            if (a.x == b.x && a.y == b.y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
