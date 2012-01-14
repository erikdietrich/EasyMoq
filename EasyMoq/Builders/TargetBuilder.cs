using System;
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
            var myClass = typeof(T);
            var myConstructor = myClass.GetConstructors()[0]; //This is going to need to be expanded to a class that parses the constructors and picks one
            var myBuilder = new ConstructorDependencyBuilder(myConstructor, builder);
            var myDependencies = myBuilder.GetDependencyDoubles();

            return (T)Activator.CreateInstance(typeof(T), myDependencies.ToArray());
        }

        //TODO - this is dead code
        //private List<object> GetDependencies(ConstructorInfo myConstructor, IMockBuilder builder)
        //{
        //    var myDependencies = new List<object>();
        //    foreach (ParameterInfo myParameter in myConstructor.GetParameters())
        //    {
        //        if (myParameter.ParameterType.IsClass || myParameter.ParameterType.IsInterface)
        //        {
        //            var myMock = builder.BuildMock(myParameter.ParameterType);
        //            myDependencies.Add(((Mock)myMock).Object);
        //        }
        //        else
        //        {
        //            myDependencies.Add(Activator.CreateInstance(myParameter.ParameterType));
        //        }
        //    }
        //    return myDependencies;
        //}
    }
}
