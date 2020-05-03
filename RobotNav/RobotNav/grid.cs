using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNav
{
    class grid
    {
        private posContain pos;
        private bool isWall;
        private List<path> paths = new List<path>();


        public posContain Pos
        {
            get
            {
                return pos;
            }
        }

        public grid(posContain ppos, bool wall)
        {
            pos = ppos;
            isWall = wall;
        }

        public bool IsWall
        {
            get
            {
                return isWall;
            }

            set
            {
                isWall = value;
            }
        }

        public List<path> Paths
        {
            get
            {
                return paths;
            }

            set
            {
                paths = value;
            }
        }
    }
}
