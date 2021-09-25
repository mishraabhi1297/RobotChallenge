# RobotChallenge

1. This is a .NET Framework Console Application
2. You can run this application in Visual Studio and enter one of the valid commands such as 
PLACE X,Y,F     -> where X, Y AND F are origin vales and F is the direction in which the robot is facing (EAST, WEST, NORTH, SOUTH) 
ROBOT N         -> where N is the robot number you wish to activate
MOVE            -> this will move the active robot in the dorection in which the robot is facing
LEFT            -> this will turn the robot 90 degrees to the left
RIGHT           -> this will turn the robot 90 degrees to the right
REPORT          -> this will report the whereabouts of all the robots, including which one is active
EXIT            -> this will exit the application
3. The only additional command is EXIT to exit the application

### Example Input and Output

1. 
Input:
PLACE 1,2,WEST
MOVE
MOVE
RIGHT 
REPORT

Output:
Name: ROBOT 1 (0,2,NORTH) Active

2.
Input:
PLACE 1,2,SOUTH
PLACE 3,3,WEST
MOVE
LEFT
MOVE
PLACE 3,2,NORTH
PLACE 3,5,WEST
ROBOT 3
REPORT

Output:
Name: ROBOT 1 (2,1,EAST)
Name: ROBOT 2 (3,3,WEST)
Name: ROBOT 3 (3,2,NORTH) Active


