namespace PostageCalculator
{
    public class MediumPackage
    {
        private readonly int _weight;

        public MediumPackage(int weight)
        {
            _weight = weight;
        }

        public int PostageInBaseCurrency()
        {
            return _weight * 4;
        }
    }
}