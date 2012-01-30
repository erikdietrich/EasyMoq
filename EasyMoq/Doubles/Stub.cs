using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace DaedTech.EasyMoq.Doubles
{
    /// <summary>Represents a stub test double</summary>
    /// <typeparam name="T"></typeparam>
    public class Stub<T> : Dummy<T>
    {
        /// <summary>This determines if the object in question can be mocked</summary>
        private readonly IMoqabilityEvaluator _evaluator = new MoqabilityEvaluator();


        /// <summary>This is the Moq-like object property to be used for this stub</summary>
        public override object Object
        {
            get
            {
                if (_evaluator.IsMoqable<T>())
                {
                    var myMock = Activator.CreateInstance(typeof(Mock<>).MakeGenericType(typeof(T))) as Mock;
                    return myMock.Object;
                }
                return base.Object;
            }
        }
    }
}
