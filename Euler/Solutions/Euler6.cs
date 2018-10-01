using System.Linq;

namespace Euler.Solutions {

    public class Euler6 : IEuler {

        public string Problem {
            get {
                return @"
Project Euler Problem 6:

   The sum of the squares of the first ten natural numbers is,
   
     12 + 22 + ... + 102 = 385
   
   The square of the sum of the first ten natural numbers is,
   
     (1 + 2 + ... + 10)2 = 552 = 3025
   
   Hence the difference between the sum of the squares of the 
   first ten natural numbers and the square of the sum is 
   3025  385 = 2640. 
   
   Find the difference between the sum of the squares of the 
   first one hundred natural numbers and the square of the sum.

";
            }
        }

        public string Answer {
            get {
                return "The difference between the sum of the squares\n" +
                "and the square of the sum of the first 100 numbers\n" +
                "is: {0}"
                .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            var sumOfsqr = 1.To(100).Sum().Sqr();
            var sqrOfsum = 1.To(100).Select(x => x.Sqr()).Sum();
            return sumOfsqr - sqrOfsum;
        }
    }
}
