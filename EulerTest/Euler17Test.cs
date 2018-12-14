using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler17Test {

        [Test]
        public void TestSolve017() {

            Euler17 e = new Euler17();
            Assert.AreEqual(21124.0, e.Solve());

        }

    }

}
