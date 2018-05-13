namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines assertions for <see cref="System.Enum"/> data types.
    /// </summary>
    /// <typeparam name="T"> The type of the enumeration value. </typeparam>
    public struct EnumValidator<T> : IFluentInterface
        where T : System.Enum
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="EnumValidator{T}"/> type.
        /// </summary>
        /// <param name="value"> The enumeration value to be validated. </param>
        public EnumValidator(T value)
        {
            Context = new ValidationContext<T>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the context validator.
        /// </summary>
        private ValidationContext<T> Context { get; }

        /// <summary>
        /// Gets the enumeration value to be validated.
        /// </summary>
        private T Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given enumeration value equals another enumeration value.
        /// </summary>
        /// <param name="expected"> The expected value of a given enumeration. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Be(T expected, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (!Equals(Value, expected))
            {
                var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"to be \"{expected}\"", because);
            }
        }
        
        #endregion
    }
}