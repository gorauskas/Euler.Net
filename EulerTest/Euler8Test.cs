using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler8Test {

        [Test]
        public void TestSolve008() {

            Euler8 e = new Euler8();
            Assert.AreEqual(23514624000.0, e.Solve());

        }

    }

}
