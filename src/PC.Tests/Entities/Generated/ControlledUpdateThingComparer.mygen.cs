/*****************************************************************************/
/***                                                                       ***/
/***    This is an automatically generated file. It is generated using     ***/
/***    MyGeneration in conjunction with IBatisBusinessObject template.    ***/
/***                                                                       ***/
/***    DO NOT MODIFY THIS FILE DIRECTLY!                                  ***/
/***                                                                       ***/
/***    If you need to make changes either modify the template and         ***/
/***    regenerate or derive a class from this class and override.         ***/
/***                                                                       ***/
/*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PebbleCode.Framework.Dates;
using PebbleCode.Tests.EntityComparers;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PebbleCode.Tests.Entities;

namespace PebbleCode.Tests.EntityComparers
{
    public class ControlledUpdateThingComparer : EntityComparerBase
    {
        /// <summary>
        /// Compare two ControlledUpdateThing entities
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void Compare(ControlledUpdateThing expected, ControlledUpdateThing actual)
        {
            // Check for nulls
            if (expected == null && actual == null) return;
            if (expected == null) Assert.Fail("Expected null, got ControlledUpdateThing");
            if (actual == null) Assert.Fail("Expected ControlledUpdateThing, got null");

            // Compare simple properties
			Assert.AreEqual(expected.Id, actual.Id, "ControlledUpdateThing.Id not equal");
			Assert.AreEqual(expected.Name, actual.Name, "ControlledUpdateThing.Name not equal");
		}

        /// <summary>
        /// Compare lists of ControlledUpdateThing entities
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void Compare(ControlledUpdateThingList expected, ControlledUpdateThingList actual)
        {
            // Check for nulls
            if (expected == null && actual == null)  return;
            if (expected == null) Assert.Fail("Expected null, got list");
            if (actual == null) Assert.Fail("Expected list, got null");

            // Check counts
            Assert.AreEqual(expected.Count, actual.Count, "List counts not equal");

            // Now compare each entity in the list
            expected.SortById();
            actual.SortById();
            for (int index = 0; index < expected.Count; index++)
				Compare(expected[index], actual[index]);
        }
    }
}