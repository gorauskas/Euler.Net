using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Euler {
    public static class Extensions {

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

        public static string FormatWith(this string str, params object[] args) {
            return string.Format(str, args);
        }

    }
}
