using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler32Test {

        [Test]
        public void TestSolve032() {

            Euler32 e = new Euler32();
            Assert.AreEqual(45228.0, e.Solve());

        }

    }

}
