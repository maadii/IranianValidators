using IranianValidators.Models;

namespace IranianValidators.Providers;

/// <summary>
/// Provides province information based on the first two digits (BIN) of Iranian postal codes.
/// Source: mobilebnk.com/blog/code-posti
/// </summary>
internal static class PostalCodeInfoProvider
{
    // Map of BIN (first two digits) to Province name
    private static readonly Dictionary<string, string> _binToProvince = new()
{
    { "11", "تهران" }, { "13", "تهران" }, { "14", "تهران" }, { "15", "تهران" }, { "16", "تهران" }, { "17", "تهران" }, { "18", "تهران" }, { "19", "تهران" },
    { "21", "تهران" },
    { "34", "قزوین" },
    { "35", "سمنان" }, { "36", "سمنان" },
    { "37", "قم" },
    { "38", "مرکزی" }, { "39", "مرکزی" },
    { "41", "گیلان" }, { "42", "گیلان" }, { "43", "گیلان" }, { "44", "گیلان" },
    { "45", "زنجان" },
    { "46", "مازندران" }, { "47", "مازندران" },
    { "48", "گلستان" }, { "49", "گلستان" },
    { "51", "آذربایجان شرقی" }, { "52", "آذربایجان شرقی" }, { "53", "آذربایجان شرقی" }, { "54", "آذربایجان شرقی" }, { "55", "آذربایجان شرقی" },
    { "56", "اردبیل" },
    { "57", "آذربایجان غربی" }, { "58", "آذربایجان غربی" }, { "59", "آذربایجان غربی" },
    { "61", "همدان" }, { "62", "همدان" },
    { "63", "خوزستان" }, { "64", "خوزستان" }, { "65", "خوزستان" },
    { "66", "کردستان" }, { "67", "کرمانشاه" },
    { "68", "لرستان" },
    { "69", "ایلام" },
    { "71", "فارس" }, { "72", "فارس" }, { "73", "فارس" }, { "74", "فارس" },
    { "75", "بوشهر" },
    { "76", "کرمان" }, { "77", "کرمان" }, { "78", "کرمان" },
    { "79", "هرمزگان" }, 
    { "81", "اصفهان" }, { "83", "اصفهان" }, { "84", "اصفهان" },
    { "85", "یزد" }, { "86", "یزد" }, { "87", "یزد" }, { "88", "یزد" }, { "89", "یزد" },
    { "91", "خراسان رضوی" }, { "92", "خراسان رضوی" }, { "93", "خراسان رضوی" }, { "95", "خراسان رضوی" }, { "96", "خراسان رضوی" },
    { "94", "خراسان شمالی" },
    { "97", "خراسان جنوبی" },
    { "98", "سیستان و بلوچستان" }, { "99", "سیستان و بلوچستان" }
    };

    public static PostalCodeInfo GetInfo(string? postalCode)
    {
        var info = new PostalCodeInfo();

        if (string.IsNullOrWhiteSpace(postalCode) || postalCode.Length <= 2)
            return info;

        var bin = postalCode.Substring(0, 2);
        info.Bin = bin;

        if (_binToProvince.TryGetValue(bin, out var province))
        {
            info.Province = province;
        }
        else
        {
            info.Province = "UNKN";
        }

        return info;
    }
}
