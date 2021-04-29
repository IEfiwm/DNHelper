namespace Helpers
{
    public class CommonExpression
    {
        public const string Numeric = @"\d+";

        public const string EnglishAlphabet = @"([a-zA-Z]+)";

        public const string EnglishAlphabetWithSpace = @"([ a-zA-Z]*)";

        public const string PersianAlphabetWithSpace = @"([ آا-ی]*)";

        public const string PersianAlphanumeric = @"([\u0627-\u064A\uFB8A\u067E\u0686\u06AF\u0698\u06A9\u06AF\u06CC\u06F0-\u06F9\s-]+)";

        public const string EnglishAndPersianAlphanumeric = @"([a-zA-Z0-9\u0627-\u064A\uFB8A\u067E\u0686\u06AF\u0698\u06A9\u06AF\u06CC\u06F0-\u06F9\s-]+)";

        public const string EnglishAndPersianAlphanumericWithoutSpace = @"([a-zA-Z0-9\u0622\u0627-\u064A\uFB8A\u067E\u0686\u06AF\u0698\u06A9\u06AF\u06CC\u06F0-\u06F9\-]+)";

        public const string NotEnglishAndPersianAlphanumericWithoutSpace = @"([^a-zA-Z0-9\u0622\u0627-\u064A\uFB8A\u067E\u0686\u06AF\u0698\u06A9\u06AF\u06CC\u06F0-\u06F9\-]+)";

        public const string PasswordStrength = @"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})";

        public const string PersianDate = @"((?<!\d+)([1-9][0-9][0-9][0-9](?!\d+)))/([1-9]|[0][1-9]|[1][0-2])/([1-9]|[1-2][0-9]|[0][1-9]|[3][0-1])";

        public const string Year = @"\d{4}";

        public const string Month = @"(([1-9])|(0\d)|(1[012]))";

        public const string Day = @"(([1-9])|([012]\d)|3[01])";

        public const string Culture = @"[a-zA-Z]{2}";

        public const string PassportNumber = @"^[A-PR-WYa-pr-wy][1-9]\d\s?\d{4}[1-9]$";

        public const string ImageResize = @"^.+(-\d{2,4})x(\d{2,4})\.{0}$";

        public const string IranianMobile = @"^09(0[1-3]|1[0-9]|3[0-9]|2[0-2]|9[0-3])-?[0-9]{3}-?[0-9]{4}$";

        public const string IranianMobileByPersianNumber = @"([0۰][9۹])[0-9۰-۹]{9}";

        public const string IranianTelephone = @"0[0-9]{6,10}$";

        public const string ShebaNumber = "^(?:IR)(?=.{24}$)[0-9]*$";

        public const string IranianTelephoneByPersianNumber = @"^[0|۰][0-9۰-۹]{2}[\-]{0,1}[\s]{0,1}[1-9۱-۹]{1}([0-9۰-۹]{3,7})$";

        public const string EnglishAndPersianAlphabet = @"([a-zA-Z\u0627-\u064A\uFB8A\u067E\u0686\u06AF\u0698\u06A9\u06AF\u06CC\s-]+)";

        public const string Email = "^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$";

        public const string WebSiteUrl = @"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

        public const string WebSiteUrlNotRequiredHttp = @"(https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,})";

        public const string ContractProjectAssemblyNamePattern = @"^(Ngra)\.(.+)\.Contract\z";

        public const string UrlIdSlug = @"^([\d]+(-[\S]+)+)$";

        public const string UrlReviewIdSlug = @"^([\d]+(-[\w]+){2,})$";

        public const string NotContainesSearchWord = @"^((?!search).)*$";

        public const string AirPort = @"([a-zA-Z]{3})|([a-zA-Z]{3})(?i)all";
    }
}
