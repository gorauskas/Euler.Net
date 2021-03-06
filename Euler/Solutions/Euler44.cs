﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler44 : IEuler {


        public string Problem {
            get {
                return @"
Project Euler Problem 44

    Pentagonal numbers are generated by the formula, Pn=n(3n−1)/2. The first ten 
    pentagonal numbers are:

        1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...

    It can be seen that P4 + P7 = 22 + 70 = 92 = P8. However, their difference, 
    70 − 22 = 48, is not pentagonal.

    Find the pair of pentagonal numbers, Pj and Pk, for which their sum and 
    difference are pentagonal and D = |Pk − Pj| is minimised; what is the value 
    of D?

";
            }
        }

        public string Answer {
            get {
                return "The value of D is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            // Only look at pentagonal numbers
            var pentaList = GetPentaList();

            foreach (var n in 1.To(2499)) {
                foreach (var m in 1.To(n)) {
                    var i = pentaList[n];
                    var j = pentaList[m];
                    if (IsPentagonal(i + j) && IsPentagonal(i - j)) {
                        return i - j;
                    }
                }
            }

            return 0;
        }

        private Func<long, bool> IsPentagonal = x => (((24.0 * x + 1.0).Sqrt() + 1.0) / 6.0) % 1.0 == 0;
        
        private List<long> GetPentaList() {
            return 1L.To(99999)
                .Select(x => x * (3 * x - 1) / 2)
                .ToList();
        }
    }
}
