using IranianValidators.Validators;
using Xunit;

namespace IranianValidators.Tests;

public class NationalCodeValidatorTests
{
    [Theory]
    [InlineData("0084575941")] // correct
    [InlineData(" 0084575941 ")] // spaces around
    [InlineData("1111111111")] // reptitive digits
    [InlineData("1234567890")] // wrong digit cheak
    [InlineData("")] // Empty string
    [InlineData(null)] // null
    [InlineData("abcdefghij")] // characters instead of digits
    [InlineData("008457594")] //less than 10 digits
    [InlineData("00845759411")] //more than 10 digits
    public void Should_ReturnFalse_For_InvalidCodes(string code)
    {
        Assert.False(NationalCodeValidator.IsValid(code));
    }
}