using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities.BusinessLogic;
using System;
using System.Linq;
using System.Security.RightsManagement;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace Librarius_DL.Validators
{
    public static class Validator
    {

        public static string ValidateString(string text)
        {
            if (string.IsNullOrEmpty(text)) return "Wartość nie może być pusta.";
            if (!char.IsUpper(text, 0)) return "Rozpocznij dużą literą.";
            if (text.Length < 3) return "Tekst powinien zawierać minimum 3 znaki.";
            if (text.Length >= 50) return "Tekst nie może przekraczać 50 znaków.";
            return string.Empty;

        }

        public static string ValidatePhoneNumber(string text) 
        {
            if (string.IsNullOrEmpty(text)) return "Wartość nie może być pusta.";
            if (text.Length != 9) return "Niepoprawna długość numeru telefonu.";
            if (!Regex.IsMatch(text, @"^\+?[0-9\s\-\(\)]*$")) return "Numer telefonu zawiera niedozwolone znaki.";
            if (DataBaseClass.Instance.Members.Any(member => member.ContactInfo == text)) return "Numer telefonu jest już bazie.";
            
            return string.Empty;
        }

        public static string ValidateISBN(string text)
        {
            if (string.IsNullOrEmpty(text)) return "Wartość nie może być pusta.";
            if (text.Length < 3) return "Tekst powinien zawierać minimum 3 znaki.";
            if (!Regex.IsMatch(text, @"^[a-zA-Z0-9]*$"))return "Tekst może zawierać tylko litery i cyfry.";
            if (DataBaseClass.Instance.Books.Any(member => member.ISBN == text)) return "ISBN musi być unikalny.";

            return string.Empty;
        }

        public static string ValidateYear(string text)
        {
            if (string.IsNullOrEmpty(text)) return "Wartość nie może być pusta.";
            if (text.Length != 4) return "Tekst powinien zawierać 4 znaki.";
            if (!Regex.IsMatch(text, @"^\+?[0-9\s\-\(\)]*$")) return "Rok zawiera niedozwolone znaki.";
            return string.Empty;
        }
    }
}
