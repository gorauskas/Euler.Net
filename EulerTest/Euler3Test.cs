using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler3Test {

        [Test]
        public void TestSolve() {

            Euler3 e = new Euler3();
            Assert.AreEqual(6857.0, e.Solve());

        }

    }

}
