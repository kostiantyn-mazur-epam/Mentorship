using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam.Mentoring.DataStructures.Tests
{
    [TestClass]
    public sealed class LinkedListTests
    {
        [TestMethod]
        public void Add_Item_ShouldAddNodeWithDefaultValueOfStructToEmptyList()
        {
            var list = new LinkedList<int>();

            list.Add(default);

            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(0, list.ElementAt(0));
        }

        [TestMethod]
        public void Add_Item_ShouldAddNodeWithDefaultValueOfClassToEmptyList()
        {
            var list = new LinkedList<string>();

            list.Add(default);

            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(null, list.ElementAt(0));
        }

        [TestMethod]
        public void Add_Item_ShouldAddNodeWithDefaultValueOfStructToListOf1()
        {
            var list = new LinkedList<int>();

            list.Add(1);

            list.Add(default);

            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(0, list.ElementAt(1));
        }

        [TestMethod]
        public void Add_Item_ShouldAddNodeWithDefaultValueOfClassToListOf1()
        {
            var list = new LinkedList<string>();

            list.Add("1");

            list.Add(default);

            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(null, list.ElementAt(1));
        }

        [TestMethod]
        public void Add_Item_ShouldAddNodeToEmptyList()
        {
            var list = new LinkedList<int>();

            list.Add(1);

            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(1, list.ElementAt(0));
        }

        [TestMethod]
        public void Add_Item_ShouldAddNodeToNotEmptyList()
        {
            var list = new LinkedList<int>();

            list.Add(1);

            list.Add(2);

            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(2, list.ElementAt(1));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeWithDefaultValueOfStructAtPosition0ToEmptyList()
        {
            var list = new LinkedList<int>();

            list.AddAt(default, 0);

            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(0, list.ElementAt(0));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeWithDefaultValueOfClassAtPosition0ToEmptyList()
        {
            var list = new LinkedList<string>();

            list.AddAt(default, 0);

            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(null, list.ElementAt(0));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeWithDefaultValueOfStructAtPosition0ToListOf1()
        {
            var list = new LinkedList<int>();
            list.Add(1);

            list.AddAt(default, 0);

            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(0, list.ElementAt(0));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeWithDefaultValueOfClassAtPosition0ToListOf1()
        {
            var list = new LinkedList<string>();

            list.Add("1");

            list.AddAt(default, 0);

            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(null, list.ElementAt(0));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeAtPosition0ToEmptyList()
        {
            var list = new LinkedList<int>();

            list.AddAt(1, 0);

            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(1, list.ElementAt(0));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeAtPosition1ToListOf3()
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.AddAt(4, 1);

            Assert.AreEqual(4, list.Length);
            Assert.AreEqual(4, list.ElementAt(1));
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

            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(2, list.ElementAt(1));
        }

        [TestMethod]
        public void AddAt_Item_ShouldAddNodeAtPosition0ToListOf1()
        {
            var list = new LinkedList<int>();

            list.Add(1);

            list.AddAt(2, 0);

            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(2, list.ElementAt(0));
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
        public void Remove_Item_ShouldRemoveFirstNodeFromListOf3()
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(1);

            list.Remove(1);

            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(2, list.ElementAt(0));
        }

        [TestMethod]
        public void Remove_Item_ShouldRemoveNodeFromListOf1()
        {
            var list = new LinkedList<int>();

            list.Add(1);

            list.Remove(1);

            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        public void Remove_Item_ShouldNotAffectEmptyList()
        {
            var list = new LinkedList<int>();

            list.Remove(1);

            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        public void Remove_Item_ShouldNotAffectNotEmptyListWithNoMatches()
        {
            var list = new LinkedList<int>();

            list.Add(2);
            list.Add(3);

            list.Remove(1);

            Assert.AreEqual(2, list.Length);
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldThrowWhenRemoveNodeAtNegaivePositionFromListOf1()
        {
            var list = new LinkedList<int>();

            list.Add(1);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
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

            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldRemoveNodeAtPosition1FromListOf3()
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(1);

            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(3, list.ElementAt(1));
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldRemoveNodeAtPosition1FromListOf4()
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(1);
            list.Add(4);

            Assert.AreEqual(3, list.Length);
            Assert.AreEqual(3, list.ElementAt(1));
            Assert.AreEqual(4, list.ElementAt(2));
        }

        [TestMethod]
        public void RemoveAt_Item_ShouldRemoveNodeAtPosition0FromListOf2()
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);

            list.RemoveAt(0);

            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(2, list.ElementAt(0));
        }

        [TestMethod]
        public void ElementAt_Item_ShouldReturnItemAtPosition0FromListOf1()
        {
            var list = new LinkedList<int>();

            list.Add(1);

            Assert.AreEqual(1, list.ElementAt(0));
        }

        [TestMethod]
        public void ElementAt_Item_ShouldReturnItemAtPosition0FromListOf2()
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);

            Assert.AreEqual(1, list.ElementAt(0));
        }

        [TestMethod]
        public void ElementAt_Item_ShouldReturnItemAtPosition1FromListOf2()
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);

            Assert.AreEqual(2, list.ElementAt(1));
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
            var sum = 0;
            var count = 0;

            list.Add(1);
            list.Add(2);

            foreach (var element in list)
            {
                count++;
                sum += element;
            }

            Assert.AreEqual(3, sum);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetEnumerator_ShouldSumElementsOfEmptyList()
        {
            var list = new LinkedList<int>();
            var sum = 0;
            var count = 0;

            foreach (var element in list)
            {
                count++;
                sum += element;
            }

            Assert.AreEqual(0, sum);
            Assert.AreEqual(0, count);
        }
    }
}