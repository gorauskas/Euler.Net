
using System.Numerics;

namespace Euler.Solutions {
    public class Euler57 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 57

    It is possible to show that the square root of two can be expressed as an
    infinite continued fraction.

      √ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...

    By expanding this for the first four iterations, we get:

      1 + 1/2 = 3/2 = 1.5
      1 + 1/(2 + 1/2) = 7/5 = 1.4
      1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
      1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...

    The next three expansions are 99/70, 239/169, and 577/408, but the eighth
    expansion, 1393/985, is the first example where the number of digits in the
    numerator exceeds the number of digits in the denominator.

    In the first one-thousand expansions, how many fractions contain a
    numerator with more digits than denominator?

";
            }
        }

        public string Answer {
            get {
                return "There are {0} fractions whose numerators have more digits\nthan then denominator."
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            // Limit, number, denominator, count
            int L = 1000;
            BigInteger n = 3;
            BigInteger d = 2;
            int c = 0;

            foreach (var x in 2.To(L - 1)) {
                n += 2 * d;
                d = n - d;

                if (BigInteger.Log10(n).ToLong() > BigInteger.Log10(d).ToLong()) {
                    c++;
                }
            }

            return c;
        }
    }
}
