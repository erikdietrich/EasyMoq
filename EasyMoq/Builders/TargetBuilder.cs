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
        public virtual T BuildWithDummies<T>() where T : class
        {
            var myClass = typeof(T);
            var myConstructor = myClass.GetConstructors()[0];
            var myDependencies = GetDependenciesAsDummies(myConstructor);

            return (T)Activator.CreateInstance(typeof(T), myDependencies.ToArray());
        }

        //TODO - this needs to be broken up
        private List<object> GetDependenciesAsDummies(ConstructorInfo myConstructor)
        {
            var myDependencies = new List<object>();
            foreach (var myParameter in myConstructor.GetParameters())
            {
                if (myParameter.ParameterType.IsClass || myParameter.ParameterType.IsInterface)
                {
                    var myMock = BuildMock(myParameter.ParameterType);
                    if (myMock != null)
                    {
                        myDependencies.Add(myMock.Object);
                    }
                }
                else
                {
                    myDependencies.Add(Activator.CreateInstance(myParameter.ParameterType));
                }
            }
            return myDependencies;
        }

        //TODO - this should be a polymorphic implementation of whatever type of test double will be created, so abstract to a class
        private Mock BuildMock(Type typeToMock)
        {
            var myMockType = typeof(Mock<>);
            Type[] myTypeArgs = new Type[] { typeToMock };
            return Activator.CreateInstance(myMockType.MakeGenericType(myTypeArgs)) as Mock;
        }
    }
}
