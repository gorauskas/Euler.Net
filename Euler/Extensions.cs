using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

namespace Euler {
    public static class Extensions {

        #region IsEven

        public static bool IsEven(this int n) {
            return n % 2 == 0;
        }

        public static bool IsEven(this long n) {
            return n % 2 == 0;
        }

        public static bool IsEven(this BigInteger n) {
            return n % 2 == 0;
        }

        #endregion

        #region IsPrime

        public static bool IsPrime(this int n) {
            if ((n & 1) == 0)
                if (n == 2)
                    return true;
                else
                    return false;

            for (int k = 3; (k * k) <= n; k += 2)
                if ((n % k) == 0)
                    return false;

            return n != 1;
        }

        public static bool IsPrime(this long n) {
            if ((n & 1) == 0)
                if (n == 2)
                    return true;
                else
                    return false;

            for (long k = 3; (k * k) <= n; k += 2)
                if ((n % k) == 0)
                    return false;

            return n != 1;
        }

        public static bool IsPrime(this BigInteger n) {
            if ((n & 1) == 0)
                if (n == 2)
                    return true;
                else
                    return false;

            for (BigInteger k = 3; (k * k) <= n; k += 2)
                if ((n % k) == 0)
                    return false;

            return n != 1;
        }

        #endregion

        #region ToInt

        /// <summary>
        /// All objects in the .NET Fx have a ToString method, but there is one type that
        /// deserves to have a ToInt method and that's string itself.
        /// </summary>
        /// <param name="str">The string to convert to int</param>
        /// <returns>an Int32 representation of the string</returns>
        /// <remarks>Throws an error if the string cannot be parsed into a number</remarks>
        public static int ToInt(this string str) {
            return Int32.Parse(str);
        }

        /// <summary>
        /// Also deserving are char types ... All objects in the .NET Fx have a ToString method, 
        /// but there is one type that deserves to have a ToInt method and that's char.
        /// </summary>
        /// <param name="c">The char to convert to int</param>
        /// <returns>an Int32 representation of the char</returns>
        public static int ToInt(this char c) {
            return ToInt(new string(c, 1));
        }

        #endregion

        #region To
        public static IEnumerable<int> ToMax(this int i) {
            return i.To(int.MaxValue);
        }

        public static IEnumerable<int> To(this int i, int to) {
            for (var x = i; x <= to; x++)
                yield return x;
        }

        public static IEnumerable<long> ToMax(this long i) {
            return i.To(long.MaxValue);
        }

        public static IEnumerable<long> To(this long i, long to) {
            for (var x = i; x <= to; x++)
                yield return x;
        }
        #endregion

        #region IsMultipleOf
        public static bool IsMultipleOf(this int i, int num) {
            if (num == 0)
                return false;

            return i % num == 0;
        }

        public static bool IsMultipleOf(this int i, params int[] nums) {
            return nums.All(n => i.IsMultipleOf(n));
        }

        public static bool IsMultipleOf(this long l, long num) {
            if (num == 0)
                return false;

            return l % num == 0;
        }

        public static bool IsMultipleOf(this long l, params long[] nums) {
            return nums.All(n => l.IsMultipleOf(n));
        }
        #endregion

        #region Pow

        public static double Pow(this double n, double power) {
            return Math.Pow(n, power);
        }

        public static int Pow(this int n, int power) {
            return (int)Math.Pow(n, power);
        }

        public static long Pow(this long n, long power) {
            return (long)Math.Pow(n, power);
        }

        #endregion

        #region Sqr

        public static double Sqr(this double n) {
            return Pow(n, 2);
        }

        public static int Sqr(this int n) {
            return (int)Sqr((double)n);
        }

        public static long Sqr(this long n) {
            return (long)(n * n);
        }

        #endregion

        /// <summary>
        /// Extension method to pretty-print a list like it is represented in the python language
        ///      [ 1, 2, 3, 4, 5 ]
        /// </summary>
        /// <typeparam name="T">the type of list items</typeparam>
        /// <param name="list">the list</param>
        /// <returns>string</returns>
        public static string ListToString<T>(this List<T> list) {
            StringBuilder sb = new StringBuilder("[");

            foreach (var item in list) {
                sb.Append(item.ToString());
                sb.Append(", ");
            }

            sb.Append("]");
            return sb.ToString().Replace(", ]", "]");
        }

        public static string FormatWith(this string str, params object[] args) {
            return string.Format(str, args);
        }

        public static IEnumerable<int> End(this IEnumerable<int> ei, int endNum) {
            return ei.TakeWhile(x => x <= endNum);
        }

    }
}
