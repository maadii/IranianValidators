# IranianValidators

IranianValidators is a lightweight .NET library for validating and retrieving information about Iranian-specific identifiers such as:

- National ID codes (کد ملی)
- Bank card numbers (شماره کارت بانکی) with BIN recognition
- Mobile numbers (شماره موبایل) with operator recognition

This library is designed with clean architecture, full unit test coverage, and extensibility in mind.

## ✅ Features

- Validate Iranian national ID codes based on the official checksum algorithm
- Validate Iranian bank card numbers using the Luhn algorithm
- Validate Iranian mobile numbers and identify operators
- Identify the issuing bank of a card by its BIN (first 6 digits)
- Support for 15+ major Iranian banks
- Support for all Iranian mobile operators (همراه اول، ایرانسل، رایتل و...)
- Multilingual information (Persian and English)
- Clean, readable API and extensible model structure
- Full unit test coverage
- Targets .NET 7

## 📦 Installation

You can clone or include the project manually:

git clone https://github.com/yourname/IranianValidators.git

(Coming soon: NuGet release)

## 🔧 Requirements

- .NET 7.0 or higher
- Visual Studio 2022 or compatible IDE

## 🧪 Usage

### Validate National ID

using IranianValidators.Validators;

bool isValid = NationalCodeValidator.IsValid("0084575941");

### Validate Iranian Bank Card Number

using IranianValidators.Validators;

bool isValid = BankCardValidator.IsValid("6037997514561243");

### Get Bank Information from Card Number

using IranianValidators.Providers;

var info = BankCardInfoProvider.GetInfo("6037997514561243");
Console.WriteLine(info.Label);        // بانک ملی ایران
Console.WriteLine(info.Abbreviation); // BMEL
Console.WriteLine(info.BankName);     // بانک ملی

### Validate Mobile Number

### Supported Banks

The library supports major Iranian banks including:
- Bank Melli (بانک ملی)
- Bank Saderat (بانک صادرات)
- Bank Mellat (بانک ملت)
- Bank Sepah (بانک سپه)
- Bank Keshavarzi (بانک کشاورزی)
- And many more...

### Supported Mobile Operators
- Hamrah-e Aval / MCI (همراه اول)
- Irancell / MTN (ایرانسل)
- Rightel (رایتل)
- Shatel Mobile (شاتل موبایل)
- Aptel (آپتل)
- Samantel (سامانتل)
- Asiatech (آسیاتک)

## 🧪 Testing

The library includes comprehensive test coverage using xUnit. To run tests:

dotnet test

## 🧑‍💻 Author
Moein Maadi

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

