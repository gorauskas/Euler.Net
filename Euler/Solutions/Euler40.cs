
using System.Linq;
using System.Collections.Generic;

namespace Euler.Solutions {
    public class Euler40 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 40:

    An irrational decimal fraction is created by concatenating the positive 
    integers:

        0.123456789101112131415161718192021...

    It can be seen that the 12th digit of the fractional part is 1.
    If dn represents the nth digit of the fractional part, find the value of 
    the following expression.

        d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000

";
            }
        }

        public string Answer {
            get {
                return "The value is {0}".FormatWith(this.Solve());
            }
        }

        public double Solve() {
            List<int> L = new List<int>();

            foreach (int n in Enumerable.Range(0, 1000000)) {
                L.Add(n);
            }

            string LS = L.ConcatListAsString();

            return LS[1].ToInt() * LS[10].ToInt() * LS[100].ToInt() *
                   LS[1000].ToInt() * LS[10000].ToInt() * LS[100000].ToInt() *
                   LS[1000000].ToInt();
        }
    }
}
