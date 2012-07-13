using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using PebbleCode.Framework;
using PebbleCode.Repository;
using PebbleCode.Framework.Logging;
using PebbleCode.Framework.Dates;

namespace PebbleCode.Tests
{
    /// <summary>
    /// A helper class for unit tests
    /// </summary>
    public class TestHelper
    {
        Random _rng = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// Constructor, used by BaseIntegrationTest and BaseUnitTest
        /// </summary>
        public TestHelper()
        {
        }

        /// <summary>
        /// Get or set the expected error count for a test. Inits to zero
        /// </summary>
        public int ExpectedErrorCount { get; set; }

        /// <summary>
        /// Called by BaseIntegrationTest and BaseUnitTest during TestInitialise
        /// </summary>
        
        [ExpectedException(typeof(Exception))]
        internal virtual void TestInitialise()
        {
            Logger.ResetErrorFlags();
            ExpectedErrorCount = 0;
        }

        /// <summary>
        /// Called by BaseIntegrationTest and BaseUnitTest during TestCleanup
        /// </summary>
        internal virtual void TestCleanup()
        {
            // Ensure correct number of errors have been logged
            if (ExpectedErrorCount == 0)
                Assert.IsFalse(Logger.ErrorsWrittenToLog, "Errors written to log. If expected, set ExpectedErrorCount during test");
            else
                Assert.AreEqual(ExpectedErrorCount, Logger.ErrorCount, "Incorrect number of errors written to log");
        }

        /// <summary>
        /// Get a random number generator prepared for action
        /// </summary>
        public Random Rng { get { return _rng; } }

        /// <summary>
        /// Get a random decimal between decimal.MinValue and decimal.MaxValue
        /// </summary>
        public decimal RandomDecimal
        {
            get { return Rng.NextDecimal(decimal.MinValue, decimal.MaxValue); }
        }

        /// <summary>
        /// Get a random int between int.MinValue and int.MaxValue
        /// </summary>
        public int RandomInt
        {
            get { return Rng.Next(int.MinValue, int.MaxValue); }
        }
    }
}
