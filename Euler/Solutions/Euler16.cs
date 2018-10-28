
using System.Numerics;

namespace Euler.Solutions {
    public class Euler16 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 16:

    2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

    What is the sum of the digits of the number 2^1000?

";
            }
        }

        public string Answer {
            get {
                return "The sum of the digits of the number 2^1000 is: {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return BigInteger.Pow(2, 1000)
                    .ToString()
                    .ToByteSequence()
                    .Sum();
        }
    }
}
