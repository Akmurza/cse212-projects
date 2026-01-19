using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue one item and dequeue it.
    // Expected Result: Returns the item.
    // Defect(s) Found: None, this should work.
    public void TestPriorityQueue_EnqueueDequeueOne()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities, dequeue should return highest priority.
    // Expected Result: C (priority 3), then B (2), then A (1).
    // Defect(s) Found: Dequeue did not remove the item from the queue, the loop to find highest priority was incorrect (wrong bounds and logic), and for ties it removed the wrong item.
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);
        var result1 = priorityQueue.Dequeue();
        Assert.AreEqual("C", result1);
        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("B", result2);
        var result3 = priorityQueue.Dequeue();
        Assert.AreEqual("A", result3);
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority, dequeue should return first enqueued.
    // Expected Result: A, then B, then C.
    // Defect(s) Found: Same as above.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 1);
        var result1 = priorityQueue.Dequeue();
        Assert.AreEqual("A", result1);
        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("B", result2);
        var result3 = priorityQueue.Dequeue();
        Assert.AreEqual("C", result3);
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue.
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Mix of priorities, ensure highest is dequeued first, and for same, FIFO.
    // Expected Result: D (4), C (3), A (2), B (2, but A was first), E (1).
    // Defect(s) Found: Same as above.
    public void TestPriorityQueue_Mixed()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 4);
        priorityQueue.Enqueue("E", 1);
        var result1 = priorityQueue.Dequeue();
        Assert.AreEqual("D", result1);
        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("C", result2);
        var result3 = priorityQueue.Dequeue();
        Assert.AreEqual("A", result3);
        var result4 = priorityQueue.Dequeue();
        Assert.AreEqual("B", result4);
        var result5 = priorityQueue.Dequeue();
        Assert.AreEqual("E", result5);
    }

    // Add more test cases as needed below.
}