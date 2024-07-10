using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{


    abstract internal class GameObject : IDraw
    {
        public Position position;
        public abstract void Draw();
    }
}
