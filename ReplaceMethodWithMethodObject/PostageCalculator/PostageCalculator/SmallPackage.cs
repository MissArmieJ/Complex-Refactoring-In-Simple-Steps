namespace PostageCalculator
{
    public class SmallPackage : Package
    {
        public override decimal PostageInBaseCurrency()
        {
            return 120m;
        }
    }
}