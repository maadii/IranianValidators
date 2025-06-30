namespace IranianValidators.Models;

public class BankCardInfo
{
    /// <summary>
    /// The first 6 digits of the card number (Bank Identification Number - BIN)
    /// </summary>
    public string Bin { get; set; } = string.Empty;

    /// <summary>
    /// Abbreviation used for the issuing bank (e.g., BMEL for Bank Mellat)
    /// </summary>
    public string Abbreviation { get; set; } = "UNKN";

    /// <summary>
    /// Friendly Persian label for displaying in UI (e.g., بانک ملت)
    /// </summary>
    public string Label { get; set; } = "UNKN";

    /// <summary>
    /// Full official name of the bank (e.g., بانک ملت ایران)
    /// </summary>
    public string BankName { get; set; } = "UNKN";

    /// <summary>
    /// Optional English name of the bank for multilingual support
    /// </summary>
    public string EnglishName { get; set; } = "UNKN";
}
