﻿namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines inverse assertions for the nullable <see cref="uint"/> data type.
    /// </summary>
    public struct NullableUintInverseValidator : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="NullableUintInverseValidator"/> type.
        /// </summary>
        /// <param name="value"> The nullable unsigned integer value to be validated. </param>
        public NullableUintInverseValidator(uint? value)
        {
            Context = new ValidationContext<uint?>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the context validator.
        /// </summary>
        private ValidationContext<uint?> Context { get; }

        /// <summary>
        /// Gets the nullable unsigned integer value to be validated.
        /// </summary>
        private uint? Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given nullable unsigned integer doese not equal another nullable unsigned integer.
        /// </summary>
        /// <param name="expected"> The expected value of a given nullable unsigned integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Be(uint? expected, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == expected)
            {
                var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be \"{expected}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable unsigned integer is not between (or equal to) a specified minimum and maximum value.
        /// </summary>
        /// <param name="minimum"> The allowed minimum value for the nullable unsigned integer. </param>
        /// <param name="maximum"> The allowed maximum value for the nullable unsigned integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeBetween(uint minimum, uint maximum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value >= minimum && Value <= maximum)
            {
                var context = Context.GetListCallerContext(testMethodName, new uint?[] { minimum, maximum }, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be between \"{minimum}\" and \"{maximum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable unsigned integer is not greater than a minimum value.
        /// </summary>
        /// <param name="minimum"> The allowed minimum value for the nullable unsigned integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeGreaterThan(uint minimum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value > minimum)
            {
                var context = Context.GetCallerContext(testMethodName, minimum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be greater than \"{minimum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable unsigned integer is not greater than or equal to a minimum value.
        /// </summary>
        /// <param name="minimum"> The allowed minimum value for the nullable unsigned integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeGreaterThanOrEqualTo(uint minimum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value >= minimum)
            {
                var context = Context.GetCallerContext(testMethodName, minimum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be greater than or equal to \"{minimum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable unsigned integer is not less than a maximum value.
        /// </summary>
        /// <param name="maximum"> The allowed maximum value for the nullable unsigned integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeLessThan(uint maximum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value < maximum)
            {
                var context = Context.GetCallerContext(testMethodName, maximum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be less than \"{maximum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable unsigned integer is not less than or equal to a maximum value.
        /// </summary>
        /// <param name="maximum"> The allowed maximum value for the nullable unsigned integer. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeLessThanOrEqualTo(uint maximum, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value <= maximum)
            {
                var context = Context.GetCallerContext(testMethodName, maximum, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be less than or equal to \"{maximum}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable unsigned integer is not null.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeNull(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value.HasValue == false)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, "is null", "not to be null", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable unsigned integer does not match one of the expected values.
        /// </summary>
        /// <param name="expectedValues"> A list of expected values. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeOneOf(IEnumerable<uint?> expectedValues, string because = null,
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