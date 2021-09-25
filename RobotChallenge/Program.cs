using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameManager();
        }

        public static void GameManager()
        {
            List<Robot> robots = new List<Robot>();
            string command;

            do
            {
                Console.Write("Please enter a valid command (Enter EXIT to exit the game): ");
                command = Console.ReadLine().ToUpper();

                if (command.Trim().StartsWith("PLACE "))
                {
                    // Check parameter values before initializing a robot
                    var parametersString = command.Split(' ')[1];
                    var parametersArray = parametersString.Split(',');

                    if (parametersArray.Length != 3)
                    {
                        Console.WriteLine("Invalid command entered");
                        continue;
                    }

                    var originX = parametersArray[0].ToString().Trim();
                    var originY = parametersArray[1].ToString().Trim();
                    var directionFacing = parametersArray[2].ToString().Trim();

                    if (!(int.TryParse(originX, out int x) && x >= 0 && x < 5)
                        || !(int.TryParse(originY, out int y) && y >= 0 && y < 5)
                        || int.TryParse(directionFacing, out _)
                        || !Enum.TryParse(directionFacing, out Directions facing))
                    {
                        Console.WriteLine("Invalid command entered");
                        continue;
                    }
                    else
                    {
                        // Everything looks good, we can add a new robot
                        robots.Add(new Robot($"ROBOT {robots.Count + 1}", x, y, facing, robots.Count == 0));
                    }
                }
                else if (command.Trim().StartsWith("ROBOT "))
                {
                    if (robots.Count > 0)
                    {
                        var parameter = command.Split(' ')[1];

                        if (!int.TryParse(parameter, out int n))
                        {
                            Console.WriteLine("Invalid command entered");
                            continue;
                        }
                        else
                        {
                            var activeRobot = robots.FirstOrDefault(robot => robot.Active);
                            var robotToBeActivated = robots.FirstOrDefault(r => r.Name.Equals($"ROBOT {n}"));
                            if (robotToBeActivated != null)
                            {
                                activeRobot.Active = false;
                                robotToBeActivated.Active = true;
                            }
                        }
                    }
                }
                else if (command.Trim().Equals("MOVE"))
                {
                    if (robots.Count > 0)
                    {
                        var activeRobot = robots.FirstOrDefault(robot => robot.Active);
                        activeRobot.Move();
                    }
                }
                else if (command.Trim().Equals("LEFT"))
                {
                    if (robots.Count > 0)
                    {
                        var activeRobot = robots.FirstOrDefault(robot => robot.Active);
                        activeRobot.TurnLeft();
                    }
                }
                else if (command.Trim().Equals("RIGHT"))
                {
                    if (robots.Count > 0)
                    {
                        var activeRobot = robots.FirstOrDefault(robot => robot.Active);
                        activeRobot.TurnRight();
                    }
                }
                else if (command.Trim().Equals("REPORT"))
                {
                    if (robots.Count == 0)
                    {
                        Console.WriteLine("No robots have been placed yet");
                    }
                    else
                    {
                        foreach (var robot in robots)
                        {
                            Console.WriteLine($"Name: {robot.Name} ({robot.X},{robot.Y},{robot.Facing}) {(robot.Active ? "Active" : "")}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command entered");
                }

            } while (!command.Equals("EXIT"));
        }
    }
}
