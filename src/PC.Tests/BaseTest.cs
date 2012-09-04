﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PebbleCode.Framework.Logging;

namespace PebbleCode.Tests
{
    /// <summary>
    /// Integration tests touch the database, and therefore it should be reset between tests
    /// </summary>
    [TestClass]
    public abstract class BaseTest<TLogManager, THelper>
        where THelper : TestHelper, new()
        where TLogManager : ILogManager
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseTest()
        {
            Helper = new THelper();
        }

        /// <summary>
        /// Get a handle on the unit test helper
        /// </summary>
        protected virtual THelper Helper { get; private set; }
        protected abstract TLogManager LoggerInstance { get; }

        /// <summary>
        /// Initialise for unit tests
        /// </summary>
        [TestInitialize]
        public virtual void TestInitialise()
        {
            Helper.TestInitialise();
        }

        /// <summary>
        /// CleanUp for unit tests
        /// </summary>
        [TestCleanup]
        public virtual void TestCleanup()
        {
            Helper.TestCleanup(); 
        }

        /// <summary>
        /// Checks for the indicated type in the exception and all of its inner exceptions
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="innerExceptionType"></param>
        /// <returns></returns>
        protected void AssertHasExceptionOfTypeInChain(Exception ex, Type innerExceptionType)
        {
            while (ex != null)
            {
                if (ex.GetType().Equals(innerExceptionType)) return;
                ex = ex.InnerException;
            }
            Assert.Fail("Failed to find exception of type {0} in exception chain", innerExceptionType.FullName);
        }
    }
}
