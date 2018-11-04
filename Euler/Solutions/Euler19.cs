using System;
using System.Linq;

namespace Euler.Solutions {
    public class Euler19 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 19:

    You are given the following information, but you may prefer to do some
    research for yourself.

    a. 1 Jan 1900 was a Monday.
    b. Thirty days has September,
       April, June and November.
       All the rest have thirty-one,
       Saving February alone,
       Which has twenty-eight, rain or shine.
       And on leap years, twenty-nine.
    c. A leap year occurs on any year evenly divisible by 4, but not on a
       century unless it is divisible by 400.

    How many Sundays fell on the first of the month during the twentieth
    century (1 Jan 1901 to 31 Dec 2000)? 

";
            }
        }

        public string Answer {
            get {
                return "There were {0} Sundays falling on the first of the month in the twentieth century."
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return new DateTime(1901, 1, 1)
                .Unfold(d => d.AddMonths(1))
                .TakeWhile(d => d <= new DateTime(2000, 12, 31))
                .Count(d => d.DayOfWeek == DayOfWeek.Sunday);
        }

    }
}
