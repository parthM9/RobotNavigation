using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNav
{
    class path
    {
        grid _location;

        public path(grid location)
        {
            _location = location;
        }

        public grid Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }
    }
}
