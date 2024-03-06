﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public const int MaxLengthName = 30;
            public const int MinLengthName = 3;

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

        public static class  CorporativeClientConstants
        {
            public const int MaxLengthName = 30;
            public const int MinLengthName = 3;

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

        public static class OrderConstants
        {
            public const int MaxNumberOfDigits = 18;
            public const int FloatingPointPrecision = 5;
        }
    }
}
