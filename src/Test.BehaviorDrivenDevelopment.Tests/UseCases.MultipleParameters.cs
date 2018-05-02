namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;

    public sealed partial class UseCases : TestCase
    {
        [Fact(DisplayName = "Method without result and one additional parameter")]
        [IntegrationTest]
        public void MethodWithoutResultAndOneAdditionalParameter()
        {
            Given(() => new Foo(new Bar()))
            .Also(() => new Bar())
            .When((foo, bar) => foo.DoSomethingWithoutResult(bar))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Method without result, one additional parameter and exception")]
        [IntegrationTest]
        public void MethodWithoutResultOneAdditionalParameterAndException()
        {
            Given(() => new Foo(new BarWithException()))
            .Also(() => new Bar())
            .When((foo, bar) => foo.DoSomethingWithoutResult(0, 0))
            .ThenThrow<NotImplementedException>();
        }

        [Fact(DisplayName = "Method with result and one additional parameter")]
        [IntegrationTest]
        public void MethodWithResultAndOneAdditionalParameter()
        {
            Given(() => new Foo(new Bar()))
            .Also(() => new Bar())
            .When((foo, bar) => foo.DoSomething(bar))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Method with result, one additional parameter and exception")]
        [IntegrationTest]
        public void MethodWithResultOneAdditionalParameterAndException()
        {
            Given(() => new Foo(new BarWithException()))
            .Also(() => new Bar())
            .When((foo, bar) => foo.DoSomething(0, 0))
            .ThenThrow<NotImplementedException>();
        }

        [Fact(DisplayName = "Method without result and two additional parameters")]
        [IntegrationTest]
        public void MethodWithoutResultAndTwoAdditionalParameters()
        {
            Given(() => new Foo(new Bar()))
            .Also(() => new Bar())
            .Also(() => new Bar())
            .When((foo, bar1, bar2) => foo.DoSomethingWithoutResult(bar1))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Method without result, two additional parameters and exception")]
        [IntegrationTest]
        public void MethodWithoutResultTwoAdditionalParametersAndException()
        {
            Given(() => new Foo(new BarWithException()))
            .Also(() => new Bar())
            .Also(() => new Bar())
            .When((foo, bar1, bar2) => foo.DoSomethingWithoutResult(0, 0))
            .ThenThrow<NotImplementedException>();
        }

        [Fact(DisplayName = "Method with result and two additional parameters")]
        [IntegrationTest]
        public void MethodWithResultAndTwoAdditionalParameters()
        {
            Given(() => new Foo(new Bar()))
            .Also(() => new Bar())
            .Also(() => new Bar())
            .When((foo, bar1, bar2) => foo.DoSomething(bar1))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Method with result, two additional parameters and exception")]
        [IntegrationTest]
        public void MethodWithResultTwoAdditionalParametersAndException()
        {
            Given(() => new Foo(new BarWithException()))
            .Also(() => new Bar())
            .Also(() => new Bar())
            .When((foo, bar1, bar2) => foo.DoSomething(0, 0))
            .ThenThrow<NotImplementedException>();
        }
    }
}