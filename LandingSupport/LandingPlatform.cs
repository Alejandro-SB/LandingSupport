using System;
using System.Drawing;

namespace LandingSupport
{
    /// <summary>
    /// Represents a landing platform
    /// </summary>
    public class LandingPlatform
    {
        /// <summary>
        /// The position where the platform is situated
        /// </summary>
        public Point Position { get; }
        /// <summary>
        /// The height of the platform
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// The width of the platform
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Creates an instance of the <see cref="LandingPlatform" /> class
        /// </summary>
        /// <param name="position">The position where the platform is</param>
        /// <param name="height">The height of the platform</param>
        /// <param name="width">The width of the platform</param>
        public LandingPlatform(Point position, int height, int width)
        {
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), height, "The value of the height must be greater than 0");
            }

            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width, "The value of the width must be greater than 0");
            }

            if (position.X < 0 || position.Y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "The coordinates X and Y of the platform should be positive or zero");
            }

            Position = position;
            Height = height;
            Width = width;
        }
    }
}