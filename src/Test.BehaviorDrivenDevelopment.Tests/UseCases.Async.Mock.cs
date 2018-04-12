namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;

    public sealed partial class UseCases
    {
        [Fact(DisplayName = "Mocked dependencies without async result")]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutAsyncResult()
        {
            Given<FooAsync>()
            .When(foo => foo.DoSomethingWithoutResultAsync(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Mocked and arranged dependencies without async result")]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutAsyncResultAndMockExpectation()
        {
            Given<FooAsync>()
            .With((IBar bar) => bar.DoSomethingElse()).Returns(42)
            .When(foo => foo.DoSomethingWithoutResultAsync(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Mocked dependencies without async result and exception")]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutAsyncResultAndException()
        {
            Given<FooAsync>()
            .With((IBar bar) => bar.DoSomethingElse()).Throws<ArgumentNullException>()
            .When(foo => foo.DoSomethingWithoutResultAsync(0, 0))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Mocked dependencies without async result and exception factory")]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutAsyncResultAndExceptionFactory()
        {
            Given<FooAsync>()
            .With((IBar bar) => bar.DoSomethingElse()).Throws(() => new ArgumentNullException("Foo"))
            .When(foo => foo.DoSomethingAsync(0, 0))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Mocked dependencies with async result")]
        [IntegrationTest]
        public void AutoMockDependenciesWithAsyncResult()
        {
            Given<FooAsync>()
            .When(foo => foo.DoSomethingAsync(0, 0))
            .Then(result => { });
        }

        [Fact(DisplayName = "Mocked and arranged dependencies with async result")]
        [IntegrationTest]
        public void AutoMockDependenciesWithAsyncResultAndMockArrangement()
        {
            Given<FooAsync>()
            .With((IBar bar) => bar.DoSomethingElse()).Returns(42)
            .When(foo => foo.DoSomethingAsync(0, 0))
            .Then(result => { });
        }

        [Fact(DisplayName = "Mocked dependencies with async result and exception")]
        [IntegrationTest]
        public void AutoMockDependenciesWithAsyncResultAndException()
        {
            Given<FooAsync>()
            .With((IBar bar) => bar.DoSomethingElse()).Throws<ArgumentNullException>()
            .When(foo => foo.DoSomethingAsync(0, 0))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Mocked dependencies with async result and exception factory")]
        [IntegrationTest]
        public void AutoMockDependenciesWithAsyncResultAndExceptionFactory()
        {
            Given<FooAsync>()
            .With((IBar bar) => bar.DoSomethingElse()).Throws(() => new ArgumentNullException("Foo"))
            .When(foo => foo.DoSomethingAsync(0, 0))
            .ThenThrow<ArgumentNullException>();
        }
    }
}