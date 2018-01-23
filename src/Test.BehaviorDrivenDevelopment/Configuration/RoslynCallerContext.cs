namespace CustomCode.Test.BehaviorDrivenDevelopment.Configuration
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Text;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Basic implementation of the <see cref="ICallerContext"/> interface that uses roslyn to parse
    /// source code files in order to obtain information about the type (name) and property (name) that
    /// was used to call a validation extension method on.
    /// </summary>
    public sealed class RoslynCallerContext : ICallerContext
    {
        #region Logic

        /// <summary>
        /// Gets the caller context for a given validation method.
        /// </summary>
        /// <param name="expected"> The expected value specified as validation method parameter. </param>
        /// <param name="testMethodName">
        /// The name of the test method that contains the call to the validation method.
        /// </param>
        /// <param name="validationMethodName"> The name of the called validation method. </param>
        /// <param name="lineNumber"> The line number that contains the call to the validation method. </param>
        /// <param name="sourceCodePath">
        /// The path to the source code file that contains the call to the validation method.
        /// </param>
        /// <returns> The parsed caller context or null. </returns>
        public string GetCallerContext<T>(T expected, string testMethodName, string validationMethodName,
            int lineNumber, string sourceCodePath)
        {
            using (var sourceCode = File.OpenRead(sourceCodePath))
            {
                var syntaxTree = CSharpSyntaxTree.ParseText(
                    SourceText.From(sourceCode),
                    path: sourceCodePath);
                var root = syntaxTree.GetRoot();
                var lineSpanWithValidatorCall = syntaxTree
                    .GetText()
                    .Lines
                    .SingleOrDefault(l => l.LineNumber == lineNumber - 1)
                    .Span;
                var nodeWithValidatorCall = root
                    .DescendantNodes(lineSpanWithValidatorCall)
                    .FirstOrDefault(n =>
                        {
                            if (lineSpanWithValidatorCall.Contains(n.Span))
                            {
                                var mae = n as MemberAccessExpressionSyntax;
                                if (mae != null)
                                {
                                    if (mae.Name?.Identifier.Text == validationMethodName)
                                    {
                                        return true;
                                    }
                                }
                            }
                            return false;
                        });

                if (nodeWithValidatorCall != null)
                {
                    var signature = nodeWithValidatorCall.Parent as InvocationExpressionSyntax;
                    var parameter = signature?.ArgumentList?.Arguments.FirstOrDefault();
                    if (expected != null && parameter != null && parameter.Expression is LiteralExpressionSyntax)
                    {
                        if (!Equals(((LiteralExpressionSyntax)parameter.Expression).Token.Value, expected))
                        {
                            return null;
                        }
                    }

                    var callerNameBuilder = new StringBuilder();
                    var identifier = nodeWithValidatorCall
                        .DescendantNodes()
                        .OfType<IdentifierNameSyntax>();
                    foreach (var i in identifier)
                    {
                        if (validationMethodName != i.Identifier.Text &&
                           nameof(ShouldExtensions.Should) != i.Identifier.Text)
                        {
                            callerNameBuilder.AppendFormat("{0}.", i.Identifier.Text);
                        }
                    }

                    return callerNameBuilder.ToString(0, callerNameBuilder.Length - 1);
                }

                return null;
            }
        }

        #endregion
    }
}