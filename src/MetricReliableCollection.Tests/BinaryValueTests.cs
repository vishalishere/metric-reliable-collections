﻿// ------------------------------------------------------------
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace MetricReliableCollections.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinaryValueTests
    {
        [TestMethod]
        public void TestComparable()
        {
            BinaryValue less = new BinaryValue(
                new ArraySegment<byte>(BitConverter.GetBytes(1)));

            BinaryValue same = new BinaryValue(
                new ArraySegment<byte>(BitConverter.GetBytes(1)));

            BinaryValue greater = new BinaryValue(
                new ArraySegment<byte>(BitConverter.GetBytes(2)));

            Assert.AreEqual<int>(-1, less.CompareTo(greater));
            Assert.AreEqual<int>(0, less.CompareTo(same));
            Assert.AreEqual<int>(1, greater.CompareTo(less));
        }

        [TestMethod]
        public void TestComparableDefault()
        {
            BinaryValue defaultValue = default(BinaryValue);

            BinaryValue defaultValueSame = default(BinaryValue);

            BinaryValue greater = new BinaryValue(
                new ArraySegment<byte>(BitConverter.GetBytes(2)));

            Assert.AreEqual<int>(-1, defaultValue.CompareTo(greater));
            Assert.AreEqual<int>(0, defaultValue.CompareTo(defaultValueSame));
            Assert.AreEqual<int>(1, greater.CompareTo(defaultValue));
        }

        [TestMethod]
        public void TestEquatable()
        {
            BinaryValue less = new BinaryValue(
                new ArraySegment<byte>(BitConverter.GetBytes(1)));

            BinaryValue same = new BinaryValue(
                new ArraySegment<byte>(BitConverter.GetBytes(1)));

            BinaryValue greater = new BinaryValue(
                new ArraySegment<byte>(BitConverter.GetBytes(2)));

            Assert.IsFalse(less.Equals(greater));
            Assert.IsTrue(less.Equals(same));
            Assert.IsFalse(greater.Equals(less));

            Assert.IsFalse(less.Equals((object) greater));
            Assert.IsTrue(less.Equals((object) same));
            Assert.IsFalse(greater.Equals((object) less));
        }

        [TestMethod]
        public void TestEquatableDefault()
        {
            BinaryValue defaultValue = default(BinaryValue);

            BinaryValue defaultValueSame = default(BinaryValue);

            BinaryValue greater = new BinaryValue(
                new ArraySegment<byte>(BitConverter.GetBytes(2)));

            Assert.IsFalse(defaultValue.Equals(greater));
            Assert.IsFalse(greater.Equals(defaultValue));
            Assert.IsTrue(defaultValue.Equals(defaultValueSame));

            Assert.IsFalse(defaultValue.Equals((object) greater));
            Assert.IsFalse(greater.Equals((object) defaultValue));
            Assert.IsTrue(defaultValue.Equals((object) defaultValueSame));
        }
    }
}