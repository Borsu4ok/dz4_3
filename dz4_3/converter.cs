using System;

namespace CurrencyConverter
{
    public class Converter
    {
        private readonly decimal usdRate;
        private readonly decimal eurRate;

        public Converter(decimal usd, decimal eur)
        {
            if (usd <= 0 || eur <= 0)
            {
                throw new ArgumentException("Rates must be positive numbers.");
            }
            usdRate = usd;
            eurRate = eur;
        }

        public decimal UahToUsd(decimal uahAmount)
        {
            return uahAmount / usdRate;
        }

        public decimal UahToEur(decimal uahAmount)
        {
            return uahAmount / eurRate;
        }

        public decimal UsdToUah(decimal usdAmount)
        {
            return usdAmount * usdRate;
        }

        public decimal EurToUah(decimal eurAmount)
        {
            return eurAmount * eurRate;
        }
    }
}

