using IranianValidators.Models;
using System.Collections.Generic;

namespace IranianValidators.Providers;

internal static class IbanBankInfoProvider
{
    private static readonly Dictionary<string, (string Abbr, string Label, string English)> _codes = new()
    {
        { "010", ("BMKR", "بانک مرکزی", "Central Bank of Iran") },
        { "011", ("SMIN", "بانک صنعت و معدن", "Bank of Industry and Mine") },
        { "012", ("BKSH", "بانک کشاورزی", "Bank Keshavarzi") },
        { "013", ("BMEL", "بانک ملت", "Bank Mellat") },
        { "014", ("BSEP", "بانک سپه", "Bank Sepah") },
        { "015", ("BSDR", "بانک صادرات ایران", "Bank Saderat Iran") },
        { "016", ("BTEJ", "بانک تجارت", "Bank Tejarat") },
        { "017", ("BMEL", "بانک ملی ایران", "Bank Melli Iran") },
        { "018", ("BMSK", "بانک مسکن", "Bank Maskan") },
        { "019", ("BPST", "پست بانک ایران", "Post Bank of Iran") },
        { "020", ("BENI", "بانک اقتصاد نوین", "Bank Eqtesad Novin") },
        { "021", ("BPAR", "بانک پارسیان", "Bank Parsian") },
        { "022", ("BPSG", "بانک پاسارگاد", "Bank Pasargad") },
        { "023", ("BSMN", "بانک سامان", "Bank Saman") },
        { "024", ("BSIN", "بانک سینا", "Bank Sina") },
        { "025", ("BRES", "بانک قرض‌الحسنه رسالت", "Resalat Qarzolhasaneh Bank") },
        { "026", ("BMHR", "بانک مهر ایران", "Mehr Iran Qarzolhasaneh Bank") },
        { "027", ("BAYN", "بانک آینده", "Bank Ayandeh") },
        { "028", ("BANS", "بانک انصار", "Bank Ansar") },
        { "029", ("BKAR", "بانک کارآفرین", "Bank Karafarin") },
        { "030", ("BTAO", "بانک توسعه تعاون", "Bank Tose’e Ta’avon") },
        { "031", ("BTOS", "بانک توسعه صادرات", "Export Development Bank of Iran") },
        { "032", ("BSHR", "بانک شهر", "Bank Shahr") },
        { "033", ("BGHA", "بانک قوامین", "Bank Ghavamin") },
        { "034", ("BTUR", "بانک گردشگری", "Tourism Bank") },
        { "035", ("BIZM", "بانک ایران زمین", "Bank Iran Zamin") },
        { "036", ("BASK", "مؤسسه اعتباری عسکریه", "Askarieh Credit Institution") },
        { "037", ("BKOS", "مؤسسه اعتباری کوثر", "Kosar Credit Institution") },
        { "038", ("BDAY", "بانک دی", "Bank Dey") },
        { "039", ("BMID", "بانک خاورمیانه", "Middle East Bank") },
        { "040", ("BSAR", "بانک سرمایه", "Bank Sarmayeh") },
        { "041", ("BIRV", "بانک ایران‌ونزوئلا", "Iran-Venezuela Bank") },
        { "042", ("BNOR", "مؤسسه اعتباری نور", "Noor Credit Institution") },
        { "053", ("BKAR", "بانک کارآفرین", "Bank Karafarin") },
        { "054", ("BPAR", "بانک پارسیان", "Bank Parsian")  },
        { "056", ("BSMN", "بانک سامان", "Bank Saman") },
        { "060", ("BMHR", "بانک مهر ایران", "Mehr Iran Qarzolhasaneh Bank") },
        { "062", ("BAYN", "بانک آینده", "Bank Ayandeh")},
        
    };

    public static BankCardInfo GetInfo(string? iban)
    {
        var info = new BankCardInfo();

        if (string.IsNullOrWhiteSpace(iban) || iban.Length < 7 || !iban.StartsWith("IR"))
            return info;

        var bankCode = iban.Substring(4, 3);

        if (_codes.TryGetValue(bankCode, out var data))
        {
            info.Abbreviation = data.Abbr;
            info.Label = data.Label;
            info.EnglishName = data.English;
        }

        return info;
    }
}
