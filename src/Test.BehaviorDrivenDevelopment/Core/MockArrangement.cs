namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using LightInject;
    using Moq;
    using Moq.Language.Flow;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public sealed class MockArrangement<T, TMock, TResult>
        where T : class
        where TMock : class
    {
        public MockArrangement(Expression<Func<TMock, TResult>> arrange)
        {
            Arrange = arrange;
        }

        private Expression<Func<TMock, TResult>> Arrange { get; }

        //public MockExecutor<T> Returns(TResult result)
        //{
        //    var registration = new ServiceRegistration();
        //    registration.FactoryExpression = (Func<IServiceFactory, TMock>)(factory =>
        //        {
        //            var mock = new Mock<TMock>();
        //            mock.Setup(Arrange).Returns(result);
        //            return mock.Object;
        //        });
        //    registration.ServiceName = typeof(TMock).Name;
        //    registration.ServiceType = typeof(TMock);
        //    return new MockExecutor<T>(Enumerable.Empty<ServiceRegistration>(), registration);
        //}
    }
}