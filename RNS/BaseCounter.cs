namespace RNS
{
    /// <summary>
    /// A singular counter.
    /// </summary>
    public class BaseCounter
    {
        private readonly int counterBase;
        public int Base { get { return counterBase; } }
        private int count;
        public int Count { get { return count; } }
        public BaseCounter(int counterBase, int value = 0)
        {
            this.counterBase = counterBase;
            count = value;
            Compute();
        }
        /// <summary>
        /// Computes the <c>count</c> value.
        /// </summary>
        public void Compute()
        {
            while (count >= counterBase)
            {
                count -= counterBase;
            }
            while (count < 0)
            {
                count += counterBase;
            }
        }
        /// <summary>
        /// Increments and computes the counter's value.
        /// </summary>
        public void Click(int n = 1)
        {
            count += n;
            Compute();
        }
        /// <summary>
        /// Sets the counter to a specified value.
        /// </summary>
        /// <param name="dest">Value to set the counter to.</param>
        /// <returns>The current value of the counter.</returns>
        public void Set(int dest)
        {
            count = dest;
            Compute();
        }

        public override string ToString()
        {
            return count.ToString();
        }
    }
}
