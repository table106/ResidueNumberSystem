using System;
using System.Linq;

namespace RNS
{
    public class RNSMath
    {
        /// <summary>
        /// Adds two <c>RNSCounter</c>s together.
        /// </summary>
        /// <param name="counter1">First RNS counter to be added.</param>
        /// <param name="counter2">Second RNS counter to be added.</param>
        /// <returns>Sum of the addition.</returns>
        /// <exception cref="CounterBaseMismatchException">Thrown upon mismatch of the two <c>RNSCounter</c>'s bases of digits.</exception>
        /// <exception cref="RNSCounterAmountDifferenceException">Thrown upon mismatch of <c>RNSCounter</c>'s <c>BaseCounter</c> number.</exception>
        public static RNSCounter Add(RNSCounter counter1, RNSCounter counter2)
        {
            RNSCounter res = new RNSCounter();
            if (counter1.Counters.Count != counter2.Counters.Count) { throw new RNSCounterAmountDifferenceException("RNSCounter BaseCounter amount cannot differ"); }
            foreach (var counter in counter1.Counters.Zip(counter2.Counters, (one, two) => new { digit1 = one, digit2 = two }))
            {
                if (counter.digit1.Value.Base != counter.digit2.Value.Base) { throw new CounterBaseMismatchException("RNSCounter's BaseCounter bases must be identical to use RNSMath.Add"); }
                res.AddCounter(new BaseCounter(counter.digit1.Value.Base, counter.digit1.Value.Count + counter.digit2.Value.Count));
            }
            return res;
        }

        /// <summary>
        /// Subtracts two <c>RNSCounter</c>s from each other.
        /// </summary>
        /// <param name="counter1">First <c>RNSCounter</c>, the minuend.</param>
        /// <param name="counter2">Second <c>RNSCounter</c>, the subtrahend.</param>
        /// <returns>Difference of the subtraction.</returns>
        /// <exception cref="RNSCounterAmountDifferenceException">Thrown upon mismatch of <c>RNSCounter</c>'s <c>BaseCounter</c> number.</exception>
        /// <exception cref="CounterBaseMismatchException">Thrown upon mismatch of the two <c>RNSCounter</c>'s bases of digits</exception>
        public static RNSCounter Subtract(RNSCounter counter1, RNSCounter counter2)
        {
            RNSCounter res = new RNSCounter();
            if (counter1.Counters.Count != counter2.Counters.Count) { throw new RNSCounterAmountDifferenceException("RNSCounter BaseCounter amount cannot differ"); }
            foreach (var counter in counter1.Counters.Zip(counter2.Counters, (one, two) => new { digit1 = one, digit2 = two }))
            {
                if (counter.digit1.Value.Base != counter.digit2.Value.Base) { throw new CounterBaseMismatchException("RNSCounter's BaseCounter bases must be identical to use RNSMath.Subtract"); }
                res.AddCounter(new BaseCounter(counter.digit1.Value.Base, counter.digit1.Value.Count - counter.digit2.Value.Count));
            }
            return res;
        }

        /// <summary>
        /// Multiplies two <c>RNSCounter</c>s.
        /// </summary>
        /// <param name="counter1">First <c>RNSCounter</c> to multiply.</param>
        /// <param name="counter2">Second <c>RNSCounter</c> to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        /// <exception cref="RNSCounterAmountDifferenceException">Thrown upon mismatch of <c>RNSCounter</c>'s <c>BaseCounter</c> number.</exception>
        /// <exception cref="CounterBaseMismatchException">Thrown upon mismatch of the two <c>RNSCounter</c>'s bases of digits</exception>
        public static RNSCounter Multiply(RNSCounter counter1, RNSCounter counter2)
        {
            RNSCounter res = new RNSCounter();
            if (counter1.Counters.Count != counter2.Counters.Count) { throw new RNSCounterAmountDifferenceException("RNSCounter BaseCounter amount cannot differ"); }
            foreach (var counter in counter1.Counters.Zip(counter2.Counters, (one, two) => new { digit1 = one, digit2 = two }))
            {
                if (counter.digit1.Value.Base != counter.digit2.Value.Base) { throw new CounterBaseMismatchException("RNSCounter's BaseCounter bases must be identical to use RNSMath.Subtract"); }
                res.AddCounter(new BaseCounter(counter.digit1.Value.Base, counter.digit1.Value.Count * counter.digit2.Value.Count));
            }
            return res;
        }

        /// <summary>
        /// Divides two <c>RNSCounter</c>s by each other.
        /// </summary>
        /// <param name="counter1">First <c>RNSCounter</c> to divide by.</param>
        /// <param name="counter2">Second <c>RNSCounter</c> to divide by.</param>
        /// <returns>Quotient of the division.</returns>
        /// <exception cref="RNSCounterAmountDifferenceException">Thrown upon mismatch of <c>RNSCounter</c>'s <c>BaseCounter</c> number.</exception>
        /// <exception cref="CounterBaseMismatchException">Thrown </exception>
        /// <exception cref="DivideByZeroException"></exception>
        public static RNSCounter Divide(RNSCounter counter1, RNSCounter counter2)
        {
            RNSCounter res = new RNSCounter();
            if (counter1.Counters.Count != counter2.Counters.Count) { throw new RNSCounterAmountDifferenceException("RNSCounter BaseCounter amount cannot differ"); }
            foreach (var counter in counter1.Counters.Zip(counter2.Counters, (one, two) => new { digit1 = one, digit2 = two }))
            {
                if (counter.digit1.Value.Base != counter.digit2.Value.Base) { throw new CounterBaseMismatchException("RNSCounter's BaseCounter bases must be identical to use RNSMath.Subtract"); }
                if (counter.digit2.Value.Count == 0) { throw new DivideByZeroException("Second counter digit cannot be 0"); }
                res.AddCounter(new BaseCounter(counter.digit1.Value.Base, counter.digit1.Value.Count / counter.digit2.Value.Count));
            }
            return res;
        }
    }
}
