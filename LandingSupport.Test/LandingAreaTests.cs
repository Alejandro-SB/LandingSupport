using System;
using Xunit;
using LandingSupport;
using System.Drawing;

namespace LandingSupport.Test
{
    public class LandingAreaTests
    {
        private readonly LandingArea _landingArea;

        public LandingAreaTests()
        {
            var landingPlatform = new LandingPlatform(10, 10);
            Point platformPosition = new Point(5, 5);
            int height = 100;
            int width = 100;

            _landingArea = new LandingArea(height, width, landingPlatform, platformPosition);
        }

        [Fact]
        public void Constructor_Throws_When_Height_Is_Less_Or_Equal_Than_Zero()
        {
            //Arrange
            int zeroHeight = 0;
            int negativeHeight = -3;
            const int width = 5;
            var landingPlatform = new LandingPlatform(1, 1);
            var platformPosition = new Point(1, 1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingArea(zeroHeight, width, landingPlatform, platformPosition));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingArea(negativeHeight, width, landingPlatform, platformPosition));
        }

        [Fact]
        public void Constructor_Throws_When_Width_Is_Less_Or_Equal_Than_Zero()
        {
            //Arrange
            const int height = 55;
            int zeroWidth = 0;
            int negativeWidth = -15;
            var landingPlatform = new LandingPlatform(1, 1);
            var platformPosition = new Point(1, 1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingArea(height, zeroWidth, landingPlatform, platformPosition));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingArea(height, negativeWidth, landingPlatform, platformPosition));
        }

        [Fact]
        public void Constructor_Stablishes_Values_On_Initialization()
        {
            //Arrange
            const int height = 100;
            const int width = 100;
            var landingPlatform = new LandingPlatform(1, 1);
            var platformPosition = new Point(99, 99);

            //Act
            var landingArea = new LandingArea(height, width, landingPlatform, platformPosition);

            //Assert
            Assert.Equal(height, landingArea.Height);
            Assert.Equal(width, landingArea.Width);
            Assert.Equal(landingPlatform, landingArea.LandingPlatform);
        }

        [Fact]
        public void Construct_Throws_When_Landing_Platform_Is_Out_Of_Bounds()
        {
            //Arrange
            const int height = 100;
            const int width = 100;
            var landingPlatform = new LandingPlatform(2, 2);
            var platformPosition = new Point(100, 100);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LandingArea(height, width, landingPlatform, platformPosition));
        }

        [Fact]
        public void CheckLanding_Returns_Ok_When_Point_Is_In_Landing_Platform()
        {
            //Arrange
            var landingPoint = new Point(5, 5);

            //Act
            string response = _landingArea.CheckLanding(landingPoint);

            //Assert
            Assert.Equal(LandingArea.Ok, response);
        }

        [Fact]
        public void CheckLanding_Returns_OutOfPlatform_When_Point_Is_Out_Of_The_Platform()
        {
            //Arrange
            var landingPoint = new Point(16, 15);

            //Act
            string response = _landingArea.CheckLanding(landingPoint);

            //Assert
            Assert.Equal(LandingArea.OutOfPlatform, response);
        }

        [Fact]
        public void CheckLanding_Returns_Clash_When_Previous_Rocket_Has_Checked_The_Same_Position()
        {
            //Arrange
            var firstRocketLandingPoint = new Point(5, 5);
            var secondRocketLandingPoint = firstRocketLandingPoint;

            //Act
            var firstRocketResponse = _landingArea.CheckLanding(firstRocketLandingPoint);
            var secondRocketResponse = _landingArea.CheckLanding(secondRocketLandingPoint);

            //Assert
            Assert.Equal(LandingArea.Ok, firstRocketResponse);
            Assert.Equal(LandingArea.Clash, secondRocketResponse);
        }

        [Fact]
        public void CheckLanding_Returns_Clash_When_Previous_Rocket_Is_One_Square_Away()
        {
            //Arrange
            var firstRocketLandingPoint = new Point(5, 5);
            var secondRocketLandingPoint = new Point(6, 6);

            //Act
            var firstRocketResponse = _landingArea.CheckLanding(firstRocketLandingPoint);
            var secondRocketResponse = _landingArea.CheckLanding(secondRocketLandingPoint);

            //Assert
            Assert.Equal(LandingArea.Ok, firstRocketResponse);
            Assert.Equal(LandingArea.Clash, secondRocketResponse);
        }

        [Fact]
        public void CheckLanding_Returns_Ok_When_Rockets_Are_More_Than_One_Square_Away()
        {
            //Arrange
            var firstRocketLandingPoint = new Point(5, 5);
            var secondRocketLandingPoint = new Point(6, 7);

            //Act
            var firstRocketResponse = _landingArea.CheckLanding(firstRocketLandingPoint);
            var secondRocketResponse = _landingArea.CheckLanding(secondRocketLandingPoint);

            //Assert
            Assert.Equal(LandingArea.Ok, firstRocketResponse);
            Assert.Equal(LandingArea.Ok, secondRocketResponse);
        }
    }
}