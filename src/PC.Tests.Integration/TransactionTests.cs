﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PebbleCode.Repository;
using PebbleCode.Tests;
using PebbleCode.Tests.Entities;

namespace SGP.Tests.Integration.RepositoryTests
{
    [TestClass]
    public class TransactionTests : BaseIntegrationTest<TestHelper>
    {
        /// <summary>
        /// Initialiser for unit tests
        /// </summary>
        [TestInitialize]
        public override void TestInitialise()
        {
            base.TestInitialise();

            // Delete all things
            ThingRepo.DeleteAll();

            // Should be no things. Check now
            ThingList things = ThingRepo.GetAll();
            Assert.AreEqual(0, things.Count, "Should be no things");
        }

        [TestMethod]
        public void AutoCommitTest()
        {
            // Add a new thing, let using statement auto commit.
            using (RepositoryTransaction rt = EntityRepository.BeginTransaction())
            {
                ThingRepo.Save(new Thing() { Name = "TestThing", Corners = 1 });
            }

            // Check thing was saved
            Assert.AreEqual(1, ThingRepo.GetAll().Count, "Thing should be saved");
        }

        [TestMethod]
        public void RollbackTest()
        {
            // Add a new thing, but rollback xn.
            using (RepositoryTransaction rt = EntityRepository.BeginTransaction())
            {
                ThingRepo.Save(new Thing() { Name = "TestThing", Corners = 1 });
                rt.Rollback();
            }

            // Check thing wasn't saved
            Assert.AreEqual(0, ThingRepo.GetAll().Count, "Thing should not be saved");
        }

        [TestMethod]
        public void CommitTest()
        {
            // Add a new thing, manually commit.
            using (RepositoryTransaction rt = EntityRepository.BeginTransaction())
            {
                ThingRepo.Save(new Thing() { Name = "TestThing", Corners = 1 });
                rt.Commit();
            }

            // Check thing was saved
            Assert.AreEqual(1, ThingRepo.GetAll().Count, "Thing should be saved");
        }

        [TestMethod]
        public void MultitpleTransactionTest()
        {
            // Add a new thing, manually commit.
            using (RepositoryTransaction rt = EntityRepository.BeginTransaction())
            {
                ThingRepo.Save(new Thing() { Name = "TestThing", Corners = 1 });
                rt.Commit();
            }

            // Check thing was saved
            Assert.AreEqual(1, ThingRepo.GetAll().Count, "Thing should be saved");

            // Add a new thing, but rollback xn.
            using (RepositoryTransaction rt = EntityRepository.BeginTransaction())
            {
                ThingRepo.Save(new Thing() { Name = "TestThing", Corners = 1 });
                rt.Rollback();
            }

            // Check thing wasn't saved
            Assert.AreEqual(1, ThingRepo.GetAll().Count, "Thing should not be saved");

            // Add a new thing, manually commit.
            using (RepositoryTransaction rt = EntityRepository.BeginTransaction())
            {
                ThingRepo.Save(new Thing() { Name = "TestThing", Corners = 1 });
                rt.Commit();
            }

            // Check thing was saved
            Assert.AreEqual(2, ThingRepo.GetAll().Count, "Thing should be saved");
        }

        [TestMethod]
        public void ExceptionRollbackTest()
        {
            try
            {
                // Add a new thing but don't commit.
                using (var transaction = EntityRepository.BeginTransaction())
                {
                    ThingRepo.Save(new Thing() { Name = "TestThing", Corners = 1 });
                    Assert.AreEqual(1, ThingRepo.GetAll().Count, "Thing should be saved");
                    // Throw excepiton before commiting.
                    throw new Exception();
                }
            }
            catch
            {
            }

            Assert.AreEqual(0, ThingRepo.GetAll().Count, "Thing save should have been rolled back");
        }

        [TestMethod]
        public void ExceptionCommitTest()
        {
            try
            {
                // Add a new thing and commit.
                using (var transaction = EntityRepository.BeginTransaction())
                {
                    ThingRepo.Save(new Thing() { Name = "TestThing", Corners = 1 });
                    Assert.AreEqual(1, ThingRepo.GetAll().Count, "Thing should be saved");
                    transaction.Commit();
                    // Throw excepiton after commiting.
                    throw new Exception();
                }
            }
            catch
            {
            }

            Assert.AreEqual(1, ThingRepo.GetAll().Count, "Thing have been saved");
        }

        [TestMethod]
        public void ThreadSafetyTest()
        {
            // Run first thread, start a transaction, add a new entity, but do not commit. Pause thread.
            // Run a second thread that will add a new entity in its own transaction, and commit. End thread.
            // Run a third thread that will go get the entities, T1 entity should not be there, but T2 entity should be. End thread.
            // Resume first thread. Commit transaction. Get all and make sure we now have all entities.

            // We define T2 and T3 before T1, as T1 runs both of these and waits for them to complete.
            ManualResetEvent t2wait = new ManualResetEvent(false);
            Thread t2 = new Thread(() =>
            {
                try
                {
                    // Add a new thing in a transaction.
                    using (RepositoryTransaction rt = EntityRepository.BeginTransaction())
                    {
                        ThingRepo.Save(new Thing() { Name = "T2", Corners = 1 });
                    }
                }
                finally
                {
                    t2wait.Set();
                }
            });

            ManualResetEvent t3wait = new ManualResetEvent(false);
            Thread t3 = new Thread(() =>
            {
                try
                {
                    // Do a get. Should get just T2. So 1 thing
                    Assert.AreEqual(1, ThingRepo.GetAll().Count, "Should be 1 thing by now");
                }
                finally
                {
                    t3wait.Set();
                }
            });

            ManualResetEvent t1wait = new ManualResetEvent(false);
            Thread t1 = new Thread(() =>
            {
                try
                {
                    using (RepositoryTransaction rt = EntityRepository.BeginTransaction())
                    {
                        ThingRepo.Save(new Thing() { Name = "T1", Corners = 1 });

                        // Before we commit. Run T2.
                        t2.Start();
                        t2wait.WaitOne();

                        // And t3
                        t3.Start();
                        t3wait.WaitOne();

                        // Now commit our changes
                        rt.Commit();
                    }

                    // And now check that we have both new things
                    Assert.AreEqual(2, ThingRepo.GetAll().Count, "Should be 2 things by now");
                }
                finally
                {
                    t1wait.Set();
                }
            });

            // Run the whole thing.
            // And wait for t1 to exit.
            t1.Start();
            t1wait.WaitOne();

            // Double check that we have both new things
            Assert.AreEqual(2, ThingRepo.GetAll().Count, "Should be 2 things by now");
        }
    }
}
