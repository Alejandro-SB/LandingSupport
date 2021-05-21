using System;
using System.Drawing;
using Xunit;

namespace LandingSupport.Test
{
    public class LandingPlatformTests
    {
        [Fact]
        public void Constructor_Throws_When_Height_Is_Less_Or_Equal_Than_Zero()
        {
            //Arrange
            const int width = 70;
            int zeroHeight = 0;
            int negativeHeight = -100;
            Point p = new(0, 0);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(p, zeroHeight, width));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(p, negativeHeight, width));
        }

        [Fact]
        public void Constructor_Throws_When_Width_Is_Less_Or_Equal_Than_Zero()
        {
            //Arrange
            const int height = 60;
            Point p = new(0, 15);
            int zeroWidth = 0;
            int negativeWidth = -3;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(p, height, zeroWidth));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(p, height, negativeWidth));
        }

        [Fact]
        public void Constructor_Throws_When_Position_Is_Less_Than_Zero()
        {
            //Arrange
            int height = 100;
            int width = 100;
            Point negativeXPosition = new(-1, 10);
            Point negativeYPosition = new(10, -1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(negativeXPosition, height, width));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(negativeYPosition, height, width));
        }

        [Fact]
        public void Constructor_Stablishes_Values_On_Initialization()
        {
            //Arrange
            Point p = new(5,5);
            int height = 10;
            int width = 10;

            //Act
            var platform = new LandingPlatform(p, height, width);

            //Assert
            Assert.Equal(p, platform.Position);
            Assert.Equal(height, platform.Height);
            Assert.Equal(width, platform.Width);
        }
    }
}