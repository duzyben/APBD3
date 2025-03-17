namespace Tutorial3;
public abstract class Container
{
    public double Mass { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxPayload { get; set; }

    public Container(int mass, double height, double tareWeight, double depth, double maxPayload)
    {
        Mass = mass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        //SerialNumber = CreateSerialNumber();
        //TODO can it be here or in inherited class
        MaxPayload = maxPayload;
    }

    public abstract string CreateSerialNumber();


    public abstract void EmptyCargo();
   

    public abstract void LoadCargo(double mass);
}