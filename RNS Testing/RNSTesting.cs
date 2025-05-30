using Microsoft.VisualStudio.TestTools.UnitTesting;
using RNS;

namespace RNS_Testing
{
    [TestClass]
    public class RNSTesting
    {
        [TestMethod]
        public void AdditionTest()
        {
            // arrange
            RNSCounter counterA = new RNSCounter();
            counterA.AddCounter(new Counter(7));
            counterA.AddCounter(new Counter(3));
            counterA.AddCounter(new Counter(5));
            counterA.Click(3); // 3 0 3

            RNSCounter counterB = new RNSCounter();
            counterB.AddCounter(new Counter(7));
            counterB.AddCounter(new Counter(3));
            counterB.AddCounter(new Counter(5));
            counterB.Click(6); // 6 0 1

            RNSCounter expected = new RNSCounter();
            expected.AddCounter(new Counter(7, 2));
            expected.AddCounter(new Counter(3, 0));
            expected.AddCounter(new Counter(5, 4));

            // act
            RNSCounter result = RNSMath.Add(counterA, counterB); // expect 2 0 4

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            // arrange
            RNSCounter counterA = new RNSCounter();
            counterA.AddCounter(new Counter(7));
            counterA.AddCounter(new Counter(3));
            counterA.AddCounter(new Counter(5));
            counterA.AddCounter(new Counter(2));
            counterA.Click(5); // 5 2 0 1

            RNSCounter counterB = new RNSCounter();
            counterB.AddCounter(new Counter(7));
            counterB.AddCounter(new Counter(3));
            counterB.AddCounter(new Counter(5));
            counterB.AddCounter(new Counter(2));
            counterB.Click(10); // 3 1 0 0

            RNSCounter expected = new RNSCounter();
            expected.AddCounter(new Counter(7, 2));
            expected.AddCounter(new Counter(3, 1));
            expected.AddCounter(new Counter(5, 0));
            expected.AddCounter(new Counter(2, 1));

            // act
            RNSCounter result = RNSMath.Subtract(counterA, counterB); // expect 2 1 0 1

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            // arrange
            RNSCounter counterA = new RNSCounter();
            counterA.AddCounter(new Counter(7));
            counterA.AddCounter(new Counter(3));
            counterA.AddCounter(new Counter(5));
            counterA.AddCounter(new Counter(2));
            counterA.Click(5); // 5 2 0 1

            RNSCounter counterB = new RNSCounter();
            counterB.AddCounter(new Counter(7));
            counterB.AddCounter(new Counter(3));
            counterB.AddCounter(new Counter(5));
            counterB.AddCounter(new Counter(2));
            counterB.Click(11); // 4 2 1 1

            RNSCounter expected = new RNSCounter();
            expected.AddCounter(new Counter(7, 6));
            expected.AddCounter(new Counter(3, 1));
            expected.AddCounter(new Counter(5, 0));
            expected.AddCounter(new Counter(2, 1));

            // act
            RNSCounter result = RNSMath.Multiply(counterA, counterB); // expect 6 1 0 1

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemovalTest()
        {
            // arrange
            RNSCounter result = new RNSCounter();
            result.AddCounter(new Counter(7));
            result.AddCounter(new Counter(3));
            result.AddCounter(new Counter(5));

            RNSCounter expected = new RNSCounter();
            expected.AddCounter(new Counter(3));
            expected.AddCounter(new Counter(5));

            // act
            result.RemoveCounter(1);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
