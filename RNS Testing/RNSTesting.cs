using Microsoft.VisualStudio.TestTools.UnitTesting;
using RNS;

namespace RNS_Testing
{
    [TestClass]
    public class RNSTesting
    {
        [TestMethod]
        public void AddTest()
        {
            // arrange
            RNSCounter counterA = new RNSCounter();
            counterA.AddCounter(new BaseCounter(7));
            counterA.AddCounter(new BaseCounter(3));
            counterA.AddCounter(new BaseCounter(5));
            counterA.Click(3); // 3 0 3

            RNSCounter counterB = new RNSCounter();
            counterB.AddCounter(new BaseCounter(7));
            counterB.AddCounter(new BaseCounter(3));
            counterB.AddCounter(new BaseCounter(5));
            counterB.Click(6); // 6 0 1

            RNSCounter expected = new RNSCounter();
            expected.AddCounter(new BaseCounter(7, 2));
            expected.AddCounter(new BaseCounter(3, 0));
            expected.AddCounter(new BaseCounter(5, 4));

            // act
            RNSCounter result = RNSMath.Add(counterA, counterB); // expect 2 0 4

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SubtractTest()
        {
            // arrange
            RNSCounter counterA = new RNSCounter();
            counterA.AddCounter(new BaseCounter(7));
            counterA.AddCounter(new BaseCounter(3));
            counterA.AddCounter(new BaseCounter(5));
            counterA.AddCounter(new BaseCounter(2));
            counterA.Click(5); // 5 2 0 1

            RNSCounter counterB = new RNSCounter();
            counterB.AddCounter(new BaseCounter(7));
            counterB.AddCounter(new BaseCounter(3));
            counterB.AddCounter(new BaseCounter(5));
            counterB.AddCounter(new BaseCounter(2));
            counterB.Click(10); // 3 1 0 0

            RNSCounter expected = new RNSCounter();
            expected.AddCounter(new BaseCounter(7, 2));
            expected.AddCounter(new BaseCounter(3, 1));
            expected.AddCounter(new BaseCounter(5, 0));
            expected.AddCounter(new BaseCounter(2, 1));

            // act
            RNSCounter result = RNSMath.Subtract(counterA, counterB); // expect 2 1 0 1

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            // arrange
            RNSCounter counterA = new RNSCounter();
            counterA.AddCounter(new BaseCounter(7));
            counterA.AddCounter(new BaseCounter(3));
            counterA.AddCounter(new BaseCounter(5));
            counterA.AddCounter(new BaseCounter(2));
            counterA.Click(5); // 5 2 0 1

            RNSCounter counterB = new RNSCounter();
            counterB.AddCounter(new BaseCounter(7));
            counterB.AddCounter(new BaseCounter(3));
            counterB.AddCounter(new BaseCounter(5));
            counterB.AddCounter(new BaseCounter(2));
            counterB.Click(11); // 4 2 1 1

            RNSCounter expected = new RNSCounter();
            expected.AddCounter(new BaseCounter(7, 6));
            expected.AddCounter(new BaseCounter(3, 1));
            expected.AddCounter(new BaseCounter(5, 0));
            expected.AddCounter(new BaseCounter(2, 1));

            // act
            RNSCounter result = RNSMath.Multiply(counterA, counterB); // expect 6 1 0 1

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveTest()
        {
            // arrange
            RNSCounter result = new RNSCounter();
            result.AddCounter(new BaseCounter(7));
            result.AddCounter(new BaseCounter(3));
            result.AddCounter(new BaseCounter(5));

            RNSCounter expected = new RNSCounter();
            expected.AddCounter(new BaseCounter(3));
            expected.AddCounter(new BaseCounter(5));

            // act
            result.RemoveCounter(1);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
