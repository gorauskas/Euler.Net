using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Euler.Sequences;

namespace Euler.Solutions {
    public class Euler41 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 41:

    We shall say that an n-digit number is pandigital if it makes use of all
    the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital
    and is also prime.

    What is the largest n-digit pandigital prime that exists?

";
            }
        }

        public string Answer {
            get {
                return "The largest n-digit pandigital prime that exists is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            long n = 7654321;

            while (!(n.IsPrime() && n.IsPanDigital(7))) {
                n -= 2;
            }

            return n;
        }
    }
}
