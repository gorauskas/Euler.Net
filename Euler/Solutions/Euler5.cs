using System.Linq;

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

        // TODO: This is pretty slow
        public double Solve() {
            return 1.ToMax()
                .Where(x => x.IsEven())
                .First(x => x.IsMultipleOf(11.To(20).ToArray()));
        }
    }
}
