using System.Linq;
using Euler.Sequences;

namespace Euler.Solutions {

    public class Euler7 : IEuler {

        public string Problem {
            get {
                return @"
Project Euler Problem 7:

   By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, 
   we can see that the 6th prime is 13.

   What is the 10001st prime number?

";
            }
        }

        public string Answer {
            get {
                return "Prime 10001 is {0}".FormatWith(this.Solve());
            }
        }

        public double Solve() {
            long prime = new LongPrimeSequence().ElementAt(10001 - 1);
            return prime;
        }

    }

}
