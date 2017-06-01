namespace PostageCalculator
{
    public class MediumPackage : Package
    {
        private readonly int _weight;

        public MediumPackage(int weight)
        {
            _weight = weight;
        }

        public override decimal PostageInBaseCurrency()
        {
            return _weight * 4;
        }
    }
}