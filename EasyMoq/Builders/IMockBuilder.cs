using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace DaedTech.EasyMoq.Builders
{
    /// <summary>This interface defines </summary>
    public interface IMockBuilder
    {
        Mock BuildMock(Type typeToMock);
    }
}
