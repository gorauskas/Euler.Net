using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler38Test {

        [Test]
        public void TestSolve038() {

            Euler38 e = new Euler38();
            Assert.AreEqual(932718654.0, e.Solve());

        }

    }

}
