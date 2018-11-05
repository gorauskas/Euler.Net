using System;
using System.Linq;

namespace Euler.Solutions {
    public class Euler20 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 20:

    n! means n * (n - 1) * ... * 3 * 2 * 1

    For example, 10! = 10 * 9 * ... * 3 * 2 * 1 = 3628800,
    and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

    Find the sum of the digits in the number 100!

";
            }
        }

        public string Answer {
            get {
                return "The sum of the digits in the number 100! is: {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return 100.BigFactorial()
                .ToString()
                .Select(x => Int32.Parse(x.ToString()))
                .Sum();
        }
    }
}
