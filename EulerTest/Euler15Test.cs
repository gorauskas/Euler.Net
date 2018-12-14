using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler15Test {

        [Test]
        public void TestSolve015() {

            Euler15 e = new Euler15();
            Assert.AreEqual(137846528820.0, e.Solve());

        }

    }

}
