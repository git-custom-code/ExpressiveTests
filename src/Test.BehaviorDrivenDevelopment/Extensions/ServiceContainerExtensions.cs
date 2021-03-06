﻿namespace CustomCode.Test.BehaviorDrivenDevelopment.Extensions
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
        #region Logic

        /// <summary>
        /// Register the <paramref name="typeUnderTest"/> at the <see cref="ServiceContainer"/> as well as
        /// a <see cref="Mock"/> for every injected reference type dependency.
        /// </summary>
        /// <param name="iocContainer"> The extended <see cref="ServiceContainer"/>. </param>
        /// <param name="typeUnderTest">
        /// The type under test that should be registered along with mock objects for it's dependencies.
        /// </param>
        /// <param name="arrangments">
        /// An optional list of arrangments that should be applied to the mock objects.
        /// </param>
        /// <returns>
        /// A collection of instanciated <see cref="Mock"/> objects for each of the
        /// <paramref name="typeUnderTest"/>'s dependencies.
        /// </returns>
        /// <remarks>
        /// Note that this will currently only work for constructor injection (and not for property injection).
        /// </remarks>
        public static HashSet<Mock> RegisterWithMocks(
            this ServiceContainer iocContainer,
            Type typeUnderTest, IDictionary<Type,
            List<Action<Mock>>> arrangments = null)
        {
            var instanciatedMocks = new HashSet<Mock>();
            foreach (var dependency in FindDependenciesFor(typeUnderTest))
            {
                var serviceType = dependency;
                Type mockType;

                if (dependency.GetTypeInfo().IsGenericType &&
                    dependency.GetTypeInfo().GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    serviceType = dependency.GenericTypeArguments[0];
                    mockType = typeof(Mock<>).MakeGenericType(serviceType);
                    if (!arrangments.ContainsKey(mockType))
                    {
                        continue;
                    }
                }
                else
                {
                    mockType = typeof(Mock<>).MakeGenericType(serviceType);
                }
                
                var mockedDependency = new ServiceRegistration();
                mockedDependency.FactoryExpression = (Func<IServiceFactory, object>)((IServiceFactory f) =>
                    {
                        var mock = mockType.GetConstructor(new Type[0]).Invoke(new object[0]) as Mock;
                        if (!instanciatedMocks.Contains(mock))
                        {
                            instanciatedMocks.Add(mock);
                        }

                        if (arrangments.TryGetValue(mockType, out List<Action<Mock>> mockArrangements))
                        {
                            mockArrangements.ForEach(arrange => arrange(mock));
                        }
                        return mock.Object;
                    });
                mockedDependency.ServiceName = string.Empty;
                mockedDependency.ServiceType = serviceType;

                iocContainer.Register(mockedDependency);
            }

            iocContainer.Register(typeUnderTest);
            return instanciatedMocks;
        }

        /// <summary>
        /// Find all dependencies for the <paramref name="typeUnderTest"/>, i.e. all reference types of all
        /// public constructors.
        /// </summary>
        /// <param name="typeUnderTest"> The type under test whose dependencies should be found. </param>
        /// <returns> A unique collection with all of the <paramref name="typeUnderTest"/>'s dependencies. </returns>
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

        #endregion
    }
}