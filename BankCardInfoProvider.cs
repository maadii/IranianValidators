using IranianValidators.Models;
using System.Collections.Generic;

namespace IranianValidators.Providers;

public static class BankCardInfoProvider
{
    private static readonly Dictionary<string, string> _bins = new()
    {
        { "502229", "بانک پاسارگاد" },
        { "502806", "بانک شهر" },
        { "502908", "بانک توسعه تعاون" },
        { "502910", "بانک توسعه صادرات" },
        { "502938", "بانک دی" },
        { "504706", "بانک رسالت" },
        { "505785", "بانک ایران زمین" },
        { "589210", "بانک سپه" },
        { "603769", "بانک صادرات ایران" },
        { "603770", "بانک کشاورزی" },
        { "603799", "بانک ملی ایران" },
        { "606373", "بانک قرض‌الحسنه مهر ایران" },
        { "610433", "بانک ملت" },
        { "622106", "بانک پارسیان" },
        { "627353", "بانک تجارت" },
        { "627381", "بانک انصار" },
        { "627412", "بانک اقتصاد نوین" },
        { "627488", "بانک کارآفرین" },
        { "627648", "بانک توسعه صادرات ایران" },
        { "627760", "پست بانک ایران" },
        { "627961", "بانک صنعت و معدن" },
        { "628023", "بانک مسکن" },
        { "636214", "بانک آینده" },
        { "636795", "بانک مرکزی جمهوری اسلامی ایران" },
        { "636949", "بانک حکمت ایرانیان" },
        { "639194", "بانک پارسیان" },
        { "639346", "بانک سینا" },
        { "639370", "بانک مهر اقتصاد" },
        { "639599", "بانک قوامین" },
        { "639607", "بانک سرمایه" },
    };

    public static BankCardInfo GetInfo(string? cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length < 6)
            return new BankCardInfo();

        string bin = cardNumber.Substring(0, 6);
        string bank = _bins.TryGetValue(bin, out var name) ? name : "نامشخص";

        return new BankCardInfo
        {
            Bin = bin,
            BankName = bank
        };
    }
}
