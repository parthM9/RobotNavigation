# RobotNavigation
	INSTRUCTIONS

In order to run the robot navigation system which I built on C# you can either use visual studio  to run the code or you can also run the program by opening the .exe file in the bin/Debug folder which would run the program for you.

Once you run the program your given option to choose which algorithm you want to run which accepts output in text value of the four algorithms implemented for navigation. 



	
	UI implementation for program runs by default when you run the code and choose your algorithm. UI is pretty basic consisting of grid map and showing you how robot moved around in map for each search. 
	 	















	Introduction
		
	Robot Navigation system


As name suggests this system or program builds an AI agent/robot which can navigate through a path to reach end goal. For this particular problem the environment is supposed to be NxM grid. Robot will initially be located in one of the cells and initial position will be marked as ‘i’ in the user interface of command line. For instance the test file I added was same as the one given to us which looks like this :  
![image](https://github.com/parthM9/RobotNavigation/assets/42254898/a10ecec1-141b-49af-b02f-ec025c59957f)
Fig 1 – Test Map for the field

Here the robot will be on red tile and the goal is to get to the green tile using different algorithms. Although in my case I built it such that there will be only one green tile so as to keep things simpler. 

Key concepts/terminology : 

A tree-based search is implemented with both uninformed(brute-force) and informed searches(heuristic-based). This program will demonstrate both type via an AI robot navigator working its way to reach the goal on an n by m grid map. Utilized by solver is following search methods : 
Uninformed - 
– Breadth-First Search, BFS
– Depth-First Search, DFS
Informed - 
– Greedy Best-First Search, GBFS
– A* Search, Astar
	

 	Search Algorithms

The search algorithms I implemented are two uninformed and two informed searches which are as follows : 
Uninformed - 
– Breadth-First Search, BFS
– Depth-First Search, DFS
Informed - 
– Greedy Best-First Search, GBFS
– A* Search, Astar


Depth-First Search (DFS)
       
             The DFS is an uninformed tree-based algorithm that uses the idea of backtracking. This involves searches for all nodes by going ahead, if possible, else by backtracking.

Backtracking works like for instance when robot needs to move forward and there are no more nodes available to go along the current path, the robot will move backwards to previous node on same path to find the other nodes left to traverse. All of nodes will be visited on one path and then only after visiting them all the robot will move onto the next path. This follows a stack (LIFO frontier) like structure with basic algorithm for robot traversal being as follows : 

1.	Pick the initial position as starting node and push all its adjacent nodes(paths available to go) into stack. 
2.	Pop a node from stack to select the next node(path) to visit and then go ahead to push all the adjacent nodes (available to move/go) into the stack for that node we just visited.
3.	Repeat this process until goal is reached which is when the stack will be empties. 

On performing this search based on our case the search visited 33 nodes in total before reaching the goal and the traversal path by the robot looked as shown in Figure 2. Here ‘i’ is initial position of the robot, with ‘’w’’ being the wall where robot can’t traverse through and ‘x’ being the path robot took in order to reach the goal. 
                                       
                                                Fig 2. DFS Navigation 
The output field for our test case looks as shown in Fig 3. : 

 
                                                  Fig 3. DFS output for used test file


	A brief comparison of number of visited nodes for this test case compared to other algorithms can be seen in table 1 given at the end of search algorithms.

Breadth-First Search (BFS)

BFS is traversing uninformed algorithm like DFS but here you traverse a little bit differently. This algorithm creates a set of all possible routes and attempts each one until it finds the end node. Once the algorithm finds a path that reaches the goal it will go there with shortest path but this makes this insufficient as for larger grids/ maps it will take long to traverse through all the paths first then moving to next path. So in terms of our test case, if robot follows BFS algorithm it will traverse through all the paths available for a given node before going into next node. Similarly for next node it will check all available paths to move, and traverse through them and come back to the current node before deciding to move to next node. This makes it time consuming but this guarantees robot to find the goal and reach it. This follows First in First out approach which we will be using queue to traverse through. 

For our case in the program it is used as follows : 

1.	Starting as visited node to be initial node and moving on to check all adjacent paths available to move and enqueue them all and adding them as visited nodes. 
2.	Similar to step 1 we check visited node and dequeue the top node of queue and move on to next node in queue and dequeue and mark the node as visited node now where robot stands.
3.	Repeat step one for this new visited node and enqueue all its nodes and dequeue after once visited all and similarly repeat step 1 and step 2 until we reach the end point.

On performing BFS based on our test case – robot visited 37 nodes in total before reaching end goal making it more time consuming then DFS and traversal path it took after searching for all nodes is as shown in figure 4.
                                                   
                                                           Fig 4. BFS search 

As one can notice from the output path that robot takes the shortest path but still visited nodes are 37 as it first visits all the available path before making the shortest path to reach the goal. The output path is as shown in figure 5. 
 
                                               Fig 5. BFS visited nodes along with path used by robot





Greedy Best-First Search

This is informed search algorithm where we consider among the possible paths or nodes to traverse which one is most promising ,i.e, closest node to the goal and then the robot moves. This falls under Heuristic Search to be specific. Unlike DFS and BFS, this algorithm actually tries to calculate something and then move onto next node depending upon value. Similary for next node the robot moves it will calculate h-value and frontier moves to next node depending on that. the greedy BFS algorithm, the evaluation function is f(n)=h(n), that is, the greedy BFS algorithm first expands the node whose estimated distance to the goal is the smallest. So, greedy BFS does not use the "past knowledge", i.e. g(n). Hence its connotation "greedy". In general, the greedy BST algorithm is not complete, that is, there is always the risk to take a path that does not bring to the goal. In the greedy BFS algorithm, all nodes on the border (or fringe or frontier) are kept in memory, and nodes that have already been expanded do not need to be stored in memory and can therefore be discarded. In general, the greedy BFS is also not optimal, that is, the path found may not be the optimal one. In general, the time complexity is O(bm), where b is the (maximum) branching factor and m is the maximum depth of the search tree. The space complexity is proportional to the number of nodes in the fringe and to the length of the found path.


For our case in program it works as follows : 

1.	Starting at initial node ( assuming it is not goal node itself) , the AI will calculate h-value for each of the paths it can move to. h-value is based on the distance of the node to the goal. 
2.	Comparing the h-values the robot will move to next node which is nearest to goal regardless of cost value or any other parameters such as wall blocking way or such.
3.	Once the robot moves to next node it performs similar steps as step 1 and 2 and continues till it reaches goal.

For our default test case used, the robot completes GBFS to find goal in 13 nodes to reach goal. Path it took is as shown in Fig 6. 
                                                 
                                                                   Fig 6. GBFS search

The output path for GBFS search for our test case is as shown in Fig 7 below.
  
                                                    Fig 7. Output for DBFS in default test case.







A* ( A Star )


A* search algorithm is another informed algorithm like GBFS but unlike that and other algorithm this algorithm has “brains”, i.e, it uses the sum of cost of movement and heuristic value to move from one node to another. So unlike GBFS the case of the A* algorithm, the evaluation function is f(n)=g(n)+h(n)
, where h is an admissible heuristic function. The "star", often denoted by an asterisk, *, refers to the fact that A* uses an admissible heuristic function, which essentially means that A* is optimal, that is, it always finds the optimal path between the starting node and the goal node. A* is also complete (unless there are infinitely many nodes to explore in the search space). The time complexity is O(bm). However, A* needs to keep all nodes in memory while searching, not just the ones in the fringe, because A*, essentially, performs an "exhaustive search" (which is "informed", in the sense that it uses a heuristic function). A* is complete, optimal, and it has a time and space complexity of O(bm). 

So for our case in program the A* works as follows : 

1.	Starting with initial position and making it visited node the AI moves on to put in open node and then calculate g and h values which are cost of movement and heuristic values. 
2.	Once calculated all and comparing all the value it will move towards the optimal node.
3.	It will keep on repeating this process until it reaches the goal.

For our default test case used, the robot reaches the goal at 14 steps and takes the following path to reach goal as shown in Fig 8.

                                                
                                                                   Fig 8. A* Search

Output for A* star search looks like below for our test case as shown in Fig 9.  
                                                             Fig 9. Output for A* search









 Implementation

Before moving to implementation of search methods I would like to first provide a brief overview of program via basic class diagram for it as seen below in Fig 10.

 
                                                              Fig 10. Class Diagram for Program


Basic Overview : 

In this program basic thing is I load the test file first in main and pass it over to LoadWord which is responsible for loading the test file and dividing all the string lines and storing them appropriately after which when we call worldMap class from main , it will be responsible for drawing the map and walls via help of few other classes such as grid class which is the basic grid for map and posContain which is simple but essentially a container class which works like point2D system and is responsible for storing x,y combined values of every positions. There is also path class which tells you of position mainly of paths adjacent to visited node. stringCon class is mainly the string conversion class which converts the string position co-ordinates to int co-ordinates which can be used where needed. Then once worldMap is loaded we move on to navigator class which is responsible for implementing all the search methods and calling the UI class to display basic UI of map to user.

DFS Implementation : 

As mentioned above in the search algorithm parts and quoting it, this follows a stack (LIFO frontier) like structure with basic algorithm for robot traversal being as follows : 

1.	Pick the initial position as starting node and push all its adjacent nodes(paths available to go) into stack. 
2.	Pop a node from stack to select the next node(path) to visit and then go ahead to push all the adjacent nodes (available to move/go) into the stack for that node we just visited.
3.	Repeat this process until goal is reached which is when the stack will be empties. 


In this DFS implementation, I first check if the initial position is equal to goal Position because if it is solution is found there and no further thing needed. If not, I create a stack to store all the open nodes and list of posContain(x and y) values for visited nodes. Then I initialize the visitedNode which is important to do.
 
Then first thing as this is DFS we have to push the initial position node into stack which is then visited in open stack and then popped out and put in the visited node . Once in visited node we will expand and also put node in visited list. Then I draw the UI , afterwhich I check the expanding grid/nodes are within map and check for adjacent nodes if they are available ( ,i.e, no wall).  Keep on repeating state checking and popping of nodes until we reach goal. If solution/goal is found move onto produceSolution function which is responsible for output managing. 
 

BFS Implementation

As mentioned above in search algorithm section and to quote , this follows First in First out approach means we will be using queue to traverse through. 

For our case in the program it is used as follows : 

1.	Starting as visited node to be initial node and moving on to check all adjacent paths available to move and enqueue them all and adding them as visited nodes. 
2.	Similar to step 1 we check visited node and dequeue the top node of queue and move on to next node in queue and dequeue and mark the node as visited node now where robot stands.
3.	Repeat step one for this new visited node and enqueue all its nodes and dequeue after once visited all and similarly repeat step 1 and step 2 until we reach the end point.


First few things remain same which is initializing the open and visiting nodes but here we use queue to initialize open nodes as we need to make it first in first out approach. Then we enqueue the open node with current position.

 


Once all initialization is done we expand the first node of queue and add it to visiting node and initialize UI to mark down the process. Then we start the process of checking each node and perform repeated state checking while also ensuring all the available paths are enqueued to frontier list until the solution is found.











 


GBFS Implementation

As mentioned in search algorithms above and quoting it , for our case in program it works as follows : 

1.	Starting at initial node ( assuming it is not goal node itself) , the AI will calculate h-value for each of the paths it can move to. h-value is based on the distance of the node to the goal. 
2.	Comparing the h-values the robot will move to next node which is nearest to goal regardless of cost value or any other parameters such as wall blocking way or such.
3.	Once the robot moves to next node it performs similar steps as step 1 and 2 and continues till it reaches goal.


Starting the coding with first checking if initial position is equal to goal position, if not we move on with search and initialize all the things needed such as open nodes, visited nodes, expanding nodes and such. Then we draw UI and start with steps of calculating and moving.
 

Before we start with calculation we  need to make sure to sort the open nodes list at the beginning of loop in order to make sure that the first node of open list is always greedy best node , robot needs to move to . Now after that on calculation part we  keep on checking and calculating the h-value which is distance of the node to the goal , we keep on calculating and moving nodes based on the value till robot reaches goal. 

 


A* implementation

As mentioned in the search algorithm section and quoting it , for our case in program the A* works as follows : 

1.	Starting with initial position and making it visited node the AI moves on to put in open node and then calculate g and h values which are cost of movement and heuristic values. 
2.	Once calculated all and comparing all the value it will move towards the optimal node.
3.	It will keep on repeating this process until it reaches the goal.

Again first checking the initial position and verifying it is not equal to final position we move on to A* part where we  first initialize open node, visiting node, expanding node and importantly the gscore in A* case as we need to calculate it in order to move ahead.
 


Then similar to previous algorithms , I check if expanding node is still within map then check the adjacent nodes are available if so  , it performs repeated state checking and calculates g(n) from start to current node and calculate the f(n) value after which is sum of g(n) and h(n). After  calculating we add adjacent node to open list and keep on repeating the process until robot reaches its goal. 

 




















Features: 

1.	A working robot navigation system that works for as many test cases as you need as long as test file remains in similar format.

2.	UI display of movement of robot including the movement it takes while scouting/searching each node.

3.	Easy to run the program using exe file.























Conclusion 

When it comes to best algorithm for path finding searching , I think we can safely rule out DFS and BFS. So informed algorithm are best for path finding search. 

So comparing GBFS and A* algorithm, greedy BFS is not complete, not optimal, has a time and a space complexity which can be polynomial. A* is complete, optimal, and it has a time and space complexity of O(bm). So, in general, A* uses more memory than greedy BFS. A* becomes impractical when the search space is huge. However, A* also guarantees that the found path between the starting node and the goal node is the optimal one and that the algorithm eventually terminates. Greedy BFS, on the other hand, uses less memory, but does not provide the optimality and completeness guarantees of A*. So, which algorithm is the "best" depends on the context, but both are "best"-first searches.


References 

•	Article on Geekforgeeks.org 

-	Contributors for Geekforgeeks, “A* search algorithm” “GBFS search algorithm”, viewed 28 March 2020
<https://www.geeksforgeeks.org/a-search-algorithm/>

•	Article on hackerearth.com about DFS and BFS

-	Contributors for hackerearth.com, “’Depth First search” “Breadth First Search”, viewed 27 March 2020
<https://www.hackerearth.com/practice/algorithms/graphs/depth-first-search/tutorial/>
<https://www.hackerearth.com/practice/algorithms/graphs/breadth-first-search/tutorial/>
















	


