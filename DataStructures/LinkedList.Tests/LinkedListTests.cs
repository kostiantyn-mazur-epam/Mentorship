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
            list.Add(1);
            Assert.AreEqual(list.Size, 1);
            Assert.AreEqual(list.ElementAt(0), 1);
        }

        [TestMethod]
        public void Add_Item_ShouldAddNodeToNotEmptyList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(list.Size, 2);
            Assert.AreEqual(list.ElementAt(1), 2);
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
            list.AddAt(1, 0);
            Assert.AreEqual(list.Size, 1);
            Assert.AreEqual(list.ElementAt(0), 1);
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
            Assert.AreEqual(list.ElementAt(1), 4);
        }

        [TestMethod]
        public void AddAt_Item_ShoudThrowWhenAddAtPosition1ToEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.AddAt(3, 1));
        }

        [TestMethod]
        public void AddAt_Item_ShoudThrowWhenAddAtPosition2ToListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.AddAt(2, 2));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeAtPosition1ToListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.AddAt(2, 1);
            Assert.AreEqual(list.Size, 2);
            Assert.AreEqual(list.ElementAt(1), 2);
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeAtPosition0ToListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.AddAt(2, 0);
            Assert.AreEqual(list.Size, 2);
            Assert.AreEqual(list.ElementAt(0), 2);
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
        public void AddAt_Item_ShouldThrowWhenAddNodeAtNegativePositionToEmptyList()
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
        public void Remove_Item_ShouldThrowWhenRemoveNodeFromEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => list.Remove());
        }

        [TestMethod]
        public void Remove_Item_ShouldRemoveNodeFromListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Remove();
            Assert.AreEqual(list.Size, 0);
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldThrowWhenRemoveNodeAtNegaivePositionFromListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldThrowWhenRemoveNodeAtPosition2FromEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => list.RemoveAt(2));
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldThrowWhenRemoveNodeAtPosition1FromListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.RemoveAt(1));
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldRemoveNodeAtPosition0FromListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.RemoveAt(0);
            Assert.AreEqual(list.Size, 0);
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldRemoveNodeAtPosition1FromListOf3()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveAt(1);
            Assert.AreEqual(list.Size, 2);
            Assert.AreEqual(list.ElementAt(1), 3);
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldRemoveNodeAtPosition0FromListOf2()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.RemoveAt(0);
            Assert.AreEqual(list.Size, 1);
            Assert.AreEqual(list.ElementAt(0), 2);
        }

        [TestMethod]
        public void ElementAt_Item_ShouldReturnItemAtPosition0FromListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            Assert.AreEqual(list.ElementAt(0), 1);
        }

        [TestMethod]
        public void ElementAt_Item_ShouldReturnItemAtPosition0FromListOf2()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(list.ElementAt(0), 1);
        }

        [TestMethod]
        public void ElementAt_Item_ShouldReturnItemAtPosition1FromListOf2()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(list.ElementAt(1), 2);
        }

        [TestMethod]
        public void ElementAt_Item_ShouldThrowWhenListIsEmpty()
        {
            var list = new LinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => list.ElementAt(0));
        }

        [TestMethod]
        public void ElementAt_Item_ShouldThrowWhenTakeItemAtPositionNegative1FromListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.ElementAt(-1));
        }

        [TestMethod]
        public void ElementAt_Item_ShouldThrowWhenTakeItemAtPosition1FromListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.ElementAt(1));
        }

        [TestMethod]
        public void GetEnumerator_ShouldSumElementsOfNotEmptyList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            var sum = 0;
            foreach(var element in list)
            {
                sum += element;
            }
            Assert.AreEqual(sum, 3);
        }

        [TestMethod]
        public void GetEnumerator_ShouldSumElementsOfEmptyList()
        {
            var list = new LinkedList<int>();
            var sum = 0;
            foreach (var element in list)
            {
                sum += element;
            }
            Assert.AreEqual(sum, 0);
        }
    }
}
