using IranianValidators.Models;

namespace IranianValidators.Providers;

internal static class BankCardInfoProvider
{
    private static readonly Dictionary<string, (string Abbrev, string Label, string FullName, string English)> _bins = new()
    {
        { "603799", ("BMEL", "بانک ملی ایران", "بانک ملی" , "Bank Melli Iran") },
        { "455379", ("BMEL", "بانک ملی ایران", "بانک ملی", "Bank Melli Iran") },
        { "440796", ("BSDR", "بانک صادرات ایران", "بانک صادرات" , "Bank Saderat Iran") },
        { "610433", ("BMEL", "بانک ملت", "بانک ملت" , "Bank Mellat") },
        { "589210", ("BSEP", "بانک سپه", "بانک سپه" , "Bank Sepah") },
        { "603769", ("BSDR", "بانک صادرات ایران", "بانک صادرات" , "Bank Saderat Iran") },
        { "636795", ("MARK", "بانک مرکزی جمهوری اسلامی ایران", "بانک مرکزی" , "Central Bank of Iran") },
        { "627961", ("SMIN", "بانک صنعت و معدن", "بانک صنعت و معدن" , "Bank of Industry and Mine") },
        { "627648", ("BTOS", "بانک توسعه صادرات ایران", "بانک توسعه صادرات" , "Export Development Bank") },
        { "589463", ("BRFW", "بانک رفاه کارگران", "بانک رفاه" , "Bank Refah") },
        { "628023", ("BMSK", "بانک مسکن", "بانک مسکن" , "Bank Maskan") },
        { "603770", ("BKSH", "بانک کشاورزی", "بانک کشاورزی" , "Bank Keshavarzi") },
        { "627353", ("BTEJ", "بانک تجارت", "بانک تجارت" , "Bank Tejarat") },
        { "585983", ("BTEJ", "بانک تجارت", "بانک تجارت" , "Bank Tejarat") },
        { "627760", ("BPST", "پست بانک ایران", "پست بانک" , "Post Bank") },
        { "502908", ("BTAO", "بانک توسعه تعاون", "بانک توسعه تعاون" , "Cooperative Development Bank") },
        { "628157", ("TDEV", "موسسه اعتباری توسعه", "مؤسسه توسعه" , "Tose'e Credit Institution") },
        { "627488", ("BKAR", "بانک کارآفرین", "بانک کارآفرین" , "Karafarin Bank") },
        { "622106", ("BPAR", "بانک پارسیان", "بانک پارسیان" , "Parsian Bank") },
        { "627412", ("BENI", "بانک اقتصاد نوین", "بانک اقتصاد نوین" , "Eghtesad Novin Bank") },
        { "621986", ("BSMN", "بانک سامان", "بانک سامان" , "Saman Bank") },
        { "502229", ("BPSG", "بانک پاسارگاد", "بانک پاسارگاد" , "Pasargad Bank") },
        { "639607", ("BSAR", "بانک سرمایه", "بانک سرمایه" , "Sarmayeh Bank") },
        { "639346", ("BSIN", "بانک سینا", "بانک سینا" , "Sina Bank") },
        { "606373", ("BMHR", "بانک قرض‌الحسنه مهر ایران", "بانک مهر ایران" , "Mehr Iran Bank") },
        { "504706", ("BSHR", "بانک شهر", "بانک شهر" , "Shahr Bank") },
        { "636214", ("BAYN", "بانک آینده", "بانک آینده" , "Ayandeh Bank") },
        { "627381", ("BANS", "بانک انصار", "بانک انصار" , "Ansar Bank") },
        { "505416", ("BTUR", "بانک گردشگری", "بانک گردشگری" , "Tourism Bank") },
        { "502938", ("BDAY", "بانک دی", "بانک دی" , "Day Bank") },
        { "505785", ("BIZM", "بانک ایران زمین", "بانک ایران زمین" , "Iran Zamin Bank") },
        { "504172", ("BRES", "بانک قرض‌الحسنه رسالت", "بانک رسالت" , "Resalat Qarz al-Hasaneh Bank") },
        { "505809", ("BMID", "بانک خاورمیانه", "بانک خاورمیانه" , "Middle East Bank") },
        { "639599", ("BGHA", "بانک قوامین", "بانک قوامین" , "Ghavamin Bank") },
        { "505801", ("BKOS", "مؤسسه کوثر", "مؤسسه کوثر" , "Kosar Credit Institution") },
        { "606256", ("BASK", "مؤسسه عسگریه", "مؤسسه عسگریه" , "Asgariyeh Credit Institution") },
        { "581874", ("BIRV", "بانک ایران‌ونزوئلا", "بانک ایران ونزوئلا" , "Iran-Venezuela Bank") },
        { "507677", ("BNOR", "مؤسسه نور", "مؤسسه نور" , "Noor Credit Institution") },
        { "636949", ("BHKM", "بانک حکمت ایرانیان", "بانک حکمت ایرانیان" , "Hekmat Iranian Bank") },
        { "504944", ("BMEQ", "بانک مهر اقتصاد", "بانک مهر اقتصاد" , "Mehr Eqtesad Bank") }
    };

    public static BankCardInfo GetInfo(string? cardNumber)
    {
        var info = new BankCardInfo();

        if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length < 6)
            return info;

        var bin = cardNumber.Trim().Substring(0, 6);
        if (_bins.TryGetValue(bin, out var data))
        {
            info.Bin = bin;
            info.Abbreviation = data.Abbrev;
            info.Label = data.Label;
            info.BankName = data.FullName;
            info.EnglishName = data.English;
        }
        else
        {
            info.Bin = bin;
        }

        return info;
    }
}
