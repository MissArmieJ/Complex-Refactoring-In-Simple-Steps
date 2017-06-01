namespace PostageCalculator
{
    public abstract class Package
    {
        public abstract decimal PostageInBaseCurrency();

        public static Package WithDimensions(int weight, int height, int width, int depth)
        {
            if (IsSmall(depth, width, height, weight))
            {
                return new SmallPackage();
            }
            if (IsMedium(depth, width, height, weight))
            {
                return new MediumPackage(weight);
            }
            return new LargePackage(weight, height, width, depth);
        }

        private static bool IsMedium(int depth, int width, int height, int weight)
        {
            return weight <= 500 && height <= 324 && width <= 229 && depth <= 100;
        }

        private static bool IsSmall(int depth, int width, int height, int weight)
        {
            return weight <= 60 && height <= 229 && width <= 162 && depth <= 25;
        }
    }
}