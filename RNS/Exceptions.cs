using System;

namespace RNS
{
    /// <summary>
    /// Represents a <c>Counter</c> <c>base</c> property mismatch in comparison.
    /// </summary>
    public class CounterBaseMismatchException : Exception
    {
        public CounterBaseMismatchException() { }
        public CounterBaseMismatchException(string message) : base(message) { }
        public CounterBaseMismatchException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// Represents a mismatch of the <c>Counter</c>s amount present in an <c>RNSCounter</c>.
    /// </summary>
    public class RNSCounterAmountDifferenceException : Exception
    {
        public RNSCounterAmountDifferenceException() { }
        public RNSCounterAmountDifferenceException(string message) : base(message) { }
        public RNSCounterAmountDifferenceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
