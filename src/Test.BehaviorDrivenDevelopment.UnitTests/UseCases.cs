namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using Moq;
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

        [Fact]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutResult()
        {
            Given<Foo>()
            .When(foo => foo.DoSomethingWithoutResult(0, 0))
            .Then(foo => { });
        }

        [Fact]
        [IntegrationTest]
        public void AutoMockDependenciesWithoutResultAndMockExpectation()
        {
            Given<Foo>()
            .With((IBar bar) => bar.DoSomethingElse()).Returns(42)
            .When(foo => foo.DoSomethingWithoutResult(0, 0))
            .Then(foo => { });
        }

        [Fact]
        [IntegrationTest]
        public void AutoMockDependenciesWithResult()
        {
            Given<Foo>()
            .When(foo => foo.DoSomething(0, 0))
            .Then(result => { });
        }
    }
}