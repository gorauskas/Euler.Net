using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler12Test {

        [Test]
        public void TestSolve012() {

            Euler12 e = new Euler12();
            Assert.AreEqual(76576500.0, e.Solve());

        }

    }

}
