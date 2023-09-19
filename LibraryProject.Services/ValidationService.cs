using LibraryProject.Models;
using System;
using System.Linq;

namespace LibraryProject.Services
{
    public class ValidationService
    {
        public static ValidationService Init { get; } = new ValidationService();
        public ValidationService() { }
     
        public bool ValidateStringToInt(string num) => int.TryParse(num, out int OutNum);
        public bool ValidateString(string s)
        {
            if (ValidateStringLength(s) && ValidateNoNumbers(s))
                return true;
            else
                throw new Exception($"string {s} did not pass validation");
        }
        public bool ValidateNoNumbers(string s)
        {
            if (s.Any(char.IsDigit))
                throw new Exception("Text should not include digits");
            else
                return true;
        }
        public bool ValidateStringLength(string s)
        {
            if (s.Length > 2 && s.Length < 20)
                return true;
            else
                throw new Exception("String Length not acceptable");
        }
        public bool ValidateEmail(string email)
        {
            if(ValidateString(email))
            {
                return email.Contains("@");
            }
            return false;

        }
    }
}
