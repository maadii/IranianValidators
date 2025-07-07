using IranianValidators.Extensions;
using Xunit;

namespace IranianValidators.Tests;

public class IranianPostalCodeValidatorTests
{
    [Theory]
    //  Valid postal codes
    [InlineData("1136845741", true)] // تهران
    [InlineData("7134567890", true)] // فارس
    [InlineData("8912345678", true)] // یزد
    [InlineData("1519694114", true)] // قم

    //  Invalid BIN (not in provider)
    [InlineData("9012345678", false)]
    [InlineData("2212345678", false)]

    // Invalid formats
    [InlineData("1111111111", false)] // all same digit
    [InlineData("0000000000", false)]
    [InlineData("abcdefghij", false)] // not digits
    [InlineData("123456789", false)]  // too short
    [InlineData("12345678901", false)] // too long
    [InlineData("", false)]
    [InlineData(" ", false)]
    [InlineData(null, false)]
    public void Should_Validate_Iranian_Postal_Code(string? code, bool expected)
    {
        Assert.Equal(expected, code.IsIranianPostalCodeValid());
    }

    [Theory]
    [InlineData("1136845741", "11", "تهران")]
    [InlineData("7134567890", "71", "فارس")]
    [InlineData("8912345678", "89", "یزد")]
    [InlineData("9912345678", "99", "سیستان و بلوچستان")]
    [InlineData("0012345678", "00", "UNKN")]
    public void Should_Get_Postal_Code_Info(string? code, string expectedBin, string expectedProvince)
    {
        var info = code.GetIranianPostalCodeInfo();
        Assert.Equal(expectedBin, info.Bin);
        Assert.Equal(expectedProvince, info.Province);
    }
}