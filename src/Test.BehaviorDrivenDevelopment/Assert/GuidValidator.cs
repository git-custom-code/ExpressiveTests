﻿namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines assertions for the <see cref="Guid"/> data type.
    /// </summary>
    public struct GuidValidator : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="GuidValidator"/> type.
        /// </summary>
        /// <param name="value"> The guid to be validated. </param>
        public GuidValidator(Guid value)
        {
            Context = new ValidationContext<Guid>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the context validator.
        /// </summary>
        private ValidationContext<Guid> Context { get; }

        /// <summary>
        /// Gets the guid to be validated.
        /// </summary>
        private Guid Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given guid equals another guid.
        /// </summary>
        /// <param name="expected"> The expected value of a given guid. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Be(Guid expected, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value != expected)
            {
                var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"to be \"{expected}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given guid is empty.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeEmpty(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value != Guid.Empty)
            {
                var context = Context.GetCallerContext(testMethodName, default(Guid), sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"to be empty", because);
            }
        }

        #endregion
    }
}