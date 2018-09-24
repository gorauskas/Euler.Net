using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {

    public class Euler3 : IEuler {

        public string Problem {
            get {
                return @"
Project Euler Problem 3:

   The prime factors of 13195 are 5, 7, 13 and 29.

   What is the largest prime factor of the number 600851475143 ?

";
            }
        }

        public string Answer {
            get {
                return "The largest prime factor of the number 600851475143 is: {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return PrimeFactors(600851475143, 2).Last();
        }

        private IEnumerable<long> PrimeFactors(long n, long factor) {
            List<long> factors = new List<long>();

            while (n % factor != 0)
                factor++;

            factors.Add(factor);

            if (n > factor)
                factors.AddRange(PrimeFactors(n / factor, factor));

            return factors;
        }
    }
}
