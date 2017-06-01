using System;

namespace PostageCalculator
{
    public class Calculator
    {
        public Money Calculate(int weight, int height, int width, int depth, Currency currency)
        {
            var postageInBaseCurrency = new Package(weight, height, width, depth).PostageInBaseCurrency();
            return ConvertCurrency(postageInBaseCurrency, currency);
        }

        private Money ConvertCurrency(decimal amountInBaseCurrency, Currency currency)
        {
            if (currency == Currency.Gbp)
                return new Money(Currency.Gbp, amountInBaseCurrency);
            if(currency == Currency.Eur)
                return new Money(Currency.Eur, (amountInBaseCurrency + 200) * 1.25m);
            if(currency == Currency.Chf)
                return new Money(Currency.Chf, (amountInBaseCurrency + 200) * 1.36m);
            throw new Exception("Currency not supported");
        }
    }
}
