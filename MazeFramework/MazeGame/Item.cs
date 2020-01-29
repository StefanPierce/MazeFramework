using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.MazeGame
{
    public abstract class Item
    {
        String name;

        public Item(string name)
        {
            this.name = name;
        }
    }
}
