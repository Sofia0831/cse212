/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Customer queue is less than 0
        // Expected Result: 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(-2);
        Console.WriteLine($"size is {cs._maxSize}");

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add customerservice with more than 0, 5
        // Expected Result: 5
        Console.WriteLine("Test 2");
        cs = new CustomerService(5);
        Console.WriteLine($"size is {cs._maxSize}");



        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: Add a customer with details and then serve
        // Expected Result: customer details + serve customer
        Console.WriteLine("Test 3");
        cs = new CustomerService(1);
        var cust = new CustomerService.Customer("Xavier", "01K", "Broken Phone Screen");
        Console.WriteLine($"Customer Details: {cust}");
        cs.ServeCustomer();



        Console.WriteLine("=================");


        // Test 4
        // Scenario: Add a new customer normally
        // Expected Result: Display details and then Serve Customer
        Console.WriteLine("Test 4");
        cs = new CustomerService(5);
        cs.AddNewCustomer();
        Console.WriteLine($"customer details: {cs}");
        cs.AddNewCustomer();
        Console.WriteLine($"customer details: {cs}");


        Console.WriteLine("=================");

        // Test 5
        // Scenario: Add more customer than queue
        // Expected Result: Should be an error saying that queue is full
        Console.WriteLine("Test 5");
        cs = new CustomerService(1);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine($"queue: {cs._maxSize}");

        Console.WriteLine("=================");

        // Test 6
        // Scenario:
        // Expected Result: 
        Console.WriteLine("Test 6");
        cs = new CustomerService(4);
        cs.AddNewCustomer();
        cs.ServeCustomer();

        Console.WriteLine("=================");
        
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        // Fix
        if (_queue.Count >= _maxSize)
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
    private void ServeCustomer() {
        // Fix
        if (_queue.Count == 0)
        {
            Console.WriteLine("All customers have been served, queue is empty");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
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
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}