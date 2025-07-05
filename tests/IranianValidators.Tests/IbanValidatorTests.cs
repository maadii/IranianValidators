using IranianValidators.Extensions;
using Xunit;

namespace IranianValidators.Tests;

public class IbanValidatorTests
{
    [Theory]

    [InlineData("IR820540102680020817909002", true)]  // بانک ملت
    [InlineData("IR062090000000100324200001", true)]  // بانک صادرات
    [InlineData("IR200170000000208563028006", true)]  // بانک ملی
    [InlineData("IR999990000000000000000000", false)]

    [InlineData("IR820540102680020817909099", false)]

    [InlineData("IR123456789012345678901234", false)]
    [InlineData("IR000000000000000000000000", false)]

    [InlineData("IR82@540102680020817909002", false)] // کاراکتر نامعتبر
    [InlineData("IR82054010268002081790900", false)]  // کوتاه‌تر از 26
    [InlineData("IR820540102680020817909002XX", false)] // بلندتر از 26
    [InlineData("XX820540102680020817909002", false)]  // شروع نادرست
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData(" ", false)]
    public void Should_Validate_Iranian_Iban_Correctly(string? iban, bool expected)
    {
        Assert.Equal(expected, iban.IsIranianIbanValid());
    }
}
