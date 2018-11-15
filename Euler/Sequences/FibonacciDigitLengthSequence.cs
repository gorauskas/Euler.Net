using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Sequences {
    public class FibonacciDigitLengthSequence : IEnumerable<int> {

        private readonly double phi;

        public FibonacciDigitLengthSequence() {
            //http://en.wikipedia.org/wiki/Phi
            phi = (1d + 5d.Sqrt()) / 2d;
        }

        public IEnumerator<int> GetEnumerator() {
            return 0.ToMax()
                .Select(CalculateDigitLength)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        private int CalculateDigitLength(int index) {
            if (index == 0 || index == 1) {
                return 1;
            }

            //http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibFormula.html#logs
            return (int)(index * Math.Log10(phi) - Math.Log10(5d) / 2 + 1d);
        }
    }
}
