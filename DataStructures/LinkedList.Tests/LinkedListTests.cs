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
        public void Add_Item_ShouldAddNodeToNotEptyList()
        {
            var list = new LinkedList<int>();
            list.Add(5);
            list.Add(2);
            Assert.AreEqual(list.Tail.Item, 2);
            Assert.AreEqual(list.Head.Item, 5);
            Assert.AreEqual(list.Size, 2);
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
    }
}
