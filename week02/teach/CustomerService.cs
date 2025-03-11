/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // * Test 1
        // Scenario: User enters an invalid size for the queue
        // Expected Result: max_size = 10 (default)
        Console.WriteLine("Test 1 - Invalid size entered - Default to 10");
        var zeroQueue = new CustomerService(0);
        var negativeQueue = new CustomerService(-1);
        Console.WriteLine(zeroQueue);
        Console.WriteLine(negativeQueue);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // * Test 2
        // Scenario: User enters a valid result for the queue
        // Expected Result: max_size = 11
        Console.WriteLine("Test 2 - Valid size entered and used");
        var queue = new CustomerService(3);
        Console.WriteLine(queue);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // * Test 3
        // Scenario: Set queue to 1 > Add a Customer to the queue
        // Expected Result: 'After' should be 1 higher than 'Before'
        Console.WriteLine("Test 3 - Queue count increase by 1");
        var queueSize1 = queue._queue.Count;
        Console.WriteLine("Count Before: " + queueSize1);
        queue.AddNewCustomer(); // Customer 1
        var queueSize2 = queue._queue.Count;
        Console.WriteLine("Count After: " + queueSize2);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // * Test 4
        // Scenario: Remove a customer from the queue and display details
        // Expected Result: Customer 1 Information should be displayed
        Console.WriteLine("Test 4 - Add to queue and then remove the first customer");
        queue.AddNewCustomer(); // Customer 2
        queue.AddNewCustomer(); // Customer 3
        queue.ServeCustomer();

        // Defect(s) Found: Customer Information displayed is not correct
        // Customer was removed before the information was retrieved for display

        Console.WriteLine("=================");

        // * Test 5
        // Scenario: Try to add Customer to full queue
        // Expected Result: Error Message Displayed
        Console.WriteLine("Test 5 - Add customer to a full queue - Display error message");
        queue.AddNewCustomer(); // Customer 4
        queue.AddNewCustomer(); // Customer 5
        var queueSize3 = queue._queue.Count;
        Console.WriteLine("Max size is 3. Queue is " + queueSize3);

        // Defect(s) Found: Customer was queued instead of receiving an error
        // If statement was missing an = to prevent adding if queue was already at max

        Console.WriteLine("=================");

        // * Test 6
        // Scenario: 
        // Expected Result:
        Console.WriteLine("Test 6 - Attempt to remove from empty queue - Display error message");
        var emptyQueue = new CustomerService(5);
        emptyQueue.ServeCustomer();

        // Defect(s) Found: Code breaks. Need to check count in queue and proceed as needed

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }


    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) // Added = to so none can be added if full
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("There are no customers in queue.");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0); // Moved to remove customer after information is retrieved
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}