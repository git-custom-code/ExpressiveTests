namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines inverse assertions for the <see cref="int"/> data type.
    /// </summary>
    public struct IntInverseValidator : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="IntValidator"/> type.
        /// </summary>
        /// <param name="value"> The integer value to be validated. </param>
        public IntInverseValidator(int value)
        {
            Context = new ValidationContext<int>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the context validator.
        /// </summary>
        private ValidationContext<int> Context { get; }

        /// <summary>
        /// Gets the integer value to be validated.
        /// </summary>
        private int Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given integer doese not equal another integer.
        /// </summary>
        /// <param name="expected"> The expected value of a given integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Be(int expected, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == expected)
            {
                var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be \"{expected}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given integer is not between (or equal to) a specified minimum and maximum value.
        /// </summary>
        /// <param name="minimum"> The allowed minimum value for the integer. </param>
        /// <param name="maximum"> The allowed maximum value for the integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeBetween(int minimum, int maximum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value >= minimum && Value <= maximum)
            {
                var context = Context.GetListCallerContext(testMethodName, new[] { minimum, maximum }, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be between \"{minimum}\" and \"{maximum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given integer is not greater than a minimum value.
        /// </summary>
        /// <param name="minimum"> The allowed minimum value for the integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeGreaterThan(int minimum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value > minimum)
            {
                var context = Context.GetCallerContext(testMethodName, minimum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be greater than \"{minimum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given integer is not greater than or equal to a minimum value.
        /// </summary>
        /// <param name="minimum"> The allowed minimum value for the integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeGreaterThanOrEqualTo(int minimum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value >= minimum)
            {
                var context = Context.GetCallerContext(testMethodName, minimum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be greater than or equal to \"{minimum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given integer is not less than a maximum value.
        /// </summary>
        /// <param name="maximum"> The allowed maximum value for the integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeLessThan(int maximum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value < maximum)
            {
                var context = Context.GetCallerContext(testMethodName, maximum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be less than \"{maximum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given integer is not less than or equal to a maximum value.
        /// </summary>
        /// <param name="maximum"> The allowed maximum value for the integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeLessThanOrEqualTo(int maximum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value <= maximum)
            {
                var context = Context.GetCallerContext(testMethodName, maximum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be less than or equal to \"{maximum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given integer does not have a negative value (less than zero).
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeNegative(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value < 0)
            {
                var context = Context.GetCallerContext(testMethodName, 0, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to have a negative value", because);
            }
        }

        /// <summary>
        /// Assert that a given integer does not have a positive value (greater than or equal to zero).
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BePositive(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value >= 0)
            {
                var context = Context.GetCallerContext(testMethodName, 0, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to have a positive value", because);
            }
        }

        #endregion
    }
}