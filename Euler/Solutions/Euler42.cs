using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Euler.Solutions {
    public class Euler42 : IEuler {

        private const string ASCII_UPCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Problem {
            get {
                return @"
Project Euler Problem 42:

    The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:

      1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

    By converting each letter in a word to a number corresponding to its alphabetical position and adding these values 
    we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. If the word value is a 
    triangle number then we shall call the word a triangle word.

    Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common 
    English words, how many are triangle words?

";
            }
        }

        public string Answer {
            get {
                return "There are {0} triangle words in the file."
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            var triangle_nums = Enumerable.Range(1, 100).Select(n => (int)(0.5 * n * (n + 1)));

            return File.ReadAllText("Artifacts/words.txt")
                .Split(new[] { ',' })
                .Select(word => word.Trim(new[] { '\"' }))
                .Where(w => triangle_nums.Contains(
                    w.Select(l => ASCII_UPCASE.IndexOf(
                        l.ToString().ToUpper()) + 1).Sum()))
                .Count();
        }
    }
}
