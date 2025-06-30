# IranianValidators

A .NET library for validating common Iranian-specific inputs such as national codes, bank cards, IBANs, and mobile numbers.

## ✅ Features
- Validate Iranian national code
- More to come: bank card, mobile, IBAN, etc.

## 🛠 Usage
```csharp
using IranianValidators.Validators;

bool isValid = NationalCodeValidator.IsValid("0079058969");
