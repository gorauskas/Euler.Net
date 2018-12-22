using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Euler.Solutions {
    public class Euler48 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 48 

    The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.

    Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
";
            }
        }

        public string Answer {
            get {
                return "The last ten digits of the series are {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            var s = 1.To(999)
                .Select(x => BigInteger.Pow(BigInteger.Parse(x.ToString()), x))
                .ToList()
                .Sum()
                .ToString();

            return Double.Parse(s.Substring(s.Length - 10));
        }
    }
}
