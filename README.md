# IranianValidators

IranianValidators is a lightweight .NET library for validating and retrieving information about Iranian-specific identifiers such as:

- National ID codes (کد ملی)
- Bank card numbers (شماره کارت بانکی) with BIN recognition
- Mobile numbers (شماره موبایل) with operator recognition
- IBAN numbers (شماره شبا) with bank recognition

This library is designed with clean architecture, full unit test coverage, and extensibility in mind.

## ✅ Features

- Validate Iranian national ID codes based on the official checksum algorithm
- Validate Iranian bank card numbers using the Luhn algorithm
- Validate Iranian mobile numbers and identify operators
- Validate Iranian IBAN numbers (IR) with checksum and bank validation
- Identify the issuing bank from card BIN (first 6 digits) or IBAN
- Support for 40+ Iranian banks and financial institutions
- Support for all Iranian mobile operators (همراه اول، ایرانسل، رایتل و...)
- Multilingual information (Persian and English)
- Clean, readable API and extensible model structure
- Full unit test coverage
- Targets .NET 7

## 📦 Installation

You can clone or include the project manually.

(Coming soon: NuGet release)

## 🔧 Requirements

- .NET 7.0 or higher
- Visual Studio 2022 or compatible IDE

## 🧪 Usage

### Validate National ID
using IranianValidators.Extensions;

bool isValid = "2143100310".IsIranianNationalCodeValid();

### Validate Iranian Bank Card Number
using IranianValidators.Extensions;

bool isValid = "6037991451234567".IsIranianBankCardValid();

### Get Bank Card Information
using IranianValidators.Extensions;

var info = "6037991451234567".GetIranianBankInfoByCard(); Console.WriteLine(info.Label);        // بانک ملی ایران 
Console.WriteLine(info.Abbreviation); // BMEL Console.WriteLine(info.BankName);     // بانک ملی 
Console.WriteLine(info.EnglishName);  // Bank Melli Iran

### Validate Mobile Number
using IranianValidators.Extensions;

bool isValid = "09121234567".IsIranianMobileNumberValid();

### Get Mobile Operator Info
using IranianValidators.Extensions;

var info = "09121234567".GetIranianMobileInfo(); Console.WriteLine(info.Operator);     // IR-MCI 
Console.WriteLine(info.Label);        // همراه اول
Console.WriteLine(info.Prefix);       // 0912

### Validate IBAN (Sheba)
using IranianValidators.Extensions;

bool isValid = "IR820150000001234567890123".IsIranianIbanValid();

### Get Bank Info from IBAN
using IranianValidators.Extensions;

var info = "IR820150000001234567890123".GetIranianBankInfoByIban(); 
Console.WriteLine(info.Label);        // بانک صادرات ایران 
Console.WriteLine(info.Abbreviation); // BSDR 
Console.WriteLine(info.EnglishName);  // Bank Saderat Iran

## 🏛️ Supported Banks
The library supports 40+ Iranian banks and financial institutions including:
- Bank Melli (بانک ملی)
- Bank Saderat (بانک صادرات)
- Bank Mellat (بانک ملت)
- Bank Sepah (بانک سپه)
- Bank Keshavarzi (بانک کشاورزی)
- Bank Maskan (بانک مسکن)
- Bank Tejarat (بانک تجارت)
- Bank Parsian (بانک پارسیان)
- Bank Pasargad (بانک پاسارگاد)
- And many more...

## 📱 Supported Mobile Operators
- Hamrah-e Aval / MCI (همراه اول) - 0910-0919
- Irancell / MTN (ایرانسل) - 0930, 0933, 0935-0939
- Rightel (رایتل) - 0920-0922
- Shatel Mobile (شاتل موبایل) - 0998
- Aptel (آپتل) - 0999
- Samantel (سامانتل) - 0990, 0991
- Asiatech (آسیاتک) - 0994

## 🧪 Testing

The library includes comprehensive test coverage using xUnit. To run tests:

## 🧑‍💻 Author
Moein Maadi

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

