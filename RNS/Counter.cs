namespace RNS
{
    /// <summary>
    /// A singular counter.
    /// </summary>
    public class Counter
    {
        public int Base { get; }
        private int Count;
        public Counter(int counterBase, int value = 0)
        {
            Base = counterBase;
            Count = value;
            Compute();
        }

        /// <summary>
        /// Computes the <c>count</c> value.
        /// </summary>
        public void Compute()
        {
            while (Count >= Base)
            {
                Count -= Base;
            }
            while (Count < 0)
            {
                Count += Base;
            }
        }

        /// <summary>
        /// Increments and computes the counter's value.
        /// </summary>
        public void Click(int n = 1)
        {
            Count += n;
            Compute();
        }

        /// <summary>
        /// Sets the counter to a specified value.
        /// </summary>
        /// <param name="dest">Value to set the counter to.</param>
        /// <returns>The current value of the counter</returns>
        public void Set(int dest)
        {
            Count = dest;
        }

        /// <summary>
        /// Getter function for the <c>Count</c> property.
        /// </summary>
        /// <returns><c>Count</c> of the <c>Counter</c></returns>
        public int GetCount()
        {
            return Count;
        }

        public override string ToString()
        {
            return Count.ToString();
        }
    }
}
