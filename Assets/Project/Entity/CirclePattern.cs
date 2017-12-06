using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Project.Entity
{
    public class CirclePattern
    {
        public string direction;
        public int level;
        public CirclePattern(String direction, string level)
        {
            this.direction = direction;
            this.level = Int32.Parse(level);
        }
    }
}
