public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public int Length => _queue.Count; // Added for testing purposes

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        for (int index = 0; index < _queue.Count; index++) // Changed index from 1 to 0. Removed -1 after .Count
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority) // Removed = to prevent index from changing if multiple have same high priority
                highPriorityIndex = index;
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // Added to remove the item from queue
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}