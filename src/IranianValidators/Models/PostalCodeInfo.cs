namespace IranianValidators.Models;

/// <summary>
/// Represents parsed information from an Iranian postal code.
/// </summary>
public class PostalCodeInfo
{
    /// <summary>First two digits (BIN) of the postal code.</summary>
    public string Bin { get; set; } = string.Empty;

    /// <summary>Province name if found, otherwise "UNKN".</summary>
    public string Province { get; set; } = "UNKN";
}
