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

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(zeroHeight, width));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(negativeHeight, width));
        }

        [Fact]
        public void Constructor_Throws_When_Width_Is_Less_Or_Equal_Than_Zero()
        {
            //Arrange
            const int height = 60;
            int zeroWidth = 0;
            int negativeWidth = -3;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(height, zeroWidth));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingPlatform(height, negativeWidth));
        }

        [Fact]
        public void Constructor_Stablishes_Values_On_Initialization()
        {
            //Arrange
            int height = 10;
            int width = 10;

            //Act
            var platform = new LandingPlatform(height, width);

            //Assert
            Assert.Equal(height, platform.Height);
            Assert.Equal(width, platform.Width);
        }
    }
}