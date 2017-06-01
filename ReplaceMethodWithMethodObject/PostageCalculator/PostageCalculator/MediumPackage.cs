namespace PostageCalculator
{
    public class MediumPackage : SizedPackage
    {
        private readonly int _weight;

        public MediumPackage(int weight)
        {
            _weight = weight;
        }

        public decimal PostageInBaseCurrency()
        {
            return _weight * 4;
        }
    }
}