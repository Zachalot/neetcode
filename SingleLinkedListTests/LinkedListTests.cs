using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SingleLinkedList;

// This assumes your LinkedList and Node classes are in the same namespace or a referenced project.
// Replace "YourProjectNamespace" with the actual namespace.
namespace SingleLinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        // Test 1: Verify a new list is empty and has a size of 0.
        [TestMethod]
        public void LinkedList_InitializesCorrectly_ReturnsSizeZero()
        {
            // Arrange
            LinkedList list = new LinkedList();

            // Assert
            Assert.AreEqual(0, list.size, "The size of a new list should be 0.");
        }

        // Test 2: Insert one element at the head and verify the size and value.
        [TestMethod]
        public void InsertHead_OnEmptyList_CorrectlyAddsElementAndUpdatesSize()
        {
            // Arrange
            LinkedList list = new LinkedList();
            int valueToInsert = 10;

            // Act
            list.InsertHead(valueToInsert);

            // Assert
            Assert.AreEqual(1, list.size, "Size should be 1 after one insertion.");
            Assert.AreEqual(valueToInsert, list.Get(0), "The value at index 0 should be the inserted value.");
        }

        // Test 3: Insert multiple elements at the head and verify the order.
        [TestMethod]
        public void InsertHead_OnNonEmptyList_CorrectlyAddsElementsInReverseOrder()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertHead(1);
            list.InsertHead(2);
            list.InsertHead(3);

            // Assert
            Assert.AreEqual(3, list.size, "Size should be 3 after three insertions.");
            Assert.AreEqual(3, list.Get(0), "The first element should be the last one inserted.");
            Assert.AreEqual(2, list.Get(1));
            Assert.AreEqual(1, list.Get(2), "The last element should be the first one inserted.");
        }

        // Test 4: Insert an element at the tail of an empty list.
        [TestMethod]
        public void InsertTail_OnEmptyList_CorrectlyAddsElementAndUpdatesSize()
        {
            // Arrange
            LinkedList list = new LinkedList();
            int valueToInsert = 50;

            // Act
            list.InsertTail(valueToInsert);

            // Assert
            Assert.AreEqual(1, list.size, "Size should be 1 after inserting to tail.");
            Assert.AreEqual(valueToInsert, list.Get(0), "The element should be at index 0.");
        }

        // Test 5: Insert multiple elements at the tail.
        [TestMethod]
        public void InsertTail_OnNonEmptyList_CorrectlyAddsElementsAndMaintainsOrder()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertHead(10);
            list.InsertHead(20);

            // Act
            list.InsertTail(30);
            list.InsertTail(40);

            // Assert
            Assert.AreEqual(4, list.size, "Size should be 4 after insertions.");
            Assert.AreEqual(20, list.Get(0), "Head should still be 20.");
            Assert.AreEqual(10, list.Get(1), "Next element should still be 10.");
            Assert.AreEqual(30, list.Get(2), "The first tail-inserted value should be at index 2.");
            Assert.AreEqual(40, list.Get(3), "The last tail-inserted value should be at the end.");
        }

        // Test 6: Get an element from the middle of the list.
        [TestMethod]
        public void Get_FromMiddleOfList_ReturnsCorrectValue()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertTail(1);
            list.InsertTail(2);
            list.InsertTail(3);
            list.InsertTail(4);

            // Act
            int value = list.Get(2);

            // Assert
            Assert.AreEqual(3, value, "Should retrieve the value at the middle index.");
        }

        // Test 7: Get from an index that is out of bounds (negative).
        [TestMethod]
        public void Get_WithNegativeIndex_ReturnsNegativeOne()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertHead(1);

            // Act
            int value = list.Get(-1);

            // Assert
            Assert.AreEqual(-1, value, "Get should return -1 for a negative index.");
        }

        // Test 8: Get from an index that is out of bounds (too large).
        [TestMethod]
        public void Get_WithIndexGreaterThanSize_ReturnsNegativeOne()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertHead(1);

            // Act
            int value = list.Get(10);

            // Assert
            Assert.AreEqual(-1, value, "Get should return -1 for an index greater than or equal to the size.");
        }

        // Test 9: Remove the head of a multi-element list.
        [TestMethod]
        public void Remove_HeadOfMultiElementList_RemovesCorrectlyAndUpdatesSize()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertTail(10);
            list.InsertTail(20);
            list.InsertTail(30);

            // Act
            bool result = list.Remove(0);

            // Assert
            Assert.IsTrue(result, "Remove operation should succeed.");
            Assert.AreEqual(2, list.size, "Size should be 2 after removal.");
            Assert.AreEqual(20, list.Get(0), "The new head should be the second element.");
        }

        // Test 10: Remove a middle element.
        [TestMethod]
        public void Remove_MiddleElement_RemovesCorrectly()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertTail(10);
            list.InsertTail(20);
            list.InsertTail(30);

            // Act
            list.Remove(1);

            // Assert
            Assert.AreEqual(2, list.size, "Size should be 2.");
            Assert.AreEqual(10, list.Get(0));
            Assert.AreEqual(30, list.Get(1), "The element after the removed one should be at the correct index.");
        }

        // Test 11: Remove the tail of a multi-element list.
        [TestMethod]
        public void Remove_TailOfMultiElementList_RemovesCorrectly()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertTail(10);
            list.InsertTail(20);
            list.InsertTail(30);

            // Act
            bool result = list.Remove(2);

            // Assert
            Assert.IsTrue(result, "Remove operation should succeed.");
            Assert.AreEqual(2, list.size, "Size should be 2.");
            Assert.AreEqual(10, list.Get(0));
            Assert.AreEqual(20, list.Get(1));
            Assert.AreEqual(-1, list.Get(2), "The old tail index should now be out of bounds.");
        }

        // Test 12: Remove the only element in the list.
        [TestMethod]
        public void Remove_OnlyElementInList_RemovesCorrectlyAndEmptiesList()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertHead(5);

            // Act
            bool result = list.Remove(0);

            // Assert
            Assert.IsTrue(result, "Remove should succeed.");
            Assert.AreEqual(0, list.size, "Size should be 0.");
            Assert.AreEqual(-1, list.Get(0), "List should be empty, so Get should return -1.");
        }

        // Test 13: Attempt to remove from an empty list.
        [TestMethod]
        public void Remove_FromEmptyList_ReturnsFalse()
        {
            // Arrange
            LinkedList list = new LinkedList();

            // Act
            bool result = list.Remove(0);

            // Assert
            Assert.IsFalse(result, "Remove on an empty list should return false.");
            Assert.AreEqual(0, list.size, "Size should remain 0.");
        }

        // Test 14: Attempt to remove with a negative index.
        [TestMethod]
        public void Remove_WithNegativeIndex_ReturnsFalse()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertHead(100);

            // Act
            bool result = list.Remove(-1);

            // Assert
            Assert.IsFalse(result, "Remove with negative index should return false.");
            Assert.AreEqual(1, list.size, "Size should not change.");
        }

        // Test 15: Verify that GetValues returns a correct list of values.
        [TestMethod]
        public void GetValues_OnNonEmptyList_ReturnsCorrectList()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.InsertTail(10);
            list.InsertTail(20);
            list.InsertTail(30);
            List<int> expected = new List<int> { 10, 20, 30 };

            // Act
            List<int> actual = list.GetValues();

            // Assert
            CollectionAssert.AreEqual(expected, actual, "The returned list of values is incorrect.");
        }
    }
}
