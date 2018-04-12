namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public sealed partial class UseCases
    {
        #region Foo

        public sealed class FooCollection
        {
            public FooCollection(IEnumerable<IBar> bars)
            {
                Bars = bars;
            }

            public int DoSomething(int a, int b)
            {
                var result = 0;
                foreach (var bar in Bars)
                {
                    result += bar.DoSomethingElse(a, b);
                }
                return result;
            }

            public IEnumerable<IBar> Bars { get; }
        }

        #endregion

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


        [Fact(DisplayName = "Mocked collection dependencies with result")]
        [IntegrationTest]
        public void AutoMockCollectionDependenciesWithResult()
        {
            Given<FooCollection>()
            .When(foo => foo.DoSomething(1, 1))
            .Then(result => result.Should().Be(0));
        }

        [Fact(DisplayName = "Mocked and arranged collection dependencies with result")]
        [IntegrationTest]
        public void AutoMockCollectionDependenciesWithResultAndMockArrangement()
        {
            Given<FooCollection>()
            .With((IBar bar) => bar.DoSomethingElse()).Returns(1)
            .When(foo => foo.DoSomething(1, 1))
            .Then(result => result.Should().Be(1));
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