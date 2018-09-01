namespace CustomCode.Test.BehaviorDrivenDevelopment.Synchronization
{
    using System.Collections.Concurrent;
    using System.Threading;

    /// <summary>
    /// A static cache that can be used to read or write key/value pairs
    /// as singleton per logical call context (i.e. per asynchronous callstack).
    /// </summary>
    /// <typeparam name="T"> The type of the cached value. </typeparam>
    internal static class AmbientCache<T>
    {
        #region Data

        /// <summary>
        /// Gets the internal thread-safe ambient data cache.
        /// </summary>
        private static ConcurrentDictionary<string, AsyncLocal<T>> Cache { get; } = new ConcurrentDictionary<string, AsyncLocal<T>>();

        #endregion

        #region Logic

        /// <summary>
        /// Gets the cached value with the specified <paramref name="key"/> for
        /// the current logical context.
        /// </summary>
        /// <param name="key"> The unique key of the value to be retrieved. </param>
        /// <returns>
        /// The cached value for the current logical context or null if the default value
        /// if no such value was found.
        /// </returns>
        internal static T Get(string key)
        {
            if (Cache.TryGetValue(key, out var entry))
            {
                return entry.Value;
            }
            return default(T);
        }

        /// <summary>
        /// Sets or updates the <paramref name="value"/> of the specified <paramref name="key"/>
        /// for the current logical context.
        /// </summary>
        /// <param name="key"> The unique key of the value to be stored. </param>
        /// <param name="value"> The value to be stored. </param>
        internal static void Set(string key, T value)
        {
            var entry = Cache.GetOrAdd(key, _ => new AsyncLocal<T>());
            entry.Value = value;
        }

        #endregion
    }
}