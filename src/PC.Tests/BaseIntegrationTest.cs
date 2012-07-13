using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PebbleCode.Tests
{
    /// <summary>
    /// Integration tests touch the database, and therefore it should be reset between tests
    /// </summary>
    [TestClass]
    public abstract class BaseIntegrationTest<THelper> : BaseTest<THelper>
        where THelper : TestHelper, new()
    {
    }
}
