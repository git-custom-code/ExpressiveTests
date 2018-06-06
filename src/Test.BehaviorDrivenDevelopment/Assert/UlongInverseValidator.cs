namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines inverse assertions for the <see cref="ulong"/> data type.
    /// </summary>
    public struct UlongInverseValidator : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="UlongInverseValidator"/> type.
        /// </summary>
        /// <param name="value"> The unsigned long value to be validated. </param>
        public UlongInverseValidator(ulong value)
        {
            Context = new ValidationContext<ulong>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the context validator.
        /// </summary>
        private ValidationContext<ulong> Context { get; }

        /// <summary>
        /// Gets the unsigned long value to be validated.
        /// </summary>
        private ulong Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given unsigned long doese not equal another unsigned long.
        /// </summary>
        /// <param name="expected"> The expected value of a given unsigned long. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Be(ulong expected, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == expected)
            {
                var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be \"{expected}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given unsigned long is not between (or equal to) a specified minimum and maximum value.
        /// </summary>
        /// <param name="minimum"> The allowed minimum value for the unsigned long. </param>
        /// <param name="maximum"> The allowed maximum value for the unsigned long. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeBetween(ulong minimum, ulong maximum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value >= minimum && Value <= maximum)
            {
                var context = Context.GetListCallerContext(testMethodName, new[] { minimum, maximum }, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be between \"{minimum}\" and \"{maximum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given unsigned long is not greater than a minimum value.
        /// </summary>
        /// <param name="minimum"> The allowed minimum value for the unsigned long. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeGreaterThan(ulong minimum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value > minimum)
            {
                var context = Context.GetCallerContext(testMethodName, minimum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be greater than \"{minimum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given unsigned long is not greater than or equal to a minimum value.
        /// </summary>
        /// <param name="minimum"> The allowed minimum value for the unsigned long. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeGreaterThanOrEqualTo(ulong minimum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value >= minimum)
            {
                var context = Context.GetCallerContext(testMethodName, minimum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be greater than or equal to \"{minimum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given unsigned long is not less than a maximum value.
        /// </summary>
        /// <param name="maximum"> The allowed maximum value for the unsigned long. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeLessThan(ulong maximum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value < maximum)
            {
                var context = Context.GetCallerContext(testMethodName, maximum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be less than \"{maximum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given unsigned long is not less than or equal to a maximum value.
        /// </summary>
        /// <param name="maximum"> The allowed maximum value for the unsigned long. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeLessThanOrEqualTo(ulong maximum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value <= maximum)
            {
                var context = Context.GetCallerContext(testMethodName, maximum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be less than or equal to \"{maximum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given unsigned long does not match one of the expected values.
        /// </summary>
        /// <param name="expectedValues"> A list of expected values. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeOneOf(IEnumerable<ulong> expectedValues, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            var value = Value;
            if (expectedValues != null && expectedValues.Any(v => v == value))
            {
                var context = Context.GetCallerContext(testMethodName, 0, sourceCodePath, lineNumber);
                var expected = $"not to be one of the following values: \"{string.Join("\", \"", expectedValues)}\"";
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", expected, because);
            }
        }

        #endregion
    }
}