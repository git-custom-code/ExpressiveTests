namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using Moq;
    using System;
    using Xunit;

    public sealed class UseCases : TestCase
    {
        #region Foo

        public interface IFoo
        {
            int DoSomething(int a, int b);

            void DoSomethingWithoutResult(int a, int b);

            int Count { get; }
        }

        public interface IBar
        {
            int DoSomethingElse(params int[] parameter);
        }

        public sealed class Foo : IFoo
        {
            public Foo(IBar bar)
            {
                Bar = bar;
            }

            private IBar Bar { get; }

            public int Count { get; private set; }

            public int DoSomething(int a, int b)
            {
                Count = Bar.DoSomethingElse(a, b);
                return Count;
            }

            public void DoSomethingWithoutResult(int a, int b)
            {
                Count = Bar.DoSomethingElse(a, b);
            }
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