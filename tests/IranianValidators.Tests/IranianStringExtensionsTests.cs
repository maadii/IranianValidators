using IranianValidators.Extensions;
using IranianValidators.Validators;
using Xunit;

namespace IranianValidators.Tests;

public class IranianStringExtensionsTests
{
    [Fact]
    public void Should_Validate_Iranian_National_Code_Correctly()
    {
        Assert.True("2143100310".IsIranianNationalCodeValid());
        Assert.False("1234567890".IsIranianNationalCodeValid());
        Assert.False("".IsIranianNationalCodeValid());
    }

    [Fact]
    public void Should_Validate_Iranian_Bank_Card_Correctly()
    {
        Assert.True("6037997482395952".IsIranianBankCardValid());
        Assert.False("1111222233334444".IsIranianBankCardValid());
        Assert.False("".IsIranianBankCardValid());
    }

    [Fact]
    public void Should_Get_Iranian_Bank_Info_From_Card()
    {
        var info = "6037997514561243".GetIranianBankInfoByCard();

        Assert.Equal("BMEL", info.Abbreviation);
        Assert.Equal("بانک ملی ایران", info.Label);
        Assert.Equal("Bank Melli Iran", info.EnglishName);
    }

    [Fact]
    public void Should_Handle_Unknown_Card_Bin()
    {
        var info = "0000001234567890".GetIranianBankInfoByCard();

        Assert.Equal("000000", info.Bin);
        Assert.Equal("UNKN", info.Abbreviation);
        Assert.Equal("UNKN", info.Label);
        Assert.Equal("UNKN", info.EnglishName);
    }
    [Theory]
    [InlineData("6037997514561236", true)]  // بانک ملی - معتبر
    [InlineData("1111222233334444", false)] // BIN نامعتبر
    [InlineData("0000000000000000", false)] // تکراری
    [InlineData("6037991234567890", false)] // BIN معتبر اما Luhn غلط
    public void Should_Validate_Cards_Based_On_Bin_And_Luhn(string card, bool expected)
    {
        Assert.Equal(expected, BankCardValidator.IsValid(card));
    }
}
