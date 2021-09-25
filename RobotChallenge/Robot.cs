using System;

namespace RobotChallenge
{
    public class Robot
    {
        private string name;
        private int x;
        private int y;
        private Directions facing;
        private bool active;

        public Robot(string name, int x, int y, Directions facing, bool active)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.facing = facing;
            this.active = active;
        }

        public void Move()
        {
            if (facing == Directions.NORTH && y < 4)
            {
                y++;
            }
            else if (facing == Directions.SOUTH && y > 0)
            {
                y--;
            }
            else if (facing == Directions.EAST && x < 4)
            {
                x++;
            }
            else if (facing == Directions.WEST && x > 0)
            {
                x--;
            }
        }

        public void TurnLeft()
        {
            if (facing == Directions.EAST)
            {
                facing = Directions.NORTH;
            }
            else
            {
                facing++;
            }
        }

        public void TurnRight()
        {
            if (facing == Directions.NORTH)
            {
                facing = Directions.EAST;
            }
            else
            {
                facing--;
            }
        }

        public string Name
        {
            get { return name; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Directions Facing
        {
            get { return facing; }
        }

        public bool Active
        {
            get {  return active; }
            set {  active = value; }
        }
    }
}
