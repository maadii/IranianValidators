namespace IranianValidators.Models;

public class MobileInfo
{
    public string Prefix { get; set; } = string.Empty;

    public string Operator { get; set; } = "UNKN"; // e.g., IR-MCI
    public string Label { get; set; } = "UNKN";    // e.g., همراه اول
}