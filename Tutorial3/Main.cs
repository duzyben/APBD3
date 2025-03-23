namespace Tutorial3;

public class MainClass
{
    public static void Main()
    {
        // Creating a container of given type
        GasContainer gasContainer = new GasContainer(5000, 2.5, 1000, 6.0, 10000);
        LiquidContainer liquidContainer = new LiquidContainer(3000, 3.0, 1200, 6.0, 12000, containsHazard: true);
        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(6000, 2.8, 1100, 6.0, 9000, "Meat", -18);
        
        //Loading cargo into a given container
        gasContainer.LoadCargo(2000);
        liquidContainer.LoadCargo(1000);
        refrigeratedContainer.LoadCargo(2000);
        
        //Loading a container onto a ship
        Ship ship = new Ship(maxSpeed: 30, maxContainers: 3, maxWeight: 50);
        ship.LoadContainer(gasContainer);
        ship.PrintInfo();
        
        //Load a list of containers onto a ship
        List<Container> containers = new List<Container>();
        containers.Add(liquidContainer);
        containers.Add(refrigeratedContainer);
        ship.LoadContainers(containers);
        ship.PrintInfo();
        
        //Remove a container from the ship
        ship.RemoveContainer(gasContainer.SerialNumber);
        ship.PrintInfo();
        
        //Unload a container
        liquidContainer.EmptyCargo();
        
        //Replace a container
        GasContainer newGasContainer = new GasContainer(5500, 2.6, 950, 5.5, 9500);
        ship.ReplaceContainer(liquidContainer.SerialNumber, newGasContainer);
        
        //Transfer container between two ships 
        Ship newShip = new Ship(maxSpeed: 30, maxContainers: 3, maxWeight: 50);
        ship.TransferContainer(newShip, refrigeratedContainer.SerialNumber);
        
        // Print info
        ship.PrintInfo();
        newShip.PrintInfo();
    }
}