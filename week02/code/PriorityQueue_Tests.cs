using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 Priority Queue with ascending priority numbers then remove
    // Rumi (1), Mira (2), Zoey(3) 
    // Expected Result: Zoey, Mira, Rumi
    // Defect(s) Found: The item with is not being removed with dequeue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Rumi", 1);
        priorityQueue.Enqueue("Zoey", 3);
        priorityQueue.Enqueue("Mira", 2);

        string[] expectedResult = ["Zoey", "Mira", "Rumi"];

        Debug.WriteLine($"Initial Queue: {priorityQueue.ToString()}");

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var priority = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], priority);
            i++;

            Debug.WriteLine(priority);

        }
    }

    [TestMethod]
    // Scenario: Test for items with the same priority number
    //Bobby(2),  Rumi(3), Mira(1), Zoey(1)
    // Expected Result: rumi, bobby, mira, zoey
    // Defect(s) Found: Instead of taking Mira who was added first, it takes Zoey. Dequeue is missing the functionality to handle items with FIFO with the same priority number
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bobby", 2);
        priorityQueue.Enqueue("Rumi", 3);
        priorityQueue.Enqueue("Mira", 1);
        priorityQueue.Enqueue("Zoey", 1);

        Debug.WriteLine($"Initial Queue: {priorityQueue.ToString()}");

        string[] expectedResult = ["Rumi", "Bobby", "Mira", "Zoey"];

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var priority = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], priority);
            i++;

            Debug.WriteLine(priority);

        }
    }

    [TestMethod]
    // Scenario: Create an empty priority queue and use dequeue to get an error
    // Expected Result(s): InvalidOperationException
    // Defect(s):  
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception was not thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }

        
    }
    
    // Add more test cases as needed below.
}