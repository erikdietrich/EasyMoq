using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using DaedTech.EasyMoq.Common;
using Moq;

namespace DaedTech.EasyMoq.Builders
{
    /// <summary>This class models a constructor for our purposes using the constructor info object</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/13/2012</written>
    public class ConstructorDependencyBuilder
    {
        #region Fields

        /// <summary>Used to verify method preconditions and object invariants</summary>
        private readonly Validator _validator = new Validator();

        /// <summary>Stores the constructor information of the type we're </summary>
        private readonly ConstructorInfo[] _constructorInfo;

        /// <summary>The particular type of mock builder to use for construction here</summary>
        private readonly IDoubleBuilder _builder;

        #endregion

        #region Constructor

        /// <summary>Dependency injected constructor</summary>
        /// <param name="constructorInfo">Constructor information of a class</param>
        public ConstructorDependencyBuilder(ConstructorInfo[] constructorInfo, IDoubleBuilder builder = null)
        {
            _validator.VerifyNonNull(constructorInfo);
            _constructorInfo = constructorInfo;
            _builder = builder ?? new DummyBuilder(); //Default to using dummies
        }

        #endregion

        #region Methods

        /// <summary>Returns doubles corresponding to the parameters of the passed in constructor</summary>
        public IList<object> GetDependencyDoubles()
        {
            var myList = new List<object>();

            var myConstructor = _constructorInfo.OrderBy(xtor => xtor.GetParameters().Count()).First(); //We want the constructor with the fewest parameters

            foreach (var myParameter in myConstructor.GetParameters())
            {
                myList.Add(_builder.CreateDouble(myParameter.ParameterType));
            }
            return myList;
        }

        #endregion
    }
}
