namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;

    public sealed partial class UseCases : TestCase
    {
        [Fact(DisplayName = "Async method without result and one additional parameter")]
        [IntegrationTest]
        public void AsyncMethodWithoutResultAndOneAdditionalParameter()
        {
            Given(() => new FooAsync(new Bar()))
            .Also(() => new Bar())
            .When((foo, bar) => foo.DoSomethingWithoutResultAsync(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Async method without result, one additional parameter and exception")]
        [IntegrationTest]
        public void AsyncMethodWithoutResultOneAdditionalParameterAndException()
        {
            Given(() => new FooAsync(new BarWithException()))
            .Also(() => new Bar())
            .When((foo, bar) => foo.DoSomethingWithoutResultAsync(0, 0))
            .ThenThrow<NotImplementedException>();
        }

        [Fact(DisplayName = "Async method with result and one additional parameter")]
        [IntegrationTest]
        public void AsyncMethodWithResultAndOneAdditionalParameter()
        {
            Given(() => new FooAsync(new Bar()))
            .Also(() => new Bar())
            .When((foo, bar) => foo.DoSomethingAsync(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Async method with result, one additional parameter and exception")]
        [IntegrationTest]
        public void AsyncMethodWithResultOneAdditionalParameterAndException()
        {
            Given(() => new FooAsync(new BarWithException()))
            .Also(() => new Bar())
            .When((foo, bar) => foo.DoSomethingAsync(0, 0))
            .ThenThrow<NotImplementedException>();
        }

        [Fact(DisplayName = "Async method without result and two additional parameters")]
        [IntegrationTest]
        public void AsyncMethodWithoutResultAndTwoAdditionalParameters()
        {
            Given(() => new FooAsync(new Bar()))
            .Also(() => new Bar())
            .Also(() => new Bar())
            .When((foo, bar1, bar2) => foo.DoSomethingWithoutResultAsync(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Async method without result, two additional parameters and exception")]
        [IntegrationTest]
        public void AsyncMethodWithoutResultTwoAdditionalParametersAndException()
        {
            Given(() => new FooAsync(new BarWithException()))
            .Also(() => new Bar())
            .Also(() => new Bar())
            .When((foo, bar1, bar2) => foo.DoSomethingWithoutResultAsync(0, 0))
            .ThenThrow<NotImplementedException>();
        }

        [Fact(DisplayName = "Async method with result and two additional parameters")]
        [IntegrationTest]
        public void AsyncMethodWithResultAndTwoAdditionalParameters()
        {
            Given(() => new FooAsync(new Bar()))
            .Also(() => new Bar())
            .Also(() => new Bar())
            .When((foo, bar1, bar2) => foo.DoSomethingAsync(0, 0))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Async method with result, two additional parameters and exception")]
        [IntegrationTest]
        public void AsyncMethodWithResultTwoAdditionalParametersAndException()
        {
            Given(() => new FooAsync(new BarWithException()))
            .Also(() => new Bar())
            .Also(() => new Bar())
            .When((foo, bar1, bar2) => foo.DoSomethingAsync(0, 0))
            .ThenThrow<NotImplementedException>();
        }
    }
}