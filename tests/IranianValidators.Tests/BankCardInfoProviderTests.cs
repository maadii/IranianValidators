using Xunit;
using IranianValidators.Providers;

namespace IranianValidators.Tests;

public class BankCardInfoProviderTests
{
    [Theory]
    [InlineData("6037997514561243", "BMEL", "بانک ملی ایران", "بانک ملی")]
    [InlineData("6104339876543210", "BMEL", "بانک ملت", "بانک ملت")]
    [InlineData("4407961234567890", "BSDR", "بانک صادرات ایران", "بانک صادرات")]
    [InlineData("6369490000000000", "BHKM", "بانک حکمت ایرانیان", "بانک حکمت ایرانیان")]
    public void Should_Return_Correct_Bank_Info(string card, string abbr, string label, string name)
    {
        var info = BankCardInfoProvider.GetInfo(card);
        Assert.Equal(abbr, info.Abbreviation);
        Assert.Equal(label, info.Label);
        Assert.Equal(name, info.BankName);
        Assert.Equal(card.Substring(0, 6), info.Bin);
    }

    [Fact]
    public void Should_Return_Default_For_Unknown_Bin()
    {
        var info = BankCardInfoProvider.GetInfo("0000001234567890");
        Assert.Equal("UNKN", info.Abbreviation);
        Assert.Equal("UNKN", info.Label);
        Assert.Equal("UNKN", info.BankName);
        Assert.Equal("000000", info.Bin);
    }
}
