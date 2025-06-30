using System.Linq;

namespace IranianValidators.Validators;

public static class BankCardValidator
{
	public static bool IsValid(string? cardNumber)
	{
		if (string.IsNullOrWhiteSpace(cardNumber))
			return false;

		cardNumber = cardNumber.Trim();

		if (cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
			return false;

		if (cardNumber.Distinct().Count() == 1)
			return false;

		// Luhn
		int sum = 0;
		for (int i = 0; i < 16; i++)
		{
			int digit = cardNumber[i] - '0';
			if (i % 2 == 0)
			{
				digit *= 2;
				if (digit > 9) digit -= 9;
			}
			sum += digit;
		}

		return sum % 10 == 0;
	}
}