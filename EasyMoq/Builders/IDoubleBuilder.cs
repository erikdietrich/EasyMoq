using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace DaedTech.EasyMoq.Builders
{
    /// <summary>This interface defines </summary>
    public interface IDoubleBuilder
    {
        object CreateMoqDouble(Type typeToMock);

        object CreateNonMoqDouble(Type typeToMock);

        object CreateValueDouble(Type typeToMock);
    }
}
