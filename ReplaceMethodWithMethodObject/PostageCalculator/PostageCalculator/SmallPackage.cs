namespace PostageCalculator
{
    public class SmallPackage : SizedPackage
    {
        public decimal PostageInBaseCurrency()
        {
            return 120m;
        }
    }
}