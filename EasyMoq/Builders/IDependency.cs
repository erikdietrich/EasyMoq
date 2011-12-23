using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaedTech.EasyMoq.Builders
{
    /// <summary>This defines base behavior for </summary>
    public interface IDependency
    {
        /// <summary>Type of the dependency to be mocked</summary>
        Type TypeToMock { get; set; }
        
        /// <summary>Mock builder to use for constructing a mock</summary>
        IMockBuilder Builder { get; set; }

        /// <summary>Generates a test double for this dependency</summary>
        /// <returns>The test double in question</returns>
        object EmitTestDouble();

    }
}
