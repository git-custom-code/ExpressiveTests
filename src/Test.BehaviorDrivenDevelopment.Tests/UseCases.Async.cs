namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public sealed partial class UseCases : TestCase
    {
        #region Foo

        public interface IFooAsync
        {
            Task<int> DoSomethingAsync(int a, int b);

            Task DoSomethingWithoutResultAsync(int a, int b);

            int Count { get; }
        }

        public sealed class FooAsync : IFooAsync
        {
            public FooAsync(IBar bar)
            {
                Bar = bar ?? throw new ArgumentNullException(nameof(bar));
            }

            private IBar Bar { get; }

            public int Count { get; private set; }

            public async Task<int> DoSomethingAsync(int a, int b)
            {
                Count = await Task.Run(() => Bar.DoSomethingElse(a, b));
                return Count;
            }

            public async Task DoSomethingWithoutResultAsync(int a, int b)
            {
                Count = await Task.Run(() => Bar.DoSomethingElse(a, b));
                return;
            }
        }

        #endregion

        [Fact(DisplayName = "Async method without result")]
        [IntegrationTest]
        public void AsyncMethodWithoutResult()
        {
            Given(() => new FooAsync(new Bar()))
            .When(foo => foo.DoSomethingWithoutResultAsync(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Asnyc method without result and exception")]
        [IntegrationTest]
        public void AsyncMethodWithoutResultAndException()
        {
            Given(() => new FooAsync(new BarWithException()))
            .When(foo => foo.DoSomethingWithoutResultAsync(0, 0))
            .ThenThrow<NotImplementedException>();
        }

        [Fact(DisplayName = "Async method with result")]
        [IntegrationTest]
        public void AsyncMethodWithResult()
        {
            Given(() => new FooAsync(new Bar()))
            .When(foo => foo.DoSomethingAsync(0, 0))
            .Then(result => { });
        }

        [Fact(DisplayName = "Asnyc method without result and exception")]
        [IntegrationTest]
        public void AsyncMethodWithException()
        {
            Given(() => new FooAsync(new BarWithException()))
            .When(foo => foo.DoSomethingAsync(0, 0))
            .ThenThrow<NotImplementedException>(e => { });
        }

    }
}