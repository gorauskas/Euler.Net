using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler41Test {

        [Test]
        public void TestSolve041() {

            Euler41 e = new Euler41();
            Assert.AreEqual(7652413.0, e.Solve());

        }

    }

}
