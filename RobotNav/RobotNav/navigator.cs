﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace RobotNav
{
    class navigator
    {
        private point2D pos;
        private point2D goalPos;
        private worldMap robotMap;
        private UI ui = new UI();

        public point2D Pos
        {
            get
            {
                return pos;
            }
        }


        //Robot constructor
        public navigator(string initialState, string goalState, worldMap map)
        {
            stringCon ifs = new stringCon(initialState);

            List<int> coordinate = ifs.getIntFromString();

            pos = new point2D(coordinate[0], coordinate[1]);

            ifs = new stringCon(goalState);

            coordinate = ifs.getIntFromString();

            goalPos = new point2D(coordinate[0], coordinate[1]);

            robotMap = map;
        }


        //Robot notifying its position and expandable paths
        public void notify()
        {
            Console.WriteLine("I'm currently at ({0},{1})", pos.X, pos.Y);
            foreach (grid g in robotMap.Grids)
            {
                if ((pos.X == g.Pos.X) && (pos.Y == g.Pos.Y))
                {
                    Console.WriteLine("From here I could go to: ");
                    foreach (path p in g.Paths)
                    {
                        Console.WriteLine("({0},{1})", p.Location.Pos.X, p.Location.Pos.Y);
                    }
                }
            }
            Console.WriteLine("My goal is to get to ({0},{1})", goalPos.X, goalPos.Y);
        }


        //Movement functions
        public string MoveUp()
        {
            return "up";
        }

        public string MoveDown(
            )
        {
            return "down";
        }

        public string MoveRight()
        {
            return "right";
        }

        public string MoveLeft()
        {
            return "left";
        }


        //Depth-First Search
        public string DfsSearch()
        {
            if ((pos.X == goalPos.X) && (pos.Y == goalPos.Y))
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for open nodes and visited nodes
                Stack<point2D> open = new Stack<point2D>();
                List<point2D> visited = new List<point2D>();

                //Initialize expanding node
                point2D visitedNode;

                //Push the initial position in the open stack
                open.Push(pos);

                while (open.Count != 0)
                {
                    //Visit a node in the open stack, popping the node out of the open stack
                    visitedNode = open.Pop();

                    //Visit a node and expand, adding the node to the visited list
                    visited.Add(visitedNode);

                    Debug.WriteLine("Expanding: " + visitedNode.Coordinate);
                    //Initialize UI
                    ui.Draw(pos, goalPos, robotMap.WallList, visitedNode, robotMap.Width, robotMap.Length);
                    Thread.Sleep(200);

                    foreach (grid g in robotMap.Grids)
                    {
                        //Verify the expanding grid is within the map
                        if ((visitedNode.X == g.Pos.X) && (visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        p.Location.Pos.ParentNode = new point2D(visitedNode);
                                        Debug.WriteLine(p.Location.Pos.Coordinate);
                                        //Push adjacent nodes to the open frontier
                                        open.Push(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((visitedNode.X == goalPos.X) && (visitedNode.Y == goalPos.Y))
                            {
                                return produceSolution("DFS", Pos, goalPos, visited);
                            }
                        }
                    }
                }

                //If no solution is found
                return "No solution";
            }
        }
        public string produceSolution(string method, point2D initial, point2D child, List<point2D> expanded)
        {
            string solution = "";
            List<point2D> path = new List<point2D>();
            List<string> action = new List<string>();

            expanded.Reverse();

            foreach (point2D p in expanded)
            {
                if ((p.X == child.X) && (p.Y == child.Y))
                    path.Add(p);

                if (path.Count() != 0)
                {
                    if ((path.Last().ParentNode.X == p.X) && (path.Last().ParentNode.Y == p.Y))
                    {
                        path.Add(p);
                    }
                }
            }

            path.Reverse();

            //Produce action from path
            for (int i = 0; i < path.Count(); i++)
            {
                if (i == path.Count() - 1)
                {
                    break;
                }


                if (path[i + 1].Y == path[i].Y - 1)
                {
                    action.Add(MoveUp());
                }

                if (path[i + 1].X == path[i].X - 1)
                {
                    action.Add(MoveLeft());
                }

                if (path[i + 1].Y == path[i].Y + 1)
                {
                    action.Add(MoveDown());
                }

                if (path[i + 1].X == path[i].X + 1)
                {
                    action.Add(MoveRight());
                }





            }

            foreach (string a in action)
            {
                solution = solution + a + "; ";
            }

            ui.DrawPath(pos, goalPos, robotMap.WallList, robotMap.Width, robotMap.Length, path);

            return method + " " + expanded.Count() + " " + solution;
        }
    }
}