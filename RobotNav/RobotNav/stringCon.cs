using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNav
{
    class stringCon
    {
        private string stringToDivide;

        public stringCon(string s)
        {
            stringToDivide = s;
        }

        public List<int> getIntFromString()
        {
            string[] numbers = Regex.Split(stringToDivide, @"\D+");

            List<int> listInt = new List<int>();

            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    listInt.Add(i);
                }
            }

            return listInt;
        }
    }
}
