using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Helpers.Extensions
{
    public static class StringExtensions
    {
        #region Private Const
        private const char YehArabic = 'ي';
        private const char YehPersian = 'ی';
        private const char KafArabic = 'ك';
        private const char KafPersian = 'ک';
        #endregion

        public static string GenerateUniqueString()
        {
            long ticks = DateTime.Now.Ticks;

            byte[] bytes = BitConverter.GetBytes(ticks);

            string unique = System.Convert.ToBase64String(bytes)
                .Replace('+', '_')
                .Replace('/', '-')
                .TrimEnd('=');

            return unique;
        }

        #region Extensions
        public static string CleanEmailAddress(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return string.Empty;
            }

            email = email.ToLowerInvariant().Trim();

            var emailParts = email.Split('@');

            var name = emailParts[0].Replace(".", string.Empty).Replace("+", string.Empty);

            var emailDomain = emailParts[1];

            string[] domainsAllowedDots =
            {
                "gmail.com",
                "facebook.com"
            };

            var isFromDomainsAllowedDots = domainsAllowedDots.Any(domain => emailDomain.Equals(domain));

            return !isFromDomainsAllowedDots ? email : $"{name}@{emailDomain}";
        }

        public static string CleanNoneLatinCharacter(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);

            var chars = new[] { 1619, 1620 };

            var exceptionChars = chars.Select(x => (char)x).ToList();

            var stringBuilder = new StringBuilder();

            foreach (var character in normalizedString)
            {
                if (exceptionChars.Contains(character))
                {
                    stringBuilder.Append(character);

                    continue;
                }

                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(character);

                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(character);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static bool IsEnglishContent(this string input)
        {
            var regex = new Regex("^[A-Za-z ]+$");

            return regex.IsMatch(input);
        }

        public static bool IsNonEnglishWord(this string word)
        {
            return Regex.IsMatch(word, @"[^\x00-\x7F]+");
        }

        public static bool IsIranianLegalIdValid(this string id)
        {
            //input has 11 digits that all of them are not equal
            if (!Regex.IsMatch(id, @"^(?!(\d)\1{10})\d{11}$"))
                return false;

            var check = System.Convert.ToInt32(id.Substring(10, 1));

            int dec = System.Convert.ToInt32(id.Substring(9, 1)) + 2;

            int[] Coef = new int[10] { 29, 27, 23, 19, 17, 29, 27, 23, 19, 17 };

            var sum = Enumerable.Range(0, 10)
                .Select(x => (System.Convert.ToInt32(id.Substring(x, 1)) + dec) * Coef[x])
                .Sum() % 11;

            sum = sum == 10 ? 0 : sum; // by 10101149480


            return sum == check;
        }

        public static bool IsIranianNationalIdValid(this string id)
        {
            if (id?.Length != 10)
                return false;

            id = id.PadLeft(10, '0');

            if (!Regex.IsMatch(id, @"^\d{10}$"))
                return false;

            var check = System.Convert.ToInt32(id.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => System.Convert.ToInt32(id.Substring(x, 1)) * (10 - x))
                .Sum() % 11;

            return sum < 2 && check == sum || sum >= 2 && check + sum == 11;
        }

        public static bool IsIranianMobileValid(this string mobile)
        {
            return !string.IsNullOrWhiteSpace(mobile) && Regex.IsMatch(mobile, CommonExpression.IranianMobile);
        }

        public static bool IsIranianTelephoneValid(this string telephone)
        {
            return !string.IsNullOrWhiteSpace(telephone) &&
                   Regex.IsMatch(telephone, CommonExpression.IranianTelephone);
        }

        public static bool IsShebaNumberValid(this string number)
        {
            return !string.IsNullOrWhiteSpace(number) && Regex.IsMatch(number, CommonExpression.ShebaNumber);
        }

        public static bool IsPersianText(this string text)
        {
            return Regex.IsMatch(text, CommonExpression.PersianAlphanumeric);
        }

        public static bool IsLatinText(this string text)
        {
            return Regex.IsMatch(text, CommonExpression.EnglishAlphabet);
        }

        public static bool IsPasswordStrength(this string password)
        {
            return Regex.IsMatch(password, CommonExpression.PasswordStrength);
        }

        public static bool IsPersianDateValid(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            //  Make sure all numbers are english
            string englishNumbers = value.ToEnglishNumber();

            return Regex.IsMatch(englishNumbers, CommonExpression.PersianDate);
        }

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            email = email.Trim();

            var result = Regex.IsMatch(email, CommonExpression.Email, RegexOptions.IgnoreCase);

            return result;
        }

        public static string ToGenerateSlug(this string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return string.Empty;
            }

            var slug = title;

            slug = Regex.Replace(slug,
                @"[^A-Za-z0-9\u0627-\u0648\uFB8A\u067E\u0686\u06AF\u0698\u06A9\u06AF\u06CC\u06F0-\u06F9\s-]", "");

            slug = Regex.Replace(slug, @"[\s-]+", " ").Trim();

            slug = slug.Substring(0, slug.Length).Trim();

            slug = Regex.Replace(slug, @"\s", "-");

            return slug.ToLower();
        }

        public static int ToInt(this string value)
        {
            return System.Convert.ToInt32(value);
        }

        public static short ToShort(this string value)
        {
            return System.Convert.ToInt16(value);
        }

        public static long ToLong(this string value)
        {
            return System.Convert.ToInt32(value);
        }

        public static string ToEnglishNumber(this string input)
        {
            string[] persianNumbers = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int index = 0; index < persianNumbers.Length; index++)
            {
                input = input.Replace(persianNumbers[index], index.ToString());
            }

            return input;
        }

        public static string ToPersianKeAndYe(this string input)
        {
            return input?.Replace(KafArabic, KafPersian).Replace(YehArabic, YehPersian);
        }

        public static string ToPersianNumber(this string input)
        {
            string[] persianNumbers = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int index = 0; index < persianNumbers.Length; index++)
            {
                input = input.Replace(index.ToString(), persianNumbers[index]);
            }

            return input;
        }

        public static string ToPersianNumber(this int input)
        {
            return input.ToString().ToPersianNumber();
        }

        public static string ToSafeUrl(this string url)
        {
            return Uri.EscapeDataString(url);
        }
        #endregion
    }
}
