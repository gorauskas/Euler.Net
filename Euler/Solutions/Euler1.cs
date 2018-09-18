using System.Collections.Generic;
using System.Linq;
using Euler;

namespace Euler.Solutions {
    public class Euler1 : IEuler {

        public string Problem {
            get {
                return @"
Project Euler Problem 1:

   If we list all the natural numbers below 10 that are
   multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of 
   these multiples is 23.

   Find the sum of all the multiples of 3 or 5 below 1000.

";
            }
        }

        public string Answer {
            get {
                return "The sum of all the multiples of 3 or 5 below 1000 is: {0}".FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return 1.To(999)
                .Where(i => i.IsMultipleOf(3) || i.IsMultipleOf(5))
                .Sum();
        }
    }
}
