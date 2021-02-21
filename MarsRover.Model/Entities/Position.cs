using System;

namespace MarsRover.Model
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                this.X = x;
                this.Y = y;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}