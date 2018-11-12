using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler23 : IEuler {

        private const int MAX = 28123;  //20161; //

        public string Problem {
            get {
                return @"
Project Euler Problem 23:

    A perfect number is a number for which the sum of its proper divisors is
    exactly equal to the number. For example, the sum of the proper divisors of
    28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect
    number.

    A number n is called `deficient` if the sum of its proper divisors is less
    than n and it is called `abundant` if this sum exceeds n.

    As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest 
    number that can be written as the sum of two abundant numbers is 24. By 
    mathematical analysis, it can be shown that all integers greater than 28123 
    can be written as the sum of two a numbers. However, this upper limit cannot 
    be reduced any further by analysis even though it is known that the greatest 
    number that cannot be expressed as the sum of two abundant numbers is less 
    than this limit.

    Find the sum of all the positive integers which cannot be written as the sum
    of two abundant numbers.

";
            }
        }

        public string Answer {
            get {
                return "The sum of all the positive integers which cannot be written as\nthe sum of two abundant numbers is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            var sumsOfTwoAbundants = CalcSumsOfTwoAbundants(1.To(MAX).Where(x => x.SumOfDivisors() > x));
            return 1.To(MAX)
                .Where(x => !x.In(sumsOfTwoAbundants))
                .Sum();
        }

        /// <summary>
        /// Calculates the sums of two abundants and returns a set containing all values under MAX.
        /// This is the LINQ version. Runs in about 3 seconds.
        /// </summary>
        /// <returns>
        /// Returns all the sums of 2 abundants in a set sequence - The HashSet is used to guarantee
        /// item uniqueness.
        /// </returns>
        /// <param name='abundants'>
        /// A sequence of abundant numbers under MAX
        /// </param>
        private ISet<int> CalcSumsOfTwoAbundants(IEnumerable<int> abundants) {
            var nums = abundants.ToList();

            return new HashSet<int>(nums.SelectMany((j, ix) => nums.Skip(ix)
                                                                   .Take(nums.Count - 1 - ix)
                                                                   .Select(i => new { j, i }))
                                        .Select(x => x.j + x.i)
                                        .Where(x => x <= MAX));
        }
    }
}
