namespace RNS
{
    /// <summary>
    /// A singular counter.
    /// </summary>
    public class Counter
    {
        public int Base { get; }
        private int _count;
        public int Count { get { return _count; }
            set
            {
                _count = value;
                Compute();
            }
        }
        public Counter(int counterBase, int value = 0)
        {
            Base = counterBase;
            _count = value;
            Compute();
        }
        /// <summary>
        /// Computes the <c>count</c> value.
        /// </summary>
        public void Compute()
        {
            while (_count >= Base)
            {
                _count -= Base;
            }
            while (_count < 0)
            {
                _count += Base;
            }
        }
        /// <summary>
        /// Increments and computes the counter's value.
        /// </summary>
        public void Click(int n = 1)
        {
            _count += n;
            Compute();
        }
        /// <summary>
        /// Sets the counter to a specified value.
        /// </summary>
        /// <param name="dest">Value to set the counter to.</param>
        /// <returns>The current value of the counter.</returns>
        public void Set(int dest)
        {
            _count = dest;
            Compute();
        }

        public override string ToString()
        {
            return _count.ToString();
        }
    }
}
