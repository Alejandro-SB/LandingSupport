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
        public LandingPlatform(int height, int width)
        {
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), height, "The value of the height must be greater than 0");
            }

            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width, "The value of the width must be greater than 0");
            }

            Height = height;
            Width = width;
        }
    }
}