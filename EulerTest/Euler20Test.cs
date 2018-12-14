using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler20Test {

        [Test]
        public void TestSolve020() {

            Euler20 e = new Euler20();
            Assert.AreEqual(648.0, e.Solve());

        }

    }

}
