using System;
using System.Linq;

namespace Euler.Solutions {
    public class Euler43 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 43:

    The number, 1406357289, is a 0 to 9 pandigital number because it is made up 
    of each of the digits 0 to 9 in some order, but it also has a rather interesting 
    sub-string divisibility property.

    Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note 
    the following:

        d2d3d4=406 is divisible by 2
        d3d4d5=063 is divisible by 3
        d4d5d6=635 is divisible by 5
        d5d6d7=357 is divisible by 7
        d6d7d8=572 is divisible by 11
        d7d8d9=728 is divisible by 13
        d8d9d10=289 is divisible by 17 

    Find the sum of all 0 to 9 pandigital numbers with this property.

";
            }
        }

        public string Answer {
            get {
                return "The sum of all 0 to 9 pandigital numbers with the property is {0}"
                    .FormatWith(this.Solve());
            }
        }

        /// <summary>
        /// 1. there are only 3,628,800 (10!) 0 to 9 pandigital numbers, so there's no need
        ///    to examine all 10 billion 10-digit numbers.   
        /// 2. consider only numbers whose last 3 digits divide by 17  
        /// 3. now only check the permutations of the 7 remaining digits 
        /// 4. this can be reduced further by considering the division by 13 and so on
        /// </summary>
        /// <returns>the solution </returns>
        public double Solve() {
            Func<int[], bool> F1 = x => (x.ToList().GetRange(1, 3).ConcatListAsNumber() % 2) == 0;
            Func<int[], bool> F2 = x => (x.ToList().GetRange(2, 3).ConcatListAsNumber() % 3) == 0;
            Func<int[], bool> F3 = x => (x.ToList().GetRange(3, 3).ConcatListAsNumber() % 5) == 0;
            Func<int[], bool> F4 = x => (x.ToList().GetRange(4, 3).ConcatListAsNumber() % 7) == 0;
            Func<int[], bool> F5 = x => (x.ToList().GetRange(5, 3).ConcatListAsNumber() % 11) == 0;
            Func<int[], bool> F6 = x => (x.ToList().GetRange(6, 3).ConcatListAsNumber() % 13) == 0;
            Func<int[], bool> F7 = x => (x.ToList().GetRange(7, 3).ConcatListAsNumber() % 17) == 0;
            long sum = 0;

            foreach (var item in 0.To(9).ToArray().Permute()) {
                if (F7(item) && F6(item) && F5(item) && F4(item) &&
                    F3(item) && F2(item) && F1(item)) {

                    sum += item.ToList().ConcatListAsNumber();

                }
            }

            return sum;
        }
    }
}
