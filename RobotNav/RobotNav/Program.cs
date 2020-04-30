using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNav
{
    class Program
    {
        static void Main(string[] args)
        {
           
            LoadWorld load = new LoadWorld(@"C:\Users\murty\Documents\GitHub\RobotNavigation\RobotNav\RobotNav\test.txt");

            //Read test file and populate data to suitable variables
            load.loadData();
            load.printInfo();
            worldMap Map = new worldMap(load.MapSize, load.Wall);
            Map.printMap();
            Console.ReadLine();
        
        }
    }
}
