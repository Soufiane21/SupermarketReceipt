using Xunit;

namespace SupermarketReceipt.Test
{
    public class SampleTest
    {
        [Fact]
        public void SampleTest_Should_Pass()
        {
            // Arrange
            var expected = true;
            
            // Act
            var actual = true;
            
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SampleTest_Should_Return_CorrectValue()
        {
            // Arrange
            var value = 10;
            
            // Act
            var result = value * 2;
            
            // Assert
            Assert.Equal(20, result);
        }
    }
}
