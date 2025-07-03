using IranianValidators.Extensions;
using Xunit;

namespace IranianValidators.Tests;

public class IranianStringExtensionsTests
{
    [Theory]
    [InlineData("8031014701", true)]
    [InlineData("2143100310", true)]
    [InlineData("1234567890", false)]
    [InlineData("", false)]
    [InlineData("1111111111", false)]
    public void Should_Validate_Iranian_National_Code(string? code, bool expected)
    {
        Assert.Equal(expected, code.IsIranianNationalCodeValid());
    }

    [Theory]
    [InlineData("6037997482395952", true)]  // بانک ملی - معتبر
    [InlineData("6037991234567890", false)] // بانک ملی - نامعتبر (Luhn fail)
    [InlineData("1111222233334444", false)] // BIN نامعتبر
    [InlineData("0000000000000000", false)] // تکراری
    public void Should_Validate_Iranian_Bank_Card(string card, bool expected)
    {
        Assert.Equal(expected, card.IsIranianBankCardValid());
    }

    [Theory]
    [InlineData("6037997482395952", "603799", "BMEL", "بانک ملی ایران", "Bank Melli Iran")]
    [InlineData("6104331234567890", "610433", "BMEL", "بانک ملت", "Bank Mellat")]
    [InlineData("0000001234567890", "000000", "UNKN", "UNKN", "UNKN")]
    public void Should_Get_Iranian_Bank_Info(string card, string expectedBin, string expectedAbbr, string expectedLabel, string expectedEnglish)
    {
        var info = card.GetIranianBankInfoByCard();

        Assert.Equal(expectedBin, info.Bin);
        Assert.Equal(expectedAbbr, info.Abbreviation);
        Assert.Equal(expectedLabel, info.Label);
        Assert.Equal(expectedEnglish, info.EnglishName);
    }

    [Theory]
    [InlineData("09121234567", true)]
    [InlineData("09351234567", true)]
    [InlineData("09901234567", true)]
    [InlineData("09941234567", true)]
    [InlineData("09951456789", false)] // ناشناخته
    [InlineData("09021234567", false)] // پیشوند اشتباه
    [InlineData("0912123456", false)]  // کوتاه
    [InlineData("091212345678", false)] // بلند
    [InlineData("09a21234567", false)] // کاراکتر نامعتبر
    [InlineData("", false)]
    [InlineData(null, false)]
    public void Should_Validate_Iranian_Mobile_Number(string? number, bool expected)
    {
        Assert.Equal(expected, number.IsIranianMobileNumberValid());
    }

    [Theory]
    [InlineData("09121234567", "0912", "IR-MCI", "همراه اول")]
    [InlineData("09351234567", "0935", "IR-MTN", "ایرانسل")]
    [InlineData("09901234567", "0990", "SamanTel", "سامانتل")]
    [InlineData("09941234567", "0994", "Asiatech", "آسیاتک")]
    [InlineData("09021234567", "0902", "UNKN", "UNKN")]
    [InlineData("000", "", "UNKN", "UNKN")]
    [InlineData("", "", "UNKN", "UNKN")]
    [InlineData(null, "", "UNKN", "UNKN")]
    public void Should_Get_Iranian_Mobile_Info(string? number, string expectedPrefix, string expectedOp, string expectedLabel)
    {
        var info = number.GetIranianMobileInfo();

        Assert.Equal(expectedPrefix, info.Prefix);
        Assert.Equal(expectedOp, info.Operator);
        Assert.Equal(expectedLabel, info.Label);
    }
}
