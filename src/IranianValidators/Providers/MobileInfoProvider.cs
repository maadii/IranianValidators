using IranianValidators.Models;
using System.Collections.Generic;

namespace IranianValidators.Providers;

internal static class MobileInfoProvider
{
    private static readonly Dictionary<string, (string Label, string Operator)> _prefixes = new()
    {
        //IR- MCI
        { "0910", ("همراه اول", "IR-MCI") },
        { "0911", ("همراه اول", "IR-MCI") },
        { "0912", ("همراه اول", "IR-MCI") },
        { "0913", ("همراه اول", "IR-MCI") },
        { "0914", ("همراه اول", "IR-MCI") },
        { "0915", ("همراه اول", "IR-MCI") },
        { "0916", ("همراه اول", "IR-MCI") },
        { "0917", ("همراه اول", "IR-MCI") },
        { "0918", ("همراه اول", "IR-MCI") },
        { "0919", ("همراه اول", "IR-MCI") },

        // irancell - MTN
        { "0930", ("ایرانسل", "IR-MTN") },
        { "0933", ("ایرانسل", "IR-MTN") },
        { "0935", ("ایرانسل", "IR-MTN") },
        { "0936", ("ایرانسل", "IR-MTN") },
        { "0937", ("ایرانسل", "IR-MTN") },
        { "0938", ("ایرانسل", "IR-MTN") },
        { "0939", ("ایرانسل", "IR-MTN") },

        // رایتل
        { "0920", ("رایتل", "Rightel") },
        { "0921", ("رایتل", "Rightel") },
        { "0922", ("رایتل", "Rightel") },

        // شاتل موبایل
        { "0998", ("شاتل موبایل", "ShatelMobile") },

        // آپتل
        { "0999", ("آپتل", "Aptel") },

        // سامانتل
        { "0990", ("سامانتل", "SamanTel") },
        { "0991", ("سامانتل", "SamanTel") },

        // آسیاتک
        { "0994", ("آسیاتک", "Asiatech") }
    };

    public static MobileInfo GetInfo(string? mobileNumber)
    {
        var info = new MobileInfo();

        mobileNumber = mobileNumber?.Trim();

        if (string.IsNullOrEmpty(mobileNumber) || mobileNumber.Length < 4)
            return info; // Prefix remains "", Operator & Label = "UNKN"

        var prefix = mobileNumber.Substring(0, 4);

        if (_prefixes.TryGetValue(prefix, out var data))
        {
            info.Prefix = prefix;
            info.Label = data.Label;
            info.Operator = data.Operator;
        }
        else
        {
            info.Prefix = prefix;
        }

        return info;
    }
}
