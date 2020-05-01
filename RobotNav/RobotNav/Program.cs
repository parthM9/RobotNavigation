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
          
            navigator ai = new navigator(load.InitialPositon, load.GoalPosition, Map);



            Console.WriteLine("What would you like to perform?");
            Console.WriteLine("1.DFS \r\n2.BFS \r\n3.GBFS \r\n4.Astar");
            Console.WriteLine("Enter the text value you wish to run(Eg.DFS)");
            string val="";
            val = Console.ReadLine();
          
            switch (val.ToLower())
            {
                case "dfs":
                    Console.WriteLine(ai.DfsSearch());
                    break;
                case "bfs":
                    Console.WriteLine(ai.BfsSearch());
                    break;
                case "gbfs":
                    Console.WriteLine(ai.GbfsSearch());
                    break;
                case "astar":
                    Console.WriteLine(ai.AStar());
                    break;
                default:
                    Console.WriteLine("No search method called " + args[1]);
                    break;
            }
            Console.ReadLine();
        
        }
    }
}
