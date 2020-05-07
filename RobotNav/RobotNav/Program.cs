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
           
            LoadWorld load = new LoadWorld(args[0].ToLower()+".txt");

            //Read test file and populate data to suitable variables
            load.loadData();
            //load.printInfo();
            worldMap Map = new worldMap(load.MapSize, load.Wall);
          
            navigator nav = new navigator(load.InitialPositon, load.GoalPosition, Map);


            string val = "";

            

               
                switch (args[1].ToLower())
                {
                    case "dfs":
                        Console.WriteLine("Would you like GUI to be enabled (Not good with larger size)? Y/N ");
                        val = Console.ReadLine();
                        Console.WriteLine(nav.DfsSearch(val));
                        break;
                    case "bfs":
                    Console.WriteLine("Would you like GUI to be enabled (Not good with larger size)? Y/N ");
                    val = Console.ReadLine();
                    Console.WriteLine(nav.BfsSearch(val));
                        break;
                    case "gbfs":
                    Console.WriteLine("Would you like GUI to be enabled (Not good with larger size)? Y/N ");
                    val = Console.ReadLine();
                    Console.WriteLine(nav.GbfsSearch(val));
                        break;
                    case "astar":
                    Console.WriteLine("Would you like GUI to be enabled (Not good with larger size)? Y/N ");
                    val = Console.ReadLine();
                    Console.WriteLine(nav.AStar(val));
                        break;

                    default:
                        Console.WriteLine("No search method called ");
                        break;
                }
            
            Console.ReadLine();
        
        }
    }
}
