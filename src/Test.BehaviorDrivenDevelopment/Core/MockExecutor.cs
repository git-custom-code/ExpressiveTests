namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using CustomCode.Test.BehaviorDrivenDevelopment.Composition;
    using LightInject;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Executes a method (to be tested) on an instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"> The type to be tested. </typeparam>
    public sealed class MockExecutor<T> where T : class
    {
        #region Dependencies

        public MockExecutor()
        { }

        public MockExecutor(IEnumerable<ServiceRegistration> mockArrangements, ServiceRegistration arrange)
        {
            MockArrangments.AddRange(mockArrangements);
            MockArrangments.Add(arrange);
        }

        #endregion

        #region Data

        private List<ServiceRegistration> MockArrangments { get; } = new List<ServiceRegistration>();

        #endregion

        #region Logic

        public Validator When()
        {
            var container = new ServiceContainer();
            container.RegisterWithMocks(typeof(T));

            /*
            //container.RegisterAssembly(Assembly.GetEntryAssembly());
            foreach (var mock in MockArrangments)
            {
                container.Register(mock);
                var instance = container.GetInstance(mock.ServiceType);
            }*/

            var typeUnderTest = container.GetInstance(typeof(T));

            return new Validator();
        }

        /*
        public MockExecutor<T> With<TMock>(Expression<Action<TMock>> arrange) where TMock : class
        {
            var @base = arrange as Expression;
            var mock = new Mock<TMock>();
            var setup = mock.Setup(@base as Expression<Action<TMock>>);

            return null;
        }*/

        public MockArrangement<T, TMock, TResult> With<TMock, TResult>(Expression<Func<TMock, TResult>> arrange) where TMock : class
        {
            //var methodCall = arrange.Body as MethodCallExpression;
            //var instance = methodCall.Object as ParameterExpression;
            //var method = methodCall.Method;
            //var instanceType = instance.Type;

            //var mock = new Mock<TMock>();
            //var setup = mock.Setup(arrange);

            return new MockArrangement<T, TMock, TResult>(arrange);
            //return new MockExecutor<T>(MockArrangments, arrange);
        }

        #endregion
    }
}