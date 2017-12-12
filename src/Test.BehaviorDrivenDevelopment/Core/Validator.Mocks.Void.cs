﻿namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using Extensions;
    using LightInject;
    using Moq;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define any number of assertions on an instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    public sealed class ValidatorWithMocks<T> : IFluentInterface where T : class
    {
        #region Dependencies

        /// <summary>
        /// Create a new instance of the <see cref="ValidatorWithMocks{T}"/> type.
        /// </summary>
        /// <param name="act"> A delegate that executes the (void) method under test. </param>
        /// <param name="arrangements">
        /// A collection of arrangements that should be applied to instanciated mock objects.
        /// </param>
        public ValidatorWithMocks(Action<T> act, IDictionary<Type, List<Action<Mock>>> arrangements)
        {
            Act = act ?? throw new ArgumentNullException(nameof(act), "Act delegate cannot be null.");
            Arrangements = arrangements ?? new Dictionary<Type, List<Action<Mock>>>();
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that executes the (void) method under test.
        /// </summary>
        private Action<T> Act { get; }

        /// <summary>
        /// Gets a collection of arrangements that should be applied to instanciated mock objects.
        /// </summary>
        private IDictionary<Type, List<Action<Mock>>> Arrangements { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Define any number of assertions on the type under test after the method under test was
        /// successfully executed.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the type under test.
        /// </param>
        public void Then(Action<T> assert)
        {
            try
            {
                // given
                var container = new ServiceContainer();
                var instanciatedMocks = container.RegisterWithMocks(typeof(T), Arrangements);
                var typeUnderTest = container.GetInstance<T>();

                // when
                Act(typeUnderTest);

                // then
                assert(typeUnderTest);
                foreach (var mock in instanciatedMocks)
                {
                    mock.VerifyAll();
                }
            }
            catch (Exception e)
            {
                throw e;
                // TODO
            }
        }

        #endregion
    }
}