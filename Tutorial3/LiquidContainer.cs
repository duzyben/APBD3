namespace Tutorial3;

public class LiquidContainer : Container
{
    public bool ContainsHazard { get; set; }
    public LiquidContainer(int mass, double height, double tareWeight, double depth, double maxPayload, bool containsHazard) : 
        base(mass, height, tareWeight, depth, maxPayload)
    {
        ContainsHazard = containsHazard;
    }

    protected override string GetContType() => "L";
    public override void EmptyCargo()
    {
        Mass = 0;
    }

    public override void LoadCargo(double mass)
    {
        double maxMass = ContainsHazard ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (Mass + mass > maxMass)
        {
            throw new Exception($"Maximum weight exceeded in container {SerialNumber}");
        }
        Mass += mass;
    }
    
    public override void SendNotification(string message)
    {
        Console.WriteLine($"HAZARD ALERT: {message} | Container: {SerialNumber} (Hazardous: {ContainsHazard})");
    }
}