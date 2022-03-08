using System;
using Xunit;


namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void NullChecker() // renamed from ShouldDoSomething
        {
            // TODO: Complete Something, if anything

            //Arrange
            var TacoParser = new TacoParser();

            //Act
            var actual = TacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.720804,-85.280165,Taco Bell La Fayett...", -85.280165)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var test = tacoParser.Parse(line);

            //Assert
            Assert.Equal(expected, test.Location.Longitude);
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("33.911058,-84.82554,Taco Bell Dalla...", 33.911058)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var test = tacoParser.Parse(line);

            //Assert
            Assert.Equal(expected, test.Location.Latitude);
        }
    }
}
