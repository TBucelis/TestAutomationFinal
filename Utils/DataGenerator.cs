using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationFinal.Utils
{
    public class DataGenerator
    {

        public static string GenerateRandomString(int stringLenght)
        {
        var chars = "abcdefghijklmnopqrstuvwxyz";
        var stringChars = new char[stringLenght];
        var random = new Random();

            for (int i = 0; i<stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);

        return finalString;
        }

        public static string NameCapitalize(string name)
        {
            string capitalizedName = (char.ToUpper(name[0]) + name.Substring(1));
            return capitalizedName;
        }
    }
}
