namespace Tutorial3;


public class GasContainer : Container
{
    public GasContainer(int mass, double height, double tareWeight, double depth, double maxPayload) : 
        base(mass, height, tareWeight, depth, maxPayload)
    {
        
    }

    protected override string GetContType() => "G";
    public override void EmptyCargo()
    {
        Mass += 0.05;
    }

    public override void LoadCargo(double mass)
    {
        if (Mass + mass > MaxPayload)
        {
            throw new InvalidOperationException($"Cannot exceed max weight {SerialNumber}");
        }
        Mass += mass;
    }
}