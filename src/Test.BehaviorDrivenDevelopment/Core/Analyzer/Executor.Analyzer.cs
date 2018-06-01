namespace CustomCode.Test.BehaviorDrivenDevelopment.Analyzer
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;
    using System;
    using System.Collections.Generic;
    using Xunit.Sdk;

    /// <summary>
    /// Executes the <see cref="DiagnosticAnalyzer"/> instance of type <typeparamref name="T"/>
    /// for a given set of code files.
    /// </summary>
    /// <typeparam name="T"> The type of the <see cref="DiagnosticAnalyzer"/> under test. </typeparam>
    public struct ExecutorForAnalyzer<T> : IFluentInterface
        where T : DiagnosticAnalyzer
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="ExecutorForAnalyzer{T}"/> type.
        /// </summary>
        /// <param name="arrange"> A delegate that creates the analyzer under test. </param>
        public ExecutorForAnalyzer(Func<T> arrange)
        {
            Arrange = arrange ?? throw new XunitException($"{Environment.NewLine}The {nameof(arrange)} delegate cannot be null");
            CodeFiles = new List<(string fileName, Func<string> code)>();
            References = new List<Type>();
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that creates the analyzer under test.
        /// </summary>
        private Func<T> Arrange { get; }

        /// <summary>
        /// Gets a collection that contains the code files that should be analyzed.
        /// </summary>
        private List<(string fileName, Func<string> code)> CodeFiles { get; }

        /// <summary>
        /// Gets a collection that contains the references for the code files that should be analyzed.
        /// </summary>
        private List<Type> References { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Add a new dynamic (c#) code file for the analyzer.
        /// </summary>
        /// <param name="code"> The (c#) source code to be analyzed. </param>
        /// <param name="fileName"> An optional file name/identifier for the dynamic code file. </param>
        /// <returns>
        /// An <see cref="ExecutorForAnalyzer{T}"/> that can be used to execute the <see cref="DiagnosticAnalyzer"/>
        /// instance of type <typeparamref name="T"/> for a given set of code files.
        /// </returns>
        public ExecutorForAnalyzer<T> With(string code, string fileName = null)
        {
            CodeFiles.Add((fileName, () => code));
            return this;
        }

        /// <summary>
        /// Add a new (dynamic c#) code file for the analyzer.
        /// </summary>
        /// <param name="code"> A delegate that creates/loads the (c#) source code file to be analyzed. </param>
        /// <param name="fileName"> An optional file name/identifier for the dynamic code file. </param>
        /// <returns>
        /// An <see cref="ExecutorForAnalyzer{T}"/> that can be used to execute the <see cref="DiagnosticAnalyzer"/>
        /// instance of type <typeparamref name="T"/> for a given set of code files.
        /// </returns>
        public ExecutorForAnalyzer<T> With(Func<string> code, string fileName = null)
        {
            CodeFiles.Add((fileName, code));
            return this;
        }

        /// <summary>
        /// Add a new persisted (c#) code file for the analyzer.
        /// </summary>
        /// <param name="filePath"> The path to the persiseted c# code file. </param>
        /// <returns>
        /// An <see cref="ExecutorForAnalyzer{T}"/> that can be used to execute the <see cref="DiagnosticAnalyzer"/>
        /// instance of type <typeparamref name="T"/> for a given set of code files.
        /// </returns>
        public ExecutorForAnalyzer<T> With(string filePath)
        {
            CodeFiles.Add((filePath, null));
            return this;
        }

        /// <summary>
        /// Add a reference to the assembly that contains the type <typeparamref name="TType"/> for
        /// dynamic project that should be analyzed.
        /// </summary>
        /// <typeparam name="TType"> A type whose assembly should be added. </typeparam>
        /// <returns>
        /// An <see cref="ExecutorForAnalyzer{T}"/> that can be used to execute the <see cref="DiagnosticAnalyzer"/>
        /// instance of type <typeparamref name="T"/> for a given set of code files.
        /// </returns>
        public ExecutorForAnalyzer<T> UsingAssembly<TType>()
        {
            References.Add(typeof(TType));
            return this;
        }

        /// <summary>
        /// Define the asynchronous (non-void) method under test via the <paramref name="actAsync"/> delegate.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidatorForAnalyzer{T}"/> that can be used to execute any number of
        /// assertions on the analyzer's <see cref="Diagnostic"/>s.
        /// </returns>
        public ValidatorForAnalyzer<T> WhenAnalyzed()
        {
            return new ValidatorForAnalyzer<T>(Arrange, CodeFiles, References);
        }

        #endregion
    }
}