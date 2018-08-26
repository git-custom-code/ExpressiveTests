namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines inverse assertions for <see cref="IEnumerable{T}"/> data types.
    /// </summary>
    public struct EnumerableInverseValidator<T> : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="EnumerableValidator{T}"/> type.
        /// </summary>
        /// <param name="value"> The eumerable to be validated. </param>
        public EnumerableInverseValidator(IEnumerable<T> value)
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
        /// Assert that an enumerable is not empty.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeEmpty(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() == 0)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"0\" item(s)", $"not to be empty", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable is not null.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeNull(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == null)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is null", $"not to be null", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable is not null or empty.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeNullOrEmpty(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == null || Value.Count() == 0)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is null or empty", $"not to be null or empty", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable hasn't more than a minimum number of items.
        /// </summary>
        /// <param name="expectedMinimumCount"> The expected minimum number of items. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountGreaterThan(uint expectedMinimumCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() > expectedMinimumCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"not to contain more than \"{expectedMinimumCount}\" item(s)", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable hasn't at least a minimum number of items.
        /// </summary>
        /// <param name="expectedMinimumCount"> The expected minimum number of items. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountGreaterThanOrEqualTo(uint expectedMinimumCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() >= expectedMinimumCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"not to contain more than or equal to \"{expectedMinimumCount}\" item(s)", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable hasn't less than a maximum number of items.
        /// </summary>
        /// <param name="expectedMaximumCount"> The expected maximum number of items. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountLessThan(uint expectedMaximumCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() < expectedMaximumCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"not to contain less than \"{expectedMaximumCount}\" item(s)", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable hasn't at most a maximum number of items.
        /// </summary>
        /// <param name="expectedMaximumCount"> The expected maximum number of items. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountLessThanOrEqualTo(uint expectedMaximumCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() <= expectedMaximumCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"not to contain less than or equal to \"{expectedMaximumCount}\" item(s)", because);
            }
        }

        /// <summary>
        /// Assert that an enumerable hasn't a specific number of items.
        /// </summary>
        /// <param name="expectedCount"> The expected number of items. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void HaveCountOf(uint expectedCount, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.Count() == expectedCount)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"contains \"{Value.Count()}\" item(s)", $"not to have \"{expectedCount}\" item(s)", because);
            }
        }

        #endregion
    }
}