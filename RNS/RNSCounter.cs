using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Text;

namespace RNS
{
    /// <summary>
    /// A Residual Number System (RNS) counter, composed of <c>Counter</c>s with varying bases.
    /// </summary>
    public class RNSCounter : IEnumerable<Counter>
    {
        public List<Counter> Counters { get; set; }

        public RNSCounter()
        {
            Counters = new List<Counter>();
        }

        /// <summary>
        /// Adds a single <c>Counter</c> to the <c>RNSCounter</c>.
        /// </summary>
        /// <param name="counter">The <c>Counter</c> to be added.</param>
        public void AddCounter(Counter counter)
        {
            counter.Compute();
            Counters.Add(counter);
        }

        /// <summary>
        /// Removes a specified <c>Counter</c> from the <c>RNSCounter</c>.
        /// </summary>
        /// <param name="index">ID of the <c>Counter</c> to remove (starts at 1).</param>
        public void RemoveCounter(int index)
        {
            Counters.RemoveAt(index);
        }

        /// <summary>
        /// Calls <c>Counter.Click()</c> on all <c>Counter</c>s in the <c>RNSCounter</c>.
        /// </summary>
        /// <param name="n">Clicks to perform. Defaults to 1</param>
        public void Click(int n = 1)
        {
            foreach (Counter counter in Counters) counter.Click(n);
        }

        public override string ToString()
        {
            StringBuilder segments = new StringBuilder();
            StringBuilder displayed = new StringBuilder();
            segments.AppendLine("ID\t|\tvalue");
            foreach (Counter counter in Counters)
            {
                segments.AppendLine(Counters.IndexOf(counter) + 1.ToString() + "\t|\t" + counter.GetCount().ToString());
                displayed.Append(counter.GetCount().ToString());
            }
            return segments + "display: " + displayed + "\n";
        }

        public Counter this[int n]
        {
            get { return Counters[n]; }
            set { Counters[n] = value; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RNSCounter other) || other.Counters.Count != this.Counters.Count) return false;

            foreach (Counter counter in Counters)
            {
                if (counter.GetCount() != other.Counters[Counters.IndexOf(counter)].GetCount()) { return false; }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public IEnumerator<Counter> GetEnumerator()
        {
            return Counters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
