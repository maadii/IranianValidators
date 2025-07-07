# IranianValidators

IranianValidators is a lightweight .NET library for validating and retrieving information about Iranian-specific identifiers such as:

- National ID codes (کد ملی)
- Bank card numbers (شماره کارت بانکی) with BIN recognition
- Mobile numbers (شماره موبایل) with operator recognition
- IBAN numbers (شماره شبا) with bank recognition
- Postal codes (کد پستی) with province recognition

This library is designed with clean architecture, full unit test coverage, and extensibility in mind.

## ✅ Features

- Validate Iranian national ID codes based on the official checksum algorithm
- Validate Iranian bank card numbers using the Luhn algorithm
- Validate Iranian mobile numbers and identify operators
- Validate Iranian IBAN numbers (IR) with checksum and bank validation
- Identify province from postal codes
- Identify the issuing bank from card BIN (first 6 digits) or IBAN
- Support for 40+ Iranian banks and financial institutions
- Support for all Iranian mobile operators (همراه اول، ایرانسل، رایتل و...)
- Support for all Iranian provinces (استان‌ها)
- Multilingual information (Persian and English)
- Clean, readable API and extensible model structure
- Full unit test coverage
- Targets .NET 7

## 📦 Installation
git clone https://github.com/yourname/IranianValidators.git

You can clone or include the project manually.

(Coming soon: NuGet release)

## 🔧 Requirements

- .NET 7.0 or higher
- Visual Studio 2022 or compatible IDE

## 🧪 Usage Examples

All validators support both extension methods and direct usage:

### National ID
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

### Postal Code
using IranianValidators.Extensions;
 
Info var info = "1234567890".GetIranianPostalCodeInfo(); // Get Province
Console.WriteLine(info.Province);     // تهران 
Console.WriteLine(info.Bin);         // 12


## 🏛️ Supported Data

### Banks (40+ institutions)
- Bank Melli (بانک ملی)
- Bank Saderat (بانک صادرات)
- Bank Mellat (بانک ملت)
- Bank Sepah (بانک سپه)
- Bank Maskan (بانک مسکن)
- Bank Tejarat (بانک تجارت)
- And 35+ more...

### Mobile Operators
- Hamrah-e Aval / MCI (همراه اول) - 0910-0919
- Irancell / MTN (ایرانسل) - 0930, 0933, 0935-0939
- Rightel (رایتل) - 0920-0922
- Shatel Mobile (شاتل موبایل) - 0998
- Aptel (آپتل) - 0999
- Samantel (سامانتل) - 0990, 0991
- Asiatech (آسیاتک) - 0994

### Provinces
Full support for all 31 Iranian provinces (استان‌ها) via postal code lookup.

## 🧪 Testing

Run the comprehensive test suite:

## 📄 License

MIT License - see LICENSE file for details.

## 🧑‍💻 Author
Moein Maadi

