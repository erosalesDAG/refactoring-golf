using System.Collections.Generic;
using System.Linq;

namespace Hole5
{
    public class TakeHomeCalculator
    {
        private readonly TaxRate _taxRate;

        public TakeHomeCalculator(TaxRate taxRate)
        {
            _taxRate = taxRate;
        }

        public Money NetAmount(Money first, params Money[] rest)
        {
            List<Money> monies = rest.ToList();

            Money total = first;

            foreach (Money next in monies)
            {
                total = total.Plus(next);
            }

            Money tax = _taxRate.Apply(total);
            return total.Minus(tax);
        }
    }
}