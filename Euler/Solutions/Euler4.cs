using System.Linq;

namespace Euler.Solutions {

    public class Euler4 : IEuler {

        /// <summary>
        /// There is more than one way to skin this cat. I chose to create nested loops 
        /// because it gives me easy access to the Factors that create the final Product.
        /// There is also a really elegant implementation using Linq included, but you can't
        /// get at the Factors as easily with Linq.
        /// </summary>
        public string Problem {
            get {
                return @"
Project Euler Problem 4:

   A palindromic number reads the same both ways. The largest palindrome made 
   from the product of two 2-digit numbers is 9009 = 91  99.

   Find the largest palindrome made from the product of two 3-digit numbers.

";
            }
        }

        public string Answer {
            get {
                return "The largest palindrome made of the product of two 3 digit numbers is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return 100.To(999)
                    .SelectMany(x => 100.To(999).Select(y => x * y))
                    .Where(IsPalindrome)
                    .Max();
        }

        private bool IsPalindrome(int i) {
            return i.ToString().SequenceEqual(i.ToString().Reverse());
        }

    }
}
