using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add a new item (data and priority) to the end of the queue and remove by priority
    // Expected Result: [e, d, c, b, a]
    // Defect(s) Found: Items are queued correctly but are not dequeued
    public void TestPriorityQueue_1()
    {
        var a = new PriorityItem("a", 1);
        var b = new PriorityItem("b", 3);
        var c = new PriorityItem("c", 2);
        var d = new PriorityItem("d", 5);
        var e = new PriorityItem("e", 4);

        PriorityItem[] expectedResult = [d, e, b, c, a];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(a.Value, a.Priority);
        priorityQueue.Enqueue(b.Value, b.Priority);
        priorityQueue.Enqueue(c.Value, c.Priority);
        priorityQueue.Enqueue(d.Value, d.Priority);
        priorityQueue.Enqueue(e.Value, e.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add 2 items with the same priority and remove the first one in the list
    // Expected Result: [w, v, x, y, z]
    // Defect(s) Found: Removing the last item with high priority instead of the first
    public void TestPriorityQueue_2()
    {
        var z = new PriorityItem("z", 1);
        var y = new PriorityItem("y", 4);
        var x = new PriorityItem("x", 2);
        var w = new PriorityItem("w", 4);
        var v = new PriorityItem("v", 3);

        PriorityItem[] expectedResult = [y, w, v, x, z];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(z.Value, z.Priority);
        priorityQueue.Enqueue(y.Value, y.Priority);
        priorityQueue.Enqueue(x.Value, x.Priority);
        priorityQueue.Enqueue(w.Value, w.Priority);
        priorityQueue.Enqueue(v.Value, v.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Return an error message if the queue is empty
    // Expected Result: Error Message
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
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
        catch (AssertFailedException)
        {
            throw;
        }
    }

    // Add more test cases as needed below.
}