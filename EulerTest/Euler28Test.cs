using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler28Test {

        [Test]
        public void TestSolve028() {

            Euler28 e = new Euler28();
            Assert.AreEqual(669171001.0, e.Solve());

        }

    }

}
