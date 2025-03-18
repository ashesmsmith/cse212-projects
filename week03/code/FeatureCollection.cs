public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    public List<Features> Features { get; set; } // List of earthquakes and their data
}

public class Features
{
    public Properties Properties { get; set; } // Access properties of an individual earthquake
}

public class Properties
{
    public decimal Mag { get; set; }
    public string Place { get; set; }
}