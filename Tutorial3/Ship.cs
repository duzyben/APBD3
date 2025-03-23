namespace Tutorial3;

public class Ship
{
    public List<Container> Containers { get; set; } = new List<Container>();
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public double MaxWeight { get; set; }

    public Ship(double maxSpeed, int maxContainers, double maxWeight)
    {
        this.MaxSpeed = maxSpeed;
        this.MaxContainers = maxContainers;
        this.MaxWeight = maxWeight;
    }

    public double GetWeight()
    {
        return Containers.Sum(c => c.Mass + c.TareWeight) / 1000;
    }
    
    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
        {
            throw new InvalidOperationException("Exceeded maximum number of containers.");
        }
        if (GetWeight() + ((container.Mass + container.TareWeight) / 1000.0) > MaxWeight)
        {
            throw new InvalidOperationException("Exceeded maximum weight.");
        }
        Containers.Add(container);
    }
    
    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new InvalidOperationException($"Container {serialNumber} wasn't found");
        }
        Containers.Remove(container);
    }

    public void ReplaceContainer(string oldSerial, Container newContainer)
    {
        RemoveContainer(oldSerial);
        LoadContainer(newContainer);
    }

    public void TransferContainer(Ship targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new InvalidOperationException("Container wasn't found.");
        }
        RemoveContainer(serialNumber);
        targetShip.LoadContainer(container);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Informations about the ship:\nMax Speed: {MaxSpeed} \nMax Containers: {MaxContainers}\nMax Weight: {MaxWeight}");
        Console.WriteLine($"Cargo: {Containers.Count} containers \nCurrent Weight: {GetWeight()}");
        foreach (var c in Containers)
        {
           c.PrintInfo();
        }
    }
}
