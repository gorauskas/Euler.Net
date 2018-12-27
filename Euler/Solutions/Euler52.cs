using System;

namespace Euler.Solutions {
    public class Euler52 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 52 

    It can be seen that the number, 125874, and its double, 251748, contain 
    exactly the same digits, but in a different order.

    Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, 
    contain the same digits.

";
            }
        }

        public string Answer {
            get {
                return "The smallest positive integer is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            Func<int, string> F = x => x.ToString().Sorted();
            int n = 99999;

            while (!(F(n) == F(n*2) && F(n) == F(n * 3) && F(n) == F(n * 4) && 
                F(n) == F(n * 5) && F(n) == F(n * 6))) {

                n += 9;
            }

            return n;
        }
    }
}
