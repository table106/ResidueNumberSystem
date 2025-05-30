using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;

namespace RNS
{
    /// <summary>
    /// A Residual Number System (RNS) counter, composed of varying <c>BaseCounter</c>s.
    /// </summary>
    public class RNSCounter : IEnumerable<Counter>
    {
        public Dictionary<int, Counter> Counters { get; set; }
        public RNSCounter()
        {
            Counters = new Dictionary<int, Counter>();
        }
        /// <summary>
        /// Adds a single counter to the RNS counter.
        /// </summary>
        /// <param name="counter">The counter to be added.</param>
        public void AddCounter(Counter counter)
        {
            counter.Compute();
            Counters.Add(Counters.Count + 1, counter);
        }
        /// <summary>
        /// Removes a chosen counter from the RNS counter.
        /// </summary>
        /// <param name="id">ID of the counter to remove (starts at 1).</param>
        public void RemoveCounter(int id)
        {
            if (!Counters.ContainsKey(id)) { throw new KeyNotFoundException("Specified ID is not in counter dictionary"); }
            Counters.Remove(id);
            Dictionary<int, Counter> newdict = new Dictionary<int, Counter>();
            foreach (KeyValuePair<int, Counter> counter in Counters)
            {
                if (counter.Key < id) newdict.Add(counter.Key, counter.Value);
                else newdict.Add(counter.Key - 1, counter.Value);
            }
            Counters = newdict;
        }
        /// <summary>
        /// Calls <c>Counter.Click()</c> on all <c>Counter</c>s in the <c>RNSCounter</c>.
        /// </summary>
        public void Click(int n = 1)
        {
            foreach (Counter counter in Counters.Values) counter.Click(n);
        }

        public override string ToString()
        {
            string segments = "ID\t|\tvalue\n";
            string displayed = "";
            foreach (KeyValuePair<int, Counter> counter in Counters)
            {
                segments += counter.Key.ToString() + "\t|\t" + counter.Value.Count.ToString() + "\n";
                displayed += counter.Value.Count.ToString();
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
            if (!(obj is RNSCounter other) || other.Counters.Count != Counters.Count) return false;

            foreach (var pair in Counters)
            {
                if (pair.Value.Count != other.Counters[pair.Key].Count) { return false; }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public IEnumerator<Counter> GetEnumerator()
        {
            return Counters.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
