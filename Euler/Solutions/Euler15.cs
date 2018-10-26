using System.Numerics;

namespace Euler.Solutions {
    public class Euler15 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 15:

    Starting in the top left corner of a 2x2 grid, there are 6 routes (without 
    backtracking) to the bottom right corner.

    How many routes are there through a 20x20 grid?

";
            }
        }

        public string Answer {
            get {
                return "There are {0} routes through a 20x20 grid"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return (double)40.Choose(20);
        }

    }
}
