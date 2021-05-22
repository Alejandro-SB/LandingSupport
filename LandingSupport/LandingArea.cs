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
        /// The position of the last rocket checked
        /// </summary>
        private Point? _lastRocketPosition = null;

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
        public LandingPlatform LandingPlatform { get; }

        /// <summary>
        /// The position of the platform
        /// </summary>
        public Point PlatformPosition { get; }

        /// <summary>
        /// Creates an instance of the <see cref="LandingArea" /> class
        /// </summary>
        /// <param name="height">The height of the landing area</param>
        /// <param name="width">The width of the landing area</param>
        public LandingArea(int height, int width, LandingPlatform landingPlatform, Point platformPosition)
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

            int maxXPosition = platformPosition.X + landingPlatform.Width - 1;
            int maxYPosition = platformPosition.Y + landingPlatform.Height - 1;
            var platformPositionOppositeCorner = new Point(maxXPosition, maxYPosition);

            if (IsOutOfArea(platformPosition) || IsOutOfArea(platformPositionOppositeCorner))
            {
                throw new ArgumentOutOfRangeException(nameof(platformPosition), platformPosition, "Platform position is out of area");
            }

            PlatformPosition = platformPosition;
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
            string landingResponse;

            if (IsInPlatform(position))
            {
                if (CollidesWithLastRocket(position))
                {
                    landingResponse = Clash;
                }
                else
                {
                    landingResponse = Ok;
                }
            }
            else
            {
                landingResponse = OutOfPlatform;
            }

            _lastRocketPosition = position;

            return landingResponse;
        }

        /// <summary>
        /// Checks if a point is out of the landing platform bounds
        /// </summary>
        /// <param name="p">The point to check</param>
        /// <returns>True if the point is out of bounds, false otherwise</returns>
        private bool IsOutOfArea(Point p)
        {
            return p.X < 0 || p.Y < 0 || p.X >= Width || p.Y >= Height;
        }

        /// <summary>
        /// Checks if a point is in the platform
        /// </summary>
        /// <param name="point">The point to check</param>
        /// <returns>True if the point is in the platform, false otherwise</returns>
        private bool IsInPlatform(Point point)
        {
            int platformX = PlatformPosition.X;
            int platformY = PlatformPosition.Y;
            int platformWidth = LandingPlatform.Width;
            int platformHeight = LandingPlatform.Height;

            bool horizontalBoundCheck = platformX <= point.X && ((platformX + platformWidth - 1) >= point.X);
            bool verticalBoundCheck = platformY <= point.Y && ((platformY + platformHeight - 1) >= point.Y);

            return horizontalBoundCheck && verticalBoundCheck;
        }

        /// <summary>
        /// Checks if the position supplied collides with the previous rocket
        /// </summary>
        /// <param name="position">The position to check</param>
        /// <returns>True if it collides, false otherwise</returns>
        private bool CollidesWithLastRocket(Point position)
        {
            if (_lastRocketPosition is Point lastPosition)
            {
                int xDiff = Math.Abs(lastPosition.X - position.X);
                int yDiff = Math.Abs(lastPosition.Y - position.Y);

                return xDiff < 2 && yDiff < 2;
            }
            else
            {
                return false;
            }
        }
    }
}