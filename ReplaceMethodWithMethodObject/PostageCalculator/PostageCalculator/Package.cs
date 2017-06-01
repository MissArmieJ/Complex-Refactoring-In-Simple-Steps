using System;

namespace PostageCalculator
{
    public class MediumPackage
    {
        public MediumPackage(int weight)
        {
            Weight = weight;
        }

        public int Weight { get; private set; }

        public int MediumPackagePostageInBaseCurrency()
        {
            return this.Weight * 4;
        }
    }

    public class LargePackage
    {
        public LargePackage(int weight, int height, int width, int depth)
        {
            Weight = weight;
            Height = height;
            Width = width;
            Depth = depth;
        }

        public int Weight { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Depth { get; private set; }

        public decimal LargePackagePostageInBaseCurrency()
        {
            return Math.Max(this.Weight, this.Height*this.Width*this.Depth/1000m)*6;
        }
    }

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

        public decimal PostageInBaseCurrency()
        {
            if (IsSmall())
            {
                return SmallPackage.SmallPackagePostageInBaseCurrency();
            }
            if (IsMedium())
            {
                return new MediumPackage(_weight).MediumPackagePostageInBaseCurrency();
            }
            return new LargePackage(_weight, _height, _width, _depth).LargePackagePostageInBaseCurrency();
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