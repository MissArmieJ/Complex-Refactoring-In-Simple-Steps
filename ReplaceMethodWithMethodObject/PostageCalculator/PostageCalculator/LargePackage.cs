using System;

namespace PostageCalculator
{
    public class LargePackage
    {
        private readonly int _weight;
        private readonly int _height;
        private readonly int _width;
        private readonly int _depth;

        public LargePackage(int weight, int height, int width, int depth)
        {
            _weight = weight;
            _height = height;
            _width = width;
            _depth = depth;
        }

        public decimal PostageInBaseCurrency()
        {
            return Math.Max(_weight, _height*_width*_depth/1000m)*6;
        }
    }
}