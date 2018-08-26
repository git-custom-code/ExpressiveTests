namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines assertions for <see cref="IEnumerable{T}"/> data types.
    /// </summary>
    public struct EnumerableValidator<T> : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="EnumerableValidator{T}"/> type.
        /// </summary>
        /// <param name="value"> The eumerable to be validated. </param>
        public EnumerableValidator(IEnumerable<T> value)
        {
            Context = new ValidationContext<IEnumerable<T>>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the context validator.
        /// </summary>
        private ValidationContext<IEnumerable<T>> Context { get; }

        /// <summary>
        /// Gets the enumerable to be validated.
        /// </summary>
        private IEnumerable<T> Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that an enumerable is empty.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeEmpty(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() != 0)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"to be empty", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable is null.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeNull(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value != null)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"to be null", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable is null or empty.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeNullOrEmpty(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value != null && Value.Count() != 0)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"to be null or empty", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable has more than a minimum number of item(s).
        /// </summary>
        /// <param name="expectedMinimumCount"> The expected minimum number of item(s). </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountGreaterThan(uint expectedMinimumCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() <= expectedMinimumCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"to contain more than \"{expectedMinimumCount}\" item(s)", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable has at least a minimum number of item(s).
        /// </summary>
        /// <param name="expectedMinimumCount"> The expected minimum number of item(s). </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountGreaterThanOrEqualTo(uint expectedMinimumCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() < expectedMinimumCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"to contain at least \"{expectedMinimumCount}\" item(s)", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable has less than a maximum number of item(s).
        /// </summary>
        /// <param name="expectedMaximumCount"> The expected maximum number of item(s). </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountLessThan(uint expectedMaximumCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() >= expectedMaximumCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"to contain less than \"{expectedMaximumCount}\" item(s)", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable has at most a maximum number of item(s).
        /// </summary>
        /// <param name="expectedMaximumCount"> The expected maximum number of item(s). </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountLessThanOrEqualTo(uint expectedMaximumCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() > expectedMaximumCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"to contain at most \"{expectedMaximumCount}\" item(s)", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable has a specific number of item(s).
        /// </summary>
        /// <param name="expectedCount"> The expected number of item(s). </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountOf(uint expectedCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() != expectedCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"to have \"{expectedCount}\" item(s)", because);
            }
        }

        #endregion
    }
}