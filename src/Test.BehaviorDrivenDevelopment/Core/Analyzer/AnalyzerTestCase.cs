namespace CustomCode.Test.BehaviorDrivenDevelopment.Analyzer
{
    using Microsoft.CodeAnalysis.Diagnostics;
    using System;

    /// <summary>
    /// Base class that can be used for <see cref="DiagnosticAnalyzer"/> unit-, integration-
    /// or smoketests to allow a "given-when-then" style fluent api.
    /// </summary>
    public abstract class AnalyzerTestCase
    {
        #region Logic

        /// <summary>
        /// Creates a new instance of a <see cref="DiagnosticAnalyzer"/> of type
        /// <typeparamref name="T"/> (to be tested).
        /// </summary>
        /// <typeparam name="T"> The analyzer type under test. </typeparam>
        /// <returns>
        /// An <see cref="ExecutorForAnalyzer{T}"/> that can be used to test the <see cref="DiagnosticAnalyzer"/>
        /// of type <typeparamref name="T"/>.
        /// </returns>
        public ExecutorForAnalyzer<T> Given<T>()
            where T : DiagnosticAnalyzer, new()
        {
            return Given(() => new T());
        }

        /// <summary>
        /// Creates a new instance of a <see cref="DiagnosticAnalyzer"/> of type
        /// <typeparamref name="T"/> (to be tested).
        /// </summary>
        /// <typeparam name="T"> The analyzer type under test. </typeparam>
        /// <param name="arrange"> A delegate that creates the analyzer type under test. </param>
        /// <returns>
        /// An <see cref="ExecutorForAnalyzer{T}"/> that can be used to test the <see cref="DiagnosticAnalyzer"/>
        /// of type <typeparamref name="T"/>.
        /// </returns>
        public ExecutorForAnalyzer<T> Given<T>(Func<T> arrange)
            where T : DiagnosticAnalyzer
        {
            return new ExecutorForAnalyzer<T>(arrange);
        }

        #endregion
    }
}