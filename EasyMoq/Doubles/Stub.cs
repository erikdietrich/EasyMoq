using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Moq.Language.Flow;
using System.Linq.Expressions;

namespace DaedTech.EasyMoq.Doubles
{
    /// <summary>Represents a stub test double</summary>
    /// <typeparam name="T"></typeparam>
    public class Stub<T> : Dummy<T>
    {
        #region Fields

        /// <summary>This determines if the object in question can be mocked</summary>
        private readonly IMoqabilityEvaluator _evaluator = new MoqabilityEvaluator();

        #endregion

        #region Properties

        private Mock _internalMoq;

        private T _target;

        /// <summary>This is the Moq-like object property to be used for this stub</summary>
        public override T Object { get { return _target; } }

        #endregion

        #region Constructor

        /// <summary>Stub takes the same xtor parameters as the type being mocked</summary>
        public Stub(params object[] constructorParameters)
        {
            ParseType(constructorParameters);
        }

        #endregion

        #region Methods

        /// <summary>Set the default return value for methods returning type TReturn</summary>
        public virtual void SetReturnsDefault<TReturn>(TReturn newDefault)
        {
            if (_internalMoq != null)
            {
                _internalMoq.SetReturnsDefault(newDefault);
            }
        }

        /// <summary>This sets up a property getter</summary>
        /// <typeparam name="TProperty">Return type of the property</typeparam>
        /// <remarks>TODO - this needs to be fixed.  It might require a redesign, but I want to be faithful to the Moq API, and forcing clients to
        /// recall the class is no good</remarks>
        public ISetupGetter<TMock, TProperty> SetupGet<TMock, TProperty>(Expression<Func<TMock, TProperty>> expression) where TMock : class
        {
            return ((Mock<TMock>)_internalMoq).SetupGet(expression);
        }

        #endregion

        #region Private Methods

        /// <summary>Abstraction for parsing the generic type into an appropriate object</summary>
        protected void ParseType(params object[] constructorParameters)
        {
            if (_evaluator.IsMoqable<T>())
            {
                Type myMockType = typeof(Mock<>).MakeGenericType(typeof(T));
                _internalMoq = Activator.CreateInstance(myMockType, constructorParameters) as Mock;
                _target = (T)_internalMoq.Object;
            }
            else if (typeof(T) == typeof(string))
            {
                if (constructorParameters.Count() > 0)
                {
                    throw new ArgumentException("Strings are not created with constructor parameters.");
                }
                _target = (T)Convert.ChangeType(string.Empty, typeof(T));
            }
            else
            {
                if(!DoesAConstructorMatchThisType(constructorParameters))
                {
                    throw new ArgumentException("Wrong number of parameters for this type's constructor");
                }
                _target = (T)Activator.CreateInstance(typeof(T), constructorParameters);
            }
        }

        /// <summary>Abstraction for checking whether constructor parameters will allow us to create a type</summary>
        /// <TODO>This should probably be pulled out to its own class</TODO>
        private static bool DoesAConstructorMatchThisType(object[] constructorParameters)
        {
            var myConstructors = typeof(T).GetConstructors();
            bool myMatch = myConstructors.Count() == 0 && constructorParameters.Count() == 0;

            foreach (var myConstructor in myConstructors)
            {
                myMatch |= myConstructor.GetParameters().Count() == constructorParameters.Count();
            }
            return myMatch;
        }

        #endregion
    }
}
