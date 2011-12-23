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
        public virtual T BuildTarget<T>(IMockBuilder builder = null) where T : class
        {
            var myBuilder = builder ?? new DummyMockBuilder();
            var myClass = typeof(T);
            var myConstructor = myClass.GetConstructors()[0];
            var myDependencies = GetDependencies(myConstructor, myBuilder);

            return (T)Activator.CreateInstance(typeof(T), myDependencies.ToArray());
        }

        //TODO - this needs to be broken up
        private List<object> GetDependencies(ConstructorInfo myConstructor, IMockBuilder myBuilder)
        {
            var myDependencies = new List<object>();
            foreach (var myParameter in myConstructor.GetParameters())
            {
                if (myParameter.ParameterType.IsClass || myParameter.ParameterType.IsInterface)
                {
                    var myMock = myBuilder.BuildMock(myParameter.ParameterType);
                    myDependencies.Add(myMock.Object);
                }
                else
                {
                    myDependencies.Add(Activator.CreateInstance(myParameter.ParameterType));
                }
            }
            return myDependencies;
        }
    }
}
