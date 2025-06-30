# IranianValidators

IranianValidators is a lightweight .NET library for validating and retrieving information about Iranian-specific identifiers such as:

National ID codes

Bank card numbers (with BIN recognition)

This library is designed with clean architecture, full unit test coverage, and extensibility in mind.

✅ Features

Validate Iranian national ID codes based on the official checksum algorithm

Validate Iranian bank card numbers using the Luhn algorithm

Identify the issuing bank of a card by its BIN (first 6 digits)

Clean, readable API and extensible model structure

📦 Installation

You can clone or include the project manually:

git clone https://github.com/yourname/IranianValidators.git

(Coming soon: NuGet release)

🧪 Usage

✅ Validate national ID

using IranianValidators.Validators;

bool isValid = NationalCodeValidator.IsValid("0084575941");

✅ Validate the Iranian bank card number

using IranianValidators.Validators;

bool isValid = BankCardValidator.IsValid("6037997514561243");

✅ Get bank information from the card number

using IranianValidators.Providers;

var info = BankCardInfoProvider.GetInfo("6037997514561243");
Console.WriteLine(info.Label);        // بانک ملی ایران
Console.WriteLine(info.Abbreviation); // BMEL
Console.WriteLine(info.BankName);     // بانک ملی

🧪 Unit Tests

The library includes full test coverage using xUnit.

To run tests:

dotnet test

📁 Structure

├── src
│   └── IranianValidators
│       ├── Validators
│       │   ├── NationalCodeValidator.cs
│       │   └── BankCardValidator.cs
│       ├── Providers
│       │   └── BankCardInfoProvider.cs
│       └── Models
│           └── BankCardInfo.cs
├── tests
│   └── IranianValidators.Tests
│       └── ... (unit tests)


🧑‍💻 Author

Moein Maadi

📍 Based in Iran, open to collaborations and contributions.

📄 License

MIT License
