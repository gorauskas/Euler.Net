
using System.Linq;
using System.Numerics;

namespace Euler.Solutions {
    public class Euler56 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 56

    A googol (10^100) is a massive number: one followed by one-hundred zeros;
    100^100 is almost unimaginably large: one followed by two-hundred
    zeros. Despite their size, the sum of the digits in each number is only 1.

    Considering natural numbers of the form, a^b, where a, b < 100, what is the
    maximum digital sum?

";
            }
        }

        public string Answer {
            get {
                return "The max digital sum is {0}."
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            int ls = 0;

            foreach (int i in 1.To(99)) {
                foreach (int j in 1.To(99)) {
                    BigInteger n = BigInteger.Pow(new BigInteger(i), j);
                    int s = n.ToString().ToList().Select(x => x.ToInt()).Sum();
                    if (s > ls) {
                        ls = s;
                    }
                }
            }

            return ls;
        }
    }
}
