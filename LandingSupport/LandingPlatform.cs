using System;
using System.Drawing;

namespace LandingSupport
{
    public class LandingPlatform
    {
        public Point Position { get; }
        public int Height { get; }
        public int Width { get; }

        public LandingPlatform(Point position, int height, int width)
        {
            if(height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), height, "The value of the height must be greater than 0");
            }

            if(width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width, "The value of the width must be greater than 0");
            }

            if(position.X < 0 || position.Y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "The coordinates X and Y of the platform should be positive or zero");
            }

            Position = position;
            Height = height;
            Width = width;
        }
    }
}