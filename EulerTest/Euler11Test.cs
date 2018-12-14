using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler11Test {

        [Test]
        public void TestSolve011() {

            Euler11 e = new Euler11();
            Assert.AreEqual(70600674.0, e.Solve());

        }

    }

}
