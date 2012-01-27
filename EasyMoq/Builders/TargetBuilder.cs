﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using DaedTech.EasyMoq.MoqInheritors;
using System.Reflection;

namespace DaedTech.EasyMoq.Builders
{

    public class TargetBuilder
    {
        /// <summary>Construct an instance of the class under test with dummy test doubles</summary>
        /// <typeparam name="T">Class to create</typeparam>
        /// <returns>Newly created test, populated with dummies, where applicable</returns>
        public virtual T BuildTarget<T>(IDoubleBuilder builder = null) where T : class
        {
            var myBuilder = new ConstructorDependencyBuilder(typeof(T).GetConstructors(), builder); //Null builder is fine here - the dependency builder will default to dummy
            var myDependencies = myBuilder.GetDependencyDoubles();

            return (T)Activator.CreateInstance(typeof(T), myDependencies.ToArray());
        }
    }
}
