namespace CustomCode.Test.BehaviorDrivenDevelopment.Test
{
    using FakeItEasy;
    using System;
    using System.Linq.Expressions;
    using Xunit;

    public class UnitTest1 : TestCase
    {
        [Fact]
        [UnitTest]
        public void Test1()
        {
            Given<Foo>()
            .With((IBar bar) => bar.CalculateSum(1, 1)).Returns(42)
            .When()
            .Then();

            //var fooMock = A.Fake<IFoo>();
            //A.CallTo(() => fooMock.Bar()).Returns("hello");
            //var res = fooMock.Bar();
            //A.CallTo(() => fooMock.Bar()).MustHaveHappened(Repeated.AtLeast.Twice);
        }
    }

    public interface IFoo
    {
        int Add(int a, int b);
    }

    public interface IBar
    {
        int CalculateSum(params int[] parameter);
    }

    public sealed class Foo : IFoo
    {
        public Foo(IBar bar)
        {
            Bar = bar;
        }

        private IBar Bar { get; }

        public int Add(int a, int b)
        {
            return Bar.CalculateSum(a, b);
        }
    }
}