using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam.Mentoring.DataStructures.HashTable.Tests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void Add_ShouldAddSingleItemToEmptyHashtable()
        {
            var table = new HashTable();

            table.Add("key", "value");

            Assert.AreEqual(true, table.Contains("key"));
            Assert.AreEqual("value", table["key"]);
        }

        [TestMethod]
        public void Add_ShouldAddTwoItemsToEmptyHashtable()
        {
            var table = new HashTable();

            table.Add("key", "value");
            table.Add("test", "data");

            Assert.AreEqual(true, table.Contains("key"));
            Assert.AreEqual(true, table.Contains("test"));
            Assert.AreEqual("value", table["key"]);
            Assert.AreEqual("data", table["test"]);
        }

        [TestMethod]
        public void Add_ShouldThrowWhenAddExistingKeyToHashtable()
        {
            var table = new HashTable();
            table.Add("key", "value");

            Assert.ThrowsException<ArgumentException>(() => table.Add("key", "test"));
        }

        [TestMethod]
        public void IndexerGet_ShouldThrowWhenKeyIsNotFoundInHashtable()
        {
            var table = new HashTable();

            Assert.ThrowsException<KeyNotFoundException>(() => table["test"]);
        }

        [TestMethod]
        public void IndexerGet_ShouldReturnValueWhenKeyExistsInHashtable()
        {
            var table = new HashTable();
            table.Add("key", "value");

            Assert.AreEqual("value", table["key"]);
        }

        [TestMethod]
        public void IndexerSet_ShouldAddKeyValuePairWhenKeyIsNotFoundInHashtable()
        {
            var table = new HashTable();

            table["key"] = "value";

            Assert.AreEqual("value", table["key"]);
        }

        [TestMethod]
        public void IndexerSet_ShouldSetValueWhenKeyIsFoundInHashtable()
        {
            var table = new HashTable();
            table.Add("key", "value");

            table["key"] = "test";

            Assert.AreEqual("test", table["key"]);
        }

        [TestMethod]
        public void IndexerSet_ShouldDeleteExistingItemFromHashtableWhenTryingToSetNull()
        {
            var table = new HashTable();
            table.Add("key", "value");

            table["key"] = null;

            Assert.AreEqual(false, table.Contains("key"));
        }

        [TestMethod]
        public void Contains_ShouldReturnTrueWhenKeyExistsInHashtable()
        {
            var table = new HashTable();
            table.Add("key", "value");

            Assert.AreEqual(true, table.Contains("key"));
        }

        [TestMethod]
        public void Contains_ShouldReturnFalseWhenKeyDoesntExistInHashtable()
        {
            var table = new HashTable();

            Assert.AreEqual(false, table.Contains("key"));
        }

        [TestMethod]
        public void TryGet_ShouldReturnFalseAndNullWhenKeyDoesntExistInHashtable()
        {
            var table = new HashTable();

            Assert.AreEqual(false, table.TryGet("key", out var value));
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void TryGet_ShouldReturnTrueAndValueWhenKeyExistsInHashtable()
        {
            var table = new HashTable();
            table.Add("key", "value");

            Assert.AreEqual(true, table.TryGet("key", out var value));
            Assert.AreEqual("value", value);
        }
    }
}
