using System;
using System.Linq;
using Euler.Sequences;

namespace Euler.Solutions {

    public class Euler5 : IEuler {

        public string Problem {
            get {
                return @"
Project Euler Problem 5:

   2520 is the smallest number that can be divided by each of the 
   numbers from 1 to 10 without any remainder.

   What is the smallest positive number that is evenly divisible 
   by all of the numbers from 1 to 20?

";
            }
        }

        public string Answer {
            get {
                return "The smallest positive number that is evenly divisible\nby all of the numbers from 1 to 20 is: {0}"
                    .FormatWith(this.Solve());
            }
        }
        
        /**
         * Using prime factorisation
         * Let pi be the i’th prime, then N can be expressed as N = p1^a1 * p2^a2 * p3^a3…
         * We start by putting ai = 0 for all i. We can iterate over all the divisors, such that divisor j=1,2,…,20 can
         * be factorised as Nj = p1^b1 * p2^b2 * p3^b3… and then ai = max(ai, bi). For p1 = 2, we have that 2^4=16 and
         * 2^5 = 32. Therefore a1 = 4. In more general terms we can express ai = floor(log k/ log pi).
         * this version runs in about 1/2 second.
         */
        public double Solve() {
            var max = 20;
            var p = new IntPrimeSequence().TakeWhile(x => x < max);
            
            return 0.To(p.Count() - 1).ToList()
                .Aggregate( //reduce
                    1, 
                    (acc, i) => acc *= ((int) Math.Pow(p.ElementAt(i), (int) Math.Floor(Math.Log(max) / Math.Log(p.ElementAt(i))))),
                    x => x
                );
        }
    }
}
