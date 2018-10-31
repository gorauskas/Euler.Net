using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions {
    public class Euler17 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 17:

    If the numbers 1 to 5 are written out in words: one, two, three, four, 
    five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

    If all the numbers from 1 to 1000 (one thousand) inclusive were written 
    out in words, how many letters would be used?

    NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and 
    forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 
    20 letters. The use of 'and' when writing out numbers is in compliance 
    with British usage.

";
            }
        }

        public string Answer {
            get {
                return "The numbers from 1 to 1000, when written out in words, have {0} letters."
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return 1.To(1000)
                    .Select(x => SpellNumberOut(x))
                    .JoinAsString()
                    .Replace(" ", "")
                    .Count();
        }


        private Dictionary<int, string> GetLookupTable() {
            Dictionary<int, string> table = new Dictionary<int, string>();
            table.Add(1, "one"); table.Add(2, "two"); table.Add(3, "three"); table.Add(4, "four"); table.Add(5, "five");
            table.Add(6, "six"); table.Add(7, "seven"); table.Add(8, "eight"); table.Add(9, "nine"); table.Add(10, "ten");
            table.Add(11, "eleven"); table.Add(12, "twelve"); table.Add(13, "thirteen"); table.Add(14, "fourteen"); table.Add(15, "fifteen");
            table.Add(16, "sixteen"); table.Add(17, "seventeen"); table.Add(18, "eighteen"); table.Add(19, "nineteen"); table.Add(20, "twenty");
            table.Add(30, "thirty"); table.Add(40, "forty"); table.Add(50, "fifty"); table.Add(60, "sixty"); table.Add(70, "seventy");
            table.Add(80, "eighty"); table.Add(90, "ninety"); table.Add(100, "hundred"); table.Add(1000, "thousand"); //table.Add(0, "zero");
            return table;
        }

        private string SpellNumberOut(int n) {
            StringBuilder buff = new StringBuilder();
            var table = GetLookupTable();
            var nums = n.ToString().ToCharArray().Reverse().ToList();

            if (nums.Count() == 4 && nums[3] != '0') {
                buff.Append(table[Int32.Parse(nums[3].ToString())] + " thousand");
            }

            if (nums.Count() >= 3 && nums[2] != '0') {
                buff.Append(table[Int32.Parse(nums[2].ToString())] + " hundred");
                if (nums.Count() >= 2 && nums[1] != '0')
                    buff.Append(" and");
                else if (nums.Count() >= 1 && nums[0] != '0')
                    buff.Append(" and");
            }

            var dec_post_val = 99;
            if (nums.Count() >= 2 && nums[1] != '0') {
                dec_post_val = Int32.Parse(nums[1].ToString()) * 10 + Int32.Parse(nums[0].ToString());
                if (dec_post_val <= 20)
                    buff.Append(" " + table[dec_post_val]);
                else
                    buff.Append(" " + table[Int32.Parse(nums[1].ToString()) * 10]);
            }

            if (nums.Count() >= 1 && nums[0] != '0' && dec_post_val > 20) {
                buff.Append(" " + table[Int32.Parse(nums[0].ToString())]);
            }

            return buff.ToString().Replace(" ", "");
        }
    }
}
