
using System.Collections.Generic;

namespace Euler.Solutions {
    public class Euler31 : IEuler {

        private const int TARGET = 200;

        public string Problem {
            get {
                return @"
Project Euler Problem 31:

    In England the currency is made up of pound, £, and pence, p, and there are 
    eight coins in general circulation:

        1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).

    It is possible to make £2 in the following way:

        1*£1 + 1*50p + 2*20p + 1*5p + 1*2p + 3*1p

    How many different ways can £2 be made using any number of coins?

";
            }
        }

        public string Answer {
            get {
                return "£2 can be made using {0} different ways."
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            IEnumerable<int> coins = new List<int>(new int[] { 1, 2, 5, 10, 20, 50, 100, 200 });
            List<int> ways = new List<int>(new int[201]);
            ways[0] = 1;

            foreach (var coin in coins) {
                foreach (var i in coin.To(TARGET)) {
                    ways[i] += ways[i - coin];
                }
            }

            return ways[TARGET];
        }
    }
}
