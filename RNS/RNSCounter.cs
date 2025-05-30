using System.Collections.Generic;

namespace RNS
{
    /// <summary>
    /// A Residual Number System (RNS) counter, composed of varying <c>BaseCounter</c>s.
    /// </summary>
    public class RNSCounter
    {
        private Dictionary<int, BaseCounter> counters;
        public Dictionary<int, BaseCounter> Counters { get { return counters; } }
        public RNSCounter()
        {
            counters = new Dictionary<int, BaseCounter>();
        }
        /// <summary>
        /// Adds a single counter to the RNS counter.
        /// </summary>
        /// <param name="counter">The counter to be added.</param>
        public void AddCounter(BaseCounter counter)
        {
            counter.Compute();
            counters.Add(counters.Count + 1, counter);
        }
        /// <summary>
        /// Removes a chosen counter from the RNS counter.
        /// </summary>
        /// <param name="id">ID of the counter to remove (starts at 1).</param>
        public void RemoveCounter(int id)
        {
            if (!counters.ContainsKey(id)) { throw new KeyNotFoundException("Specified ID is not in counter dictionary"); }
            counters.Remove(id);
            Dictionary<int, BaseCounter> newdict = new Dictionary<int, BaseCounter>();
            foreach (KeyValuePair<int, BaseCounter> counter in counters)
            {
                if (counter.Key < id) { newdict.Add(counter.Key, counter.Value); }
                else { newdict.Add(counter.Key - 1, counter.Value); }
            }
            counters = newdict;
        }
        /// <summary>
        /// Calls <c>BaseCounter.Click()</c> on all <c>BaseCounter</c>s in the <c>RNSCounter</c>.
        /// </summary>
        public void Click(int n = 1)
        {
            foreach (BaseCounter counter in counters.Values)
            {
                counter.Click(n);
            }
        }

        public override string ToString()
        {
            string segments = "ID\t|\tvalue\n";
            string displayed = "";
            foreach (KeyValuePair<int, BaseCounter> counter in counters)
            {
                segments += counter.Key.ToString() + "\t|\t" + counter.Value.Count.ToString() + "\n";
                displayed += counter.Value.Count.ToString();
            }
            return segments + "display: " + displayed + "\n";
        }

        public BaseCounter this[int n]
        {
            get { return counters[n]; }
            set { counters[n] = value; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RNSCounter other) || other.Counters.Count != Counters.Count) return false;

            foreach (var pair in counters)
            {
                if (pair.Value.Count != other.Counters[pair.Key].Count) { return false; }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
