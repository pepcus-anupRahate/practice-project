
class Program
{
    static void Main(string[] args)
    {
        //Ask the user to Select the Travel Type
        Console.WriteLine("Please Enter Travel Type : \n1 for Auto \n2 for Bus \n3 for Train \n4 for Taxi");

        int travelType = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("You Select Travel type : " + travelType);

        //Create an Instance of the TravelContext class
        TravelContext ctx = new TravelContext();

        //Based on the Travel Type Selected by user at Runtime,
        //Create the Appropriate Travel Instance and call the SetTravelStrategy method
        if (travelType == (int)TravelType.Bus)
        {
            ctx.SetTravelStrategy(new BusTravelStrategy());
        }
        else if (travelType == (int)TravelType.Train)
        {
            ctx.SetTravelStrategy(new TrainTravelStrategy());
        }
        else if (travelType == (int)TravelType.Taxi)
        {
            ctx.SetTravelStrategy(new TaxiTravelStrategy());
        }
        else if (travelType == (int)TravelType.Auto)
        {
            ctx.SetTravelStrategy(new AutoTravelStrategy());
        }
        else
        {
            Console.WriteLine("You Select an Invalid Option");
        }

        //Finally, call the GotoAirport Method
        ctx.GotoAirport();
        Console.Read();
    }
}
public enum TravelType
{
    Auto = 1,  // 1 for Auto
    Bus = 2,   // 2 for Bus
    Train = 3, // 3 for Train
    Taxi = 4  // 4 for Taxi
}

public interface ITravelStrategy
{
    void GotoAirport();
}

// Concrete Strategy A
// The following AutoTravelStrategy Concrete Strategy implement the ITravelStrategy Interface and 
// Implement the GotoAirport Method. 
public class AutoTravelStrategy : ITravelStrategy
{
    public void GotoAirport()
    {
        Console.WriteLine("Traveler is going to Airport by Auto and will be charged Rs 600");
    }
}

// Concrete Strategy B
// The following TrainTravelStrategy Concrete Strategy implement the ITravelStrategy Interface and 
// Implement the GotoAirport Method. 
public class TrainTravelStrategy : ITravelStrategy
{
    public void GotoAirport()
    {
        Console.WriteLine("Traveler is going to Airport by Train and will be charged Rs 200");
    }
}

// Concrete Strategy C
// The following TaxiTravelStrategy Concrete Strategy implement the ITravelStrategy Interface and 
// Implement the GotoAirport Method. 
public class TaxiTravelStrategy : ITravelStrategy
{
    public void GotoAirport()
    {
        Console.WriteLine("Traveler is going to Airport by Taxi and will be charged Rs 1000");
    }
}

// Concrete Strategy D
// The following BusTravelStrategy Concrete Strategy implement the ITravelStrategy Interface and 
// Implement the GotoAirport Method. 
public class BusTravelStrategy : ITravelStrategy
{
    public void GotoAirport()
    {
        Console.WriteLine("Traveler is going to Airport by bus and will be charged Rs 300");
    }
}

public class TravelContext
{
    // The Context has a reference to one of the Strategy objects.
    // The Context does not know the concrete class of a strategy. 
    // It should work with all strategies via the Strategy interface.
    private ITravelStrategy? travelStrategy;
    // The Client will set what TravelStrategy to use by calling this method at runtime
    public void SetTravelStrategy(ITravelStrategy strategy)
    {
        travelStrategy = strategy;
    }
    // The Context delegates the work to the Strategy object instead of
    // implementing multiple versions of the algorithm on its own.
    public void GotoAirport()
    {
        travelStrategy?.GotoAirport();
    }
}