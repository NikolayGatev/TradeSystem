namespace TradeSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class ClientsConstants
        {
            public const int MaxNumberOfDigits = 18;
            public const int FloatingPointPrecision = 2;
        }

        public static class IndividualClientConstants
        {
            public const int MaxLengthNationalIdentityNumber = 30;
            public const int MinLengthNationalIdentityNumber = 8;
        }

        public static class AddressConstants
        {
            public const int MaxLengthPostCode = 15;
            public const int MinLengthPostCode = 5;

            public const int MaxLengthDistrict = 15;
            public const int MinLengthDistrict = 5;
        }

        public static class CorporativeClientConstants
        {
            public const int MaxLengthNationalIdentityNumber = 30;
            public const int MinLengthNationalIdentityNumber = 8;

            public const int MaxLengthLegalForm = 10;
            public const int MinLengthLegalForm = 3;

            public const int MaxLengthNameOfRepresentative = 30;
            public const int MinLengthNameOfRepresentative = 10;
        }
        public static class DepositedMoneyConstants
        {
            public const int MaxNumberOfDigits = 18;
            public const int FloatingPointPrecision = 2;
        }

        public static class OrderAndTradesConstants
        {
            public const int MaxNumberOfDigits = 18;
            public const int FloatingPointPrecision = 5;
            public const string PriceMaxLegnth = "2000.00";
            public const string PriceMinLegnth = "0.01";
            public const string DepozitMax = "200000.00";

            public const int VolumeMax = 500;
            public const int VolumeMin = 1;
        }

        public static class CountryAndTownConstants
        {
            public const int MaxLengthName = 30;
            public const int MinLengthName = 3;
        }

        public static class FinancialInstrumentonstants
        {
            public const int MaxLengthName = 30;
            public const int MinLengthName = 3;

            public const int MaxLengthDescription = 250;
            public const int MinLengthDescription = 50;

            public const int VolumeMax = 50000;
            public const int VolumeMin = 1;

            public const int ISINLength = 12;

        }
    }
}
