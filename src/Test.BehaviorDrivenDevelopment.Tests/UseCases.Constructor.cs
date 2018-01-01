namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;

    public sealed partial class UseCases
    {
        [Fact(DisplayName = "Type constructor")]
        [IntegrationTest]
        public void TypeConstructor()
        {
            Given()
            .When(() => new Foo(new Bar()))
            .Then(foo => { });
        }

        [Fact(DisplayName = "Type constructor with exception")]
        [IntegrationTest]
        public void TypeConstructorWithException()
        {
            Given()
            .When(() => new Foo(null))
            .ThenThrow<ArgumentNullException>();
        }
    }
}