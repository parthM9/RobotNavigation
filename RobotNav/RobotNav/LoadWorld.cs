using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNav
{
    class LoadWorld
    {
        private string line;
        private System.IO.StreamReader loadFile;
        private List<string> wall = new List<string>();
        private string mapSize;
        private string initialPosition;
        private string goalPosition;

        //list of strings for all the walls (positions) in our world
        public List<string> Wall
        {
            get
            {
                return wall;
            }
        }
        //Initial State of Agent
        public string InitialPositon
        {
            get
            {
                return initialPosition;
            }
        }

        //Goal position for robot
        public string GoalPosition
        {
            get
            {
                return goalPosition;
            }
        }

        public string MapSize
        {
            get
            {
                return mapSize;
            }
        }

        public LoadWorld(string fileName)
        {
            loadFile = new System.IO.StreamReader(fileName);
        }
        //Map is supposed to be such that first line is MapSize, second line is Initial Position Co. , third line is Goal Co. , fourth and other all lines are Co-ordinates for walls with their size.
        //Allocate data from text file to program variable
        public void loadData()
        {
            int counter = 0;

            while ((line = loadFile.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    mapSize = line;
                }

                if (counter == 1)
                {
                    initialPosition = line;
                }

                if (counter == 2)
                {
                    goalPosition = line;
                }

                if (counter >= 3)
                {
                    wall.Add(line);
                }

                counter++;
            }
        }

        //Print map info (Just for checking )
        public void printInfo()
        {
            Console.WriteLine("Map size: {0}", mapSize);
            Console.WriteLine("Initial Position: {0}", initialPosition);
            Console.WriteLine("Goal Positon: {0}", goalPosition);

            foreach (string w in wall)
            {
                Console.WriteLine("Wall: {0}", w);
            }
        }

        public void closeFile()
        {
            loadFile.Close();
        }
    }
}
