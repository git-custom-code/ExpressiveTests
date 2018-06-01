namespace CustomCode.Test.BehaviorDrivenDevelopment.Analyzer
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Text;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// An in-memory roslyn project from dynamic c# source code files.
    /// </summary>
    public sealed class DynamicProject
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="DynamicProject"/> type.
        /// </summary>
        /// <param name="sources"> The project's source code files. </param>
        /// <param name="references"> The project's references. </param>
        public DynamicProject(IEnumerable<(string fileName, string code)> sources, ISet<Assembly> references)
        {
            Project = new Lazy<Project>(CreateProject, true);
            References = references;
            Sources = sources;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the interal in-memory roslyn project.
        /// </summary>
        private Lazy<Project> Project { get; }

        /// <summary>
        /// Gets the project's references.
        /// </summary>
        private ISet<Assembly> References { get; }

        /// <summary>
        /// Gets the project's source code files.
        /// </summary>
        private IEnumerable<(string fileName, string code)> Sources { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Create a dynamic in-memory project from the given <see cref="Sources"/> and <see cref="References"/>.
        /// </summary>
        /// <returns> A dynamic in-memory project from the given <see cref="Sources"/> and <see cref="References"/>. </returns>
        private Project CreateProject()
        {
            var testProjectName = "TestProject";
            var projectId = ProjectId.CreateNewId(debugName: testProjectName);

            var solution = new AdhocWorkspace()
                .CurrentSolution
                .AddProject(projectId, testProjectName, testProjectName, LanguageNames.CSharp)
                .AddMetadataReference(projectId, MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location))
                .AddMetadataReference(projectId, MetadataReference.CreateFromFile(typeof(Enumerable).GetTypeInfo().Assembly.Location))
                .AddMetadataReference(projectId, MetadataReference.CreateFromFile(typeof(CSharpCompilation).GetTypeInfo().Assembly.Location))
                .AddMetadataReference(projectId, MetadataReference.CreateFromFile(typeof(Compilation).GetTypeInfo().Assembly.Location));

            foreach (var reference in References)
            {
                solution = solution.AddMetadataReference(projectId, MetadataReference.CreateFromFile(reference.Location));
            }

            foreach (var source in Sources)
            {
                var documentId = DocumentId.CreateNewId(projectId, debugName: source.fileName);
                solution = solution.AddDocument(documentId, source.fileName, SourceText.From(source.code));
            }

            return solution.GetProject(projectId);
        }

        /// <summary>
        /// Creates and returns the in-memory projects <see cref="Document"/>s.
        /// </summary>
        /// <returns> The in-memory projects <see cref="Document"/>s. </returns>
        public IEnumerable<Document> GetDocuments()
        {
            var documents = Project.Value.Documents.ToArray();

            if (Sources.Count() != documents.Length)
            {
                throw new InvalidOperationException("Amount of sources did not match amount of Documents created");
            }

            return documents;
        }

        #endregion
    }
}