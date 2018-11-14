
using System.Linq;

namespace Euler.Solutions {
    public class Euler24 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 24:

    A permutation is an ordered arrangement of objects. For example, 3124 is one 
    possible permutation of the digits 1, 2, 3 and 4. If all of the permutations 
    are listed numerically or alphabetically, we call it lexicographic order. The 
    lexicographic permutations of 0, 1 and 2 are:

    012   021   102   120   201   210

    What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 
    5, 6, 7, 8 and 9?

";
            }
        }

        public string Answer {
            get {
                return "The millionth lexicographic permutation of the digits 0 to 9 is: {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return 0.To(9).ToArray()
                          .Permute()
                          .ToList()[999999]
                          .ToList()
                          .ToLong();
        }
    }
}
