using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void Add_Item_ShouldAddNodeToEmptyList()
        {
            var list = new LinkedList<int>();
            list.Add(5);
            Assert.AreEqual(list.Tail.Item, 5);
            Assert.AreEqual(list.Head.Item, 5);
            Assert.AreEqual(list.Size, 1);
        }

        [TestMethod]
        public void Add_Item_ShouldAddNodeToNotEmptyList()
        {
            var list = new LinkedList<int>();
            list.Add(5);
            list.Add(2);
            Assert.AreEqual(list.Tail.Item, 2);
            Assert.AreEqual(list.Head.Item, 5);
            Assert.AreEqual(list.Size, 2);
        }

        [TestMethod]
        public void Add_Item_ShouldThrowWhenAddNullToEmptyList()
        {
            var list = new LinkedList<string>();
            Assert.ThrowsException<ArgumentNullException>(() => list.Add(null));
        }

        [TestMethod]
        public void Add_Item_ShouldThrowWhenAddNullToNotEmptyList()
        {
            var list = new LinkedList<string>();
            list.Add("1");
            Assert.ThrowsException<ArgumentNullException>(() => list.Add(null));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeAtPosition0ToEmptyList()
        {
            var list = new LinkedList<int>();
            list.AddAt(3, 0);
            Assert.AreEqual(list.Tail.Item, 3);
            Assert.AreEqual(list.Head.Item, 3);
            Assert.AreEqual(list.Size, 1);
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeAtPosition1ToListOf3()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.AddAt(4, 1);
            Assert.AreEqual(list.Size, 4);

        }

        [TestMethod]
        public void AddAt_Item_ShoudThrowWhenAddAtPosition1ToEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.AddAt(3, 1));
        }

        [TestMethod]
        public void AddAt_Item_ShoudThrowWhenAddAtPosition3ToListOf2()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.AddAt(3, 3));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeAtLastPositionToNotEmptyList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.AddAt(4, 3);
            Assert.AreEqual(list.Size, 4);
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddAtFirstPositionToNotEmptyList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.AddAt(4, 0);
            Assert.AreEqual(list.Size, 4);
        }

        [TestMethod]
        public void AddAt_Item_ShouldThrowWhenAddNullAtPosition0ToEmptyList()
        {
            var list = new LinkedList<string>();
            Assert.ThrowsException<ArgumentNullException>(() => list.AddAt(null, 0));
        }

        [TestMethod]
        public void AddAt_Item_ShouldThrowWhenAddNullAtPosition0ToNotEmptyList()
        {
            var list = new LinkedList<string>();
            list.Add("1");
            Assert.ThrowsException<ArgumentNullException>(() => list.AddAt(null, 0));
        }

        [TestMethod]
        public void AddAt_Item_ShouldThrowWhenAddNodeAtPositionMinus2ToEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.AddAt(1, -2));
        }

        [TestMethod]
        public void AddAt_Item_ShouldThrowWhenAddNodeAtPosition1ToEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.AddAt(1, 1));
        }

        [TestMethod]
        public void Remove_Item_ShouldThrowWhenRemoveFromEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => list.Remove());
        }

        public void Remove_Item_ShouldRemoveNodeFromListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Remove();
            Assert.AreEqual(list.Size, 0);
        }
    }
}
