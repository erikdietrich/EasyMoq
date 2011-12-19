using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using DaedTech.EasyMoq.MoqInheritors;

namespace DaedTech.EasyMoq.Builders
{

    public class TargetBuilder
    {
        /// <summary>Construct an instance of the class under test with dummy test doubles</summary>
        /// <typeparam name="T">Class to create</typeparam>
        /// <returns>Newly created test, populated with dummies, where applicable</returns>
        public T BuildWithDummies<T>() where T : class
        {
            List<object> myDependencies = new List<object>();
            var myClass = typeof(T);
            var myConstructor = myClass.GetConstructors()[0];
            foreach (var myParameter in myConstructor.GetParameters())
            {
                var myMockType = typeof(Mock<>);
                Type[] myTypeArgs = new Type[] { myParameter.ParameterType };
                var myMock = Activator.CreateInstance(myMockType.MakeGenericType(myTypeArgs)) as Mock;
                if (myMock != null)
                {
                    myDependencies.Add(myMock.Object);
                }
            }
            return (T)Activator.CreateInstance(typeof(T), myDependencies.ToArray());
        }
    }
}
