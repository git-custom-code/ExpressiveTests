namespace CustomCode.Test.BehaviorDrivenDevelopment.Composition
{
    using LightInject;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Extension methods for the <see cref="ServiceContainer"/> type.
    /// </summary>
    public static class ServiceContainerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iocContainer"></param>
        /// <param name="typeUnderTest"></param>
        public static void RegisterWithMocks(this ServiceContainer iocContainer, Type typeUnderTest)
        {
            foreach (var dependency in FindDependenciesFor(typeUnderTest))
            {
                var mockType = typeof(Mock<>).MakeGenericType(dependency);
                mockType.GetConstructor(new Type[0]).Invoke(new object[0]);

                var mockedDependency = new ServiceRegistration();
                mockedDependency.FactoryExpression = (Func<IServiceFactory, object>)((IServiceFactory f) =>
                    {
                        var mock = mockType.GetConstructor(new Type[0]).Invoke(new object[0]) as Mock;
                        return mock.Object;
                    });
                mockedDependency.ServiceName = string.Empty;
                mockedDependency.ServiceType = dependency;

                iocContainer.Register(mockedDependency);
            }

            iocContainer.Register(typeUnderTest);
        }

        private static IEnumerable<Type> FindDependenciesFor(Type typeUnderTest)
        {
            var dependencies = new HashSet<Type>();
            foreach (var constructor in typeUnderTest.GetConstructors(BindingFlags.Instance | BindingFlags.Public))
            {
                foreach (var parameter in constructor.GetParameters())
                {
                    if (parameter.ParameterType.GetTypeInfo().IsValueType)
                    {
                        continue;
                    }

                    if (!dependencies.Contains(parameter.ParameterType))
                    {
                        dependencies.Add(parameter.ParameterType);
                    }
                }
            }

            return dependencies;
        }
    }
}