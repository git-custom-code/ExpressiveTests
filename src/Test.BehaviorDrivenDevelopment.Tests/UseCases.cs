namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;

    public sealed partial class UseCases : TestCase
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
                Bar = bar ?? throw new ArgumentNullException(nameof(bar));
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

        public sealed class Bar : IBar
        {
            public int DoSomethingElse(params int[] parameter)
            {
                return 13;
            }
        }

        public sealed class BarWithException : IBar
        {
            public int DoSomethingElse(params int[] parameter)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        [Fact(DisplayName = "Method without result")]
        [IntegrationTest]
        public void MethodWithoutResult()
        {
            Given(() => new Foo(new Bar()))
            .When(foo => foo.DoSomethingWithoutResult(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Method without result and exception")]
        [IntegrationTest]
        public void MethodWithoutResultAndException()
        {
            Given(() => new Foo(new BarWithException()))
            .When(foo => foo.DoSomethingWithoutResult(0, 0))
            .ThenThrow<NotImplementedException>();
        }

        [Fact(DisplayName = "Method with result")]
        [IntegrationTest]
        public void MethodWithResult()
        {
            Given(() => new Foo(new Bar()))
            .When(foo => foo.DoSomething(0, 0))
            .Then(result => { });
        }

        [Fact(DisplayName = "Method without result and exception")]
        [IntegrationTest]
        public void MethodWithException()
        {
            Given(() => new Foo(new BarWithException()))
            .When(foo => foo.DoSomething(0, 0))
            .ThenThrow<NotImplementedException>(e => { });
        }

    }
}