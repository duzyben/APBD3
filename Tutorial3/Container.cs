namespace Tutorial3;
public abstract class Container : IHazardNotifier
{
    public double Mass { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxPayload { get; set; }
    private static int _counter = 1;

    public Container(int mass, double height, double tareWeight, double depth, double maxPayload)
    {
        Mass = mass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        SerialNumber = CreateSerialNumber();
        MaxPayload = maxPayload;
    }

    public string CreateSerialNumber()
    {
        return $"KON-{GetContType()}-{_counter++}";
    }

    protected abstract string GetContType();


    public abstract void EmptyCargo();
    
    public abstract void LoadCargo(double mass);
    
    public virtual void SendNotification(string notification)
    {
        Console.WriteLine($"ALERT: {notification}. Container: {SerialNumber}");
    }
    
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Serial: {SerialNumber}, Type: {GetContType()}, Mass: {Mass}, Max Payload: {MaxPayload}");
    }

}