using System;
using System.Drawing;

namespace LandingSupport
{
    /// <summary>
    /// Represents the landing area
    /// </summary>
    public class LandingArea
    {
        /// <summary>
        /// Message returned when landing position is valid
        /// </summary>
        public static readonly string Ok = "ok for landing";
        /// <summary>
        /// Message returned when landing position collides with another rocket
        /// </summary>
        public static readonly string Clash = "clash";
        /// <summary>
        /// Message returned when landing position goes out of platform
        /// </summary>
        public static readonly string OutOfPlatform = "out of platform";

        /// <summary>
        /// Total height of the landing area
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// Total width of the landing area
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The landing platform of the area
        /// </summary>
        public LandingPlatform LandingPlatform{ get; }

        /// <summary>
        /// Creates an instance of the <see cref="LandingArea" /> class
        /// </summary>
        /// <param name="height">The height of the landing area</param>
        /// <param name="width">The width of the landing area</param>
        public LandingArea(int height, int width, LandingPlatform landingPlatform)
        {
            if(height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), height, "The value of the height must be greater than 0");
            }

            if(width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width, "The value of the width must be greater than 0");
            }

            Height = height;
            Width = width;

            int maxXPosition = landingPlatform.Position.X + landingPlatform.Width - 1;
            int maxYPosition = landingPlatform.Position.Y + landingPlatform.Height - 1;

            if(IsOutOfPlatform(new Point(maxXPosition, maxYPosition)))
            {
                throw new ArgumentOutOfRangeException(nameof(landingPlatform), landingPlatform, "The landing platform is out of bounds");
            }

            LandingPlatform = landingPlatform;
        }

        /// <summary>
        /// Checks if the landing position is valid
        /// </summary>
        /// <param name="position">The predicted landing spot</param>
        /// <returns>If position is correct, returns "ok for landing"; 
        /// if collides with another rocket, returns "clash";
        /// else returns "out of platform"
        /// </returns>
        public string CheckLanding(Point position)
        {
            if(IsOutOfPlatform(position))
            {
                return OutOfPlatform;
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a point is out of the landing platform bounds
        /// </summary>
        /// <param name="p">The point to check</param>
        /// <returns>True if the point is out of bounds, false otherwise</returns>
        private bool IsOutOfPlatform(Point p)
        {
            return p.X < 0 || p.Y < 0 || p.X >= Width || p.Y >= Height;
        }
    }
}