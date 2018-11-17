using System;
using System.Collections.Generic;
using System.Linq;
using Euler.Sequences;

namespace Euler.Solutions {
    public class Euler26 : IEuler {

        private readonly IList<int> decs = new List<int>();

        public string Problem {
            get {
                return @"
Project Euler Problem 26:

    A unit fraction contains 1 in the numerator. The decimal representation of 
    the unit fractions with denominators 2 to 10 are given:

    1/2 =  0.5 
    1/3 =  0.(3) 
    1/4 =  0.25 
    1/5 =  0.2 
    1/6 =  0.1(6) 
    1/7 =  0.(142857) 
    1/8 =  0.125 
    1/9 =  0.(1) 
    1/10 =  0.1 

    Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can 
    be seen that 1/7 has a 6-digit recurring cycle.

    Find the value of d < 1000 for which 1/d contains the longest recurring 
    cycle in its decimal fraction part.

";
            }
        }

        public string Answer {
            get {
                return "The value of d > 1000 for which 1/d contains the longest recurring\ncycle in its decimal fraction part is: {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return new IntPrimeSequence()
                .TakeWhile(x => x <= 999)
                .Select(x => new { Div = x, CycleLenght = CalcCycleLen(x) })
                .OrderByDescending(x => x.CycleLenght)
                .First()
                .Div;
        }

        private int CalcCycleLen(int divs) {
            decs.Clear();
            int remd;
            Math.DivRem(1 * 10, divs, out remd);
            return CalcCycleLen(remd, divs);
        }

        private int CalcCycleLen(int divd, int divs) {
            if (divd == 1) {
                return decs.Count() + 1;
            }

            int remd;
            var quot = Math.DivRem(divd * 10, divs, out remd);
            decs.Add(quot);

            if (remd == 0) {
                return 0;
            }

            return CalcCycleLen(remd, divs);
        }
    }
}
