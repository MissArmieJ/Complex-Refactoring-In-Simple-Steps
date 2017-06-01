using System;

namespace PostageCalculator
{
    public class Package
    {
        private readonly int _weight;
        private readonly int _height;
        private readonly int _width;
        private readonly int _depth;

        public Package(int weight, int height, int width, int depth)
        {
            _weight = weight;
            _height = height;
            _width = width;
            _depth = depth;
        }

        public int GetWeight() => _weight;
        public int GetHeight() => _height;
        public int GetWidth() => _width;
        public int GetDepth() => _depth;
    }

    public class Calculator
    {
        public Money Calculate(int weight, int height, int width, int depth, Currency currency)
        {
            var postageInBaseCurrency = PostageInBaseCurrency(new Package(weight, height, width, depth));
            return ConvertCurrency(postageInBaseCurrency, currency);
        }

        private decimal PostageInBaseCurrency(Package package)
        {
            if (package.GetWeight() <= 60 && package.GetHeight() <= 229 && package.GetWidth() <= 162 && package.GetDepth() <= 25)
            {
                return 120m;
            }
            if (package.GetWeight() <= 500 && package.GetHeight() <= 324 && package.GetWidth() <= 229 && package.GetDepth() <= 100)
            {
                return package.GetWeight()*4;
            }
            return Math.Max(package.GetWeight(), package.GetHeight()*package.GetWidth()*package.GetDepth()/1000m)*6;
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
