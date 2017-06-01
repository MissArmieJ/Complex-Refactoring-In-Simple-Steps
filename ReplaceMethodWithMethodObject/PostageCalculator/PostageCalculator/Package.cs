namespace PostageCalculator
{
    public class Package
    {
        private readonly int _weight;
        private readonly int _height;
        private readonly int _width;
        private readonly int _depth;
        private SizedPackage _sizedPackage;

        public Package(int weight, int height, int width, int depth)
        {
            _weight = weight;
            _height = height;
            _width = width;
            _depth = depth;
            _sizedPackage = CreateSizedPackage();
        }

        public decimal PostageInBaseCurrency()
        {
            return _sizedPackage.PostageInBaseCurrency();
        }

        private SizedPackage CreateSizedPackage()
        {
            if (IsSmall())
            {
                return new SmallPackage();
            }
            if (IsMedium())
            {
                return new MediumPackage(_weight);
            }
            return new LargePackage(_weight, _height, _width, _depth);
        }

        private bool IsMedium()
        {
            return _weight <= 500 && _height <= 324 && _width <= 229 && _depth <= 100;
        }

        private bool IsSmall()
        {
            return _weight <= 60 && _height <= 229 && _width <= 162 && _depth <= 25;
        }
    }
}