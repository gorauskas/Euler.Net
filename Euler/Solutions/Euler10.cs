using System.Linq;
using Euler.Sequences;

namespace Euler.Solutions {

    public class Euler10 : IEuler {

        public string Problem {
            get {
                return @"
Project Euler Problem 10:

   The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

   Find the sum of all the primes below two million.

";
            }
        }

        public string Answer {
            get {
                return "The sum of all primes below 2 million is: {0}".FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return new LongPrimeSequence().AsParallel().TakeWhile(x => x < 2000000).Sum();
        }

    }

}
