namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines assertions for reference data types.
    /// </summary>
    public struct ReferenceTypeValidator<T> : IFluentInterface where T : class
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="ReferenceTypeValidator{T}"/> type.
        /// </summary>
        /// <param name="value"> The reference type to be validated. </param>
        public ReferenceTypeValidator(T value)
        {
            Context = new ValidationContext<T>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the validation context.
        /// </summary>
        private ValidationContext<T> Context { get; }

        /// <summary>
        /// Gets the reference type value to be validated.
        /// </summary>
        private T Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given reference type is null.
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

        #endregion
    }
}