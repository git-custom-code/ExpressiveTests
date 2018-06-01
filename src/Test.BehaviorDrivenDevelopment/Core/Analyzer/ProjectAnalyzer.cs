namespace CustomCode.Test.BehaviorDrivenDevelopment.Analyzer
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A wrapper for a <see cref="DynamicProject"/> that can be used to execute a <see cref="DiagnosticAnalyzer"/> on
    /// the wrapped project.
    /// </summary>
    public sealed class ProjectAnalyzer
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="ProjectAnalyzer"/> type.
        /// </summary>
        /// <param name="project"> The project to be analyzed. </param>
        public ProjectAnalyzer(DynamicProject project)
        {
            Project = project;
        }

        /// <summary>
        /// Gets the project to be analyzed.
        /// </summary>
        private DynamicProject Project { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Analyze the source code of the wrapped <see cref="Project"/> using the specified <paramref name="analyzer"/>.
        /// </summary>
        /// <param name="analyzer"> The <see cref="DiagnosticAnalyzer"/> that should be executed. </param>
        /// <returns> A collection of <see cref="Diagnostic"/>s that was detected by the <paramref name="analyzer"/>. </returns>
        public async Task<IEnumerable<Diagnostic>> AnalyzeAsync(DiagnosticAnalyzer analyzer)
        {
            var sources = await Task.Run(() => Project.GetDocuments());
            return await GetSortedDiagnosticsFromDocumentsAsync(analyzer, sources);
        }

        /// <summary>
        /// Analyze a collection of <paramref name="documents"/> using the specified <paramref name="analyzer"/>.
        /// </summary>
        /// <param name="analyzer"> The <see cref="DiagnosticAnalyzer"/> that should be executed. </param>
        /// <param name="documents"> The <see cref="Document"/>s that should be analyzed. </param>
        /// <returns> A collection of <see cref="Diagnostic"/>s that was detected by the <paramref name="analyzer"/>. </returns>
        private async Task<IEnumerable<Diagnostic>> GetSortedDiagnosticsFromDocumentsAsync(
            DiagnosticAnalyzer analyzer, IEnumerable<Document> documents)
        {
            var projects = new HashSet<Project>();
            foreach (var document in documents)
            {
                projects.Add(document.Project);
            }

            var diagnostics = new List<Diagnostic>();
            foreach (var project in projects)
            {
                var compilation = await project.GetCompilationAsync();
                var compilationWithAnalyzers = compilation.WithAnalyzers(ImmutableArray.Create(analyzer));
                var diags = await compilationWithAnalyzers.GetAnalyzerDiagnosticsAsync();
                foreach (var diag in diags)
                {
                    if (diag.Location == Location.None || diag.Location.IsInMetadata)
                    {
                        diagnostics.Add(diag);
                    }
                    else
                    {
                        foreach (var document in documents)
                        {
                            var tree = await document.GetSyntaxTreeAsync();
                            if (tree == diag.Location.SourceTree)
                            {
                                diagnostics.Add(diag);
                            }
                        }
                    }
                }
            }

            var results = diagnostics.OrderBy(d => d.Location.SourceSpan.Start).ToArray();
            diagnostics.Clear();
            return results;
        }

        #endregion
    }
}