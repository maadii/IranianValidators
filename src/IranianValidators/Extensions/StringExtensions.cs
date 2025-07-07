using IranianValidators.Validators;
using IranianValidators.Providers;
using IranianValidators.Models;

namespace IranianValidators.Extensions;

/// <summary>
/// Provides fluent-style extension methods for validating and extracting
/// information from Iranian-specific identifiers such as national codes and bank card numbers.
/// </summary>
public static class IranianStringExtensions
{
    /// <summary>
    /// Checks whether the string is a valid Iranian national code.
    /// </summary>
    public static bool IsIranianNationalCodeValid(this string? input)
    {
        return NationalCodeValidator.IsValid(input);
    }

    /// <summary>
    /// Checks whether the string is a valid Iranian bank card number.
    /// </summary>
    public static bool IsIranianBankCardValid(this string? input)
    {
        return BankCardValidator.IsValid(input);
    }

    /// <summary>
    /// Retrieves bank information (label, abbreviation, etc.) from the card number.
    /// </summary>
    public static BankCardInfo GetIranianBankInfoByCard(this string? cardNumber)
    {
        return BankCardInfoProvider.GetInfo(cardNumber);
    }
    /// <summary>
    /// Checks whether the string is a valid Iranian Mobile number.
    /// </summary>
    public static bool IsIranianMobileNumberValid(this string? input)
    {
        return IranianMobileValidator.IsValid(input);
    }
    /// <summary>
    /// Retrieves Mobile information (label, abbreviation, etc.) from the card number.
    /// </summary>
    public static MobileInfo GetIranianMobileInfo(this string? mobileNumber)
    {
        return MobileInfoProvider.GetInfo(mobileNumber);
    }
    /// <summary>  
    /// Checks whether the string is a valid Iranian iban.
    /// </summary>
    public static bool IsIranianIbanValid(this string? input)
    {
        return IbanValidator.IsValid(input);
    }
    /// <summary>
    /// Retrieves iban information (label, banck, etc.) from the iban number.
    /// </summary>
    public static BankCardInfo GetIranianBankInfoByIban(this string? iban)
    {
        return IbanBankInfoProvider.GetInfo(iban);
    }
    /// <summary>
    /// Checks whether the string is a valid Iranian postal code.
    /// </summary>
    public static bool IsIranianPostalCodeValid(this string? input)
    {
        return IranianPostalCodeValidator.IsValid(input);
    }

    /// <summary>
    /// Retrieves postal region info (BIN and province) from the postal code.
    /// </summary>
    public static PostalCodeInfo GetIranianPostalCodeInfo(this string? input)
    {
        return PostalCodeInfoProvider.GetInfo(input);
    }
}
