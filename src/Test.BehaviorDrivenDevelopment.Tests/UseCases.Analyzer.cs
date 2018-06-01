namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using Analyzer;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using System.Collections.Immutable;
    using Xunit;

    public sealed class UseCasesForAnalyzer : AnalyzerTestCase
    {
        #region Foo

        public sealed class FooAnalyzer : DiagnosticAnalyzer
        {
            public FooAnalyzer()
            {
                Rule = new DiagnosticDescriptor(
                    id: "FOO4711",
                    title: "Title",
                    messageFormat: "MessageFormat",
                    category: "Category",
                    defaultSeverity: DiagnosticSeverity.Warning,
                    isEnabledByDefault: true);
                SupportedDiagnostics = ImmutableArray.Create(Rule);
            }

            private DiagnosticDescriptor Rule { get; }

            public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; }

            public override void Initialize(AnalysisContext context)
            {
                context.RegisterSyntaxNodeAction(AnalyzeClassDeclaration, new[] { SyntaxKind.ClassDeclaration });
            }

            private void AnalyzeClassDeclaration(SyntaxNodeAnalysisContext context)
            {
                var classNode = context.Node as ClassDeclarationSyntax;
                var symbol = context.SemanticModel.GetDeclaredSymbol(classNode);
                if (symbol.Name == "Foo")
                {
                    var diagnostic = Diagnostic.Create(Rule, classNode.GetLocation());
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }

        #endregion

        [Fact(DisplayName = "Analyzer with single code file and diagnostic results")]
        [UnitTest]
        public void AnalyzerWithSingleCodeFileAndDiagnosticResults()
        {
            Given<FooAnalyzer>()
            .With("public sealed class Foo { }", "Foo.cs")
            .WhenAnalyzed()
            .Then(diagnostics =>
                {
                });
        }

        [Fact(DisplayName = "Analyzer with single code file but without diagnostic results")]
        [UnitTest]
        public void AnalyzerWithSingleCodeFileButWithoutDiagnosticResults()
        {
            Given<FooAnalyzer>()
            .With("public sealed class Bar { }", "Bar.cs")
            .WhenAnalyzed()
            .Then(diagnostics =>
                {
                });
        }
    }
}