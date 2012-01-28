using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaedTech.EasyMoq.Doubles
{
    /// <summary>Represents a stub test double</summary>
    /// <typeparam name="T"></typeparam>
    public class Stub<T> : Dummy<T>
    {
        public override object Object
        {
            get
            {
                return base.Object;
            }
        }
    }
}
