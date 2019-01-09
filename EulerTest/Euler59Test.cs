﻿using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler59Test {

        [Test]
        public void TestSolve059() {

            Euler59 e = new Euler59();
            Assert.AreEqual(107359.0, e.Solve());

        }

    }

}
