namespace TradeSystem.Common
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required";

        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

        public const string PhoneExists = "Phone number already exists. Enter another one";

        public const string HasBeAdult = "You must be adult";

        public const string PriceValue = "Price must be a positive number and less than {2} leva";

        public const string FileLength = "File size must be more 0 bytes and less {0}";

        public static string ZeroBalance = "Your balace is 0 BGN, to submit an order you must fund your account!";

        public static string DoNotEnoughMoney = "You do not enough momey for this order!";

        public static string DoNotEnoughFinancialInstruments = "You do not enough count from this financial instrument for all your sell oreders!";
    }
}
