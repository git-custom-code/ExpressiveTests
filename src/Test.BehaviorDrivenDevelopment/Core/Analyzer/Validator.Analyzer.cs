namespace CustomCode.Test.BehaviorDrivenDevelopment.Analyzer
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xunit.Sdk;

    /// <summary>
    /// Define any number of assertions on the <see cref="Diagnostic"/>s of the <see cref="DiagnosticAnalyzer"/> under test.
    /// </summary>
    /// <typeparam name="T"> The type of the <see cref="DiagnosticAnalyzer"/> under test. </typeparam>
    public struct ValidatorForAnalyzer<T> : IFluentInterface
        where T : DiagnosticAnalyzer
    {
        #region Dependencies

        /// <summary>
        /// Create a new instance of the <see cref="ValidatorForAnalyzer{T}"/> type.
        /// </summary>
        /// <param name="arrange"> A delegate that creates the type under test. </param>
        /// <param name="codeFiles"> A collection that contains the code files that should be analyzed. </param>
        /// <param name="references"> A collection with references needed by the <paramref name="codeFiles"/>. </param>
        public ValidatorForAnalyzer(Func<T> arrange, IEnumerable<(string fileName, Func<string> code)> codeFiles, IEnumerable<Type> references)
        {
            Arrange = arrange ?? throw new XunitException($"The {nameof(arrange)} delegate cannot be null.");
            CodeFiles = codeFiles;
            References = references;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that creates the type under test.
        /// </summary>
        private Func<T> Arrange { get; }

        /// <summary>
        /// Gets a collection that contains the code files that should be analyzed.
        /// </summary>
        private IEnumerable<(string fileName, Func<string> code)> CodeFiles { get; }

        /// <summary>
        /// Gets a collection with references needed by the <see cref="CodeFiles"/>.
        /// </summary>
        private IEnumerable<Type> References { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Gets the source code files to be analyzed.
        /// </summary>
        /// <returns> The source code files to be analyzed. </returns>
        private IEnumerable<(string fileName, string code)> GetCodeFiles()
        {
            var codeFiles = new List<(string fileName, string code)>();
            var index = 0;

            foreach (var codeFile in CodeFiles)
            {
                var fileName = codeFile.fileName;
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = $"TestFile{index}.cs";
                    ++index;
                }

                if (!Path.HasExtension(".cs"))
                {
                    fileName = Path.ChangeExtension(fileName, "cs");
                }

                var code = string.Empty;
                if (codeFile.code == null)
                {
                    if (File.Exists(fileName))
                    {
                        code = File.ReadAllText(fileName);
                    }
                }
                else
                {
                    code = codeFile.code();
                }

                codeFiles.Add((fileName, code));
            }

            return codeFiles;
        }

        /// <summary>
        /// Gets the reference (assemblies) for the source code files to be analyzed.
        /// </summary>
        /// <returns> The reference (assemblies) for the source code files to be analyzed. </returns>
        private ISet<Assembly> GetReferences()
        {
            var references = new HashSet<Assembly>();
            foreach (var reference in References)
            {
                var assembly = reference.GetTypeInfo().Assembly;
                if (!references.Contains(assembly))
                {
                    references.Add(assembly);
                }
            }

            return references;
        }

        /// <summary>
        /// Define any number of assertions on the result of the method under test after it was
        /// successfully executed.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the result of the method under test.
        /// </param>
        public void Then(Action<IEnumerable<Diagnostic>> assert)
        {
            var validator = this;
            async Task ThenAsync()
            {
                try
                {
                    // given
                    var analyzerUnderTest = validator.Arrange();
                    var sources = validator.GetCodeFiles();
                    var references = validator.GetReferences();
                    var project = new DynamicProject(sources, references);
                    var verifier = new ProjectAnalyzer(project);

                    // when
                    var result = await verifier.AnalyzeAsync(analyzerUnderTest);

                    // then
                    assert(result);
                }
                catch (Exception e)
                {
                    // TODO
                    throw e;
                }
            };

            Task.WaitAll(Task.Run(ThenAsync));
        }

        #endregion
    }
}