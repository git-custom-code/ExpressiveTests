namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines assertions for <see cref="object"/> data types.
    /// </summary>
    public struct ObjectValidator : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="ObjectValidator"/> type.
        /// </summary>
        /// <param name="value"> The object to be validated. </param>
        public ObjectValidator(object value)
        {
            Context = new ValidationContext<object>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the validation context.
        /// </summary>
        private ValidationContext<object> Context { get; }

        /// <summary>
        /// Gets the object value to be validated.
        /// </summary>
        private object Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given object is null.
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
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"to be null", because);
            }
        }

        /// <summary>
        /// Assert that a given object is of the specified type.
        /// </summary>
        /// <typeparam name="T"> The object's expected type. </typeparam>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeOfType<T>(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value?.GetType() != typeof(T))
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value?.GetType()?.Name ?? "undefined"}\"", $"to be of type \"{typeof(T).Name}\"", because);
            }
        }

        #endregion
    }
}