namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;

    public sealed partial class UseCases
    {
        [Fact(DisplayName = "Mocked dependencies without result")]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutResult()
        {
            Given<Foo>()
            .When(foo => foo.DoSomethingWithoutResult(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Mocked and arranged dependencies without result")]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutResultAndMockExpectation()
        {
            Given<Foo>()
            .With((IBar bar) => bar.DoSomethingElse()).Returns(42)
            .When(foo => foo.DoSomethingWithoutResult(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Mocked dependencies without result and exception")]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutResultAndException()
        {
            Given<Foo>()
            .With((IBar bar) => bar.DoSomethingElse()).Throws<ArgumentNullException>()
            .When(foo => foo.DoSomethingWithoutResult(0, 0))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Mocked dependencies without result and exception factory")]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutResultAndExceptionFactory()
        {
            Given<Foo>()
            .With((IBar bar) => bar.DoSomethingElse()).Throws(() => new ArgumentNullException("Foo"))
            .When(foo => foo.DoSomething(0, 0))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Mocked dependencies with result")]
        [IntegrationTest]
        public void AutoMockDependenciesWithResult()
        {
            Given<Foo>()
            .When(foo => foo.DoSomething(0, 0))
            .Then(result => { });
        }

        [Fact(DisplayName = "Mocked and arranged dependencies with result")]
        [IntegrationTest]
        public void AutoMockDependenciesWithResultAndMockArrangement()
        {
            Given<Foo>()
            .With((IBar bar) => bar.DoSomethingElse()).Returns(42)
            .When(foo => foo.DoSomething(0, 0))
            .Then(result => { });
        }

        [Fact(DisplayName = "Mocked dependencies with result and exception")]
        [IntegrationTest]
        public void AutoMockDependenciesWithResultAndException()
        {
            Given<Foo>()
            .With((IBar bar) => bar.DoSomethingElse()).Throws<ArgumentNullException>()
            .When(foo => foo.DoSomething(0, 0))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Mocked dependencies with result and exception factory")]
        [IntegrationTest]
        public void AutoMockDependenciesWithResultAndExceptionFactory()
        {
            Given<Foo>()
            .With((IBar bar) => bar.DoSomethingElse()).Throws(() => new ArgumentNullException("Foo"))
            .When(foo => foo.DoSomething(0, 0))
            .ThenThrow<ArgumentNullException>();
        }
    }
}