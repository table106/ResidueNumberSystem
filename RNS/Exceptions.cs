using System;

namespace RNS
{
    public class CounterBaseMismatchException : Exception
    {
        public CounterBaseMismatchException() { }
        public CounterBaseMismatchException(string message) : base(message) { }
        public CounterBaseMismatchException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class RNSCounterAmountDifferenceException : Exception
    {
        public RNSCounterAmountDifferenceException() { }
        public RNSCounterAmountDifferenceException(string message) : base(message) { }
        public RNSCounterAmountDifferenceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
