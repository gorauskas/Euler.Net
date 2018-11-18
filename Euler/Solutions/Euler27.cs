using System;
using System.Collections.Generic;


namespace Euler.Solutions {
    public class Euler27 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 27:

    Euler published the remarkable quadratic formula:

    n² + n + 41

    It turns out that the formula will produce 40 primes for the consecutive 
    values n = 0 to 39. However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 
    is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly 
    divisible by 41.

    Using computers, the incredible formula  n² - 79n + 1601 was discovered, 
    which produces 80 primes for the consecutive values n = 0 to 79. The 
    product of the coefficients, -79 and 1601, is -126479.

    Considering quadratics of the form:

    n² + an + b, where |a| < 1000 and |b| < 1000

    where |n| is the modulus/absolute value of n
    e.g. |11| = 11 and |-4| = 4
    
    Find the product of the coefficients, a and b, for the quadratic 
    expression that produces the maximum number of primes for consecutive 
    values of n, starting with n = 0.

";
            }
        }

        public string Answer {
            get {
                return "The product of the coefficients, a and b, for the quadratic expression that produces\nthe maximum number of primes for consecutive values of n is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            int max = 0, res = 0, a = 0, b = 0;

            for (int x = -999; x <= 999; x++) {
                for (int y = -999; y <= 999; y++) {
                    bool done = false;
                    int count = 0;

                    while (!done) {
                        int num = count * count + x * count + y;
                        if (num > 0 && num.IsPrime()) {
                            count++;
                        } else {
                            done = true;
                        }
                    }

                    if (count > max) {
                        a = x;
                        b = y;
                        max = count;
                        res = x * y;
                    }
                }
            }

            return res;
        }
    }
}
