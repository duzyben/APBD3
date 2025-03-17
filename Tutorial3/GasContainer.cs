namespace Tutorial3;


public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(int mass, double height, double tareWeight, double depth, double maxPayload) : 
        base(mass, height, tareWeight, depth, maxPayload)
    {
        SerialNumber = CreateSerialNumber();
    }


    public override string CreateSerialNumber()
    {
        string serNum = "KON-G";
        int randNum = new Random().Next();
        // TODO make sure the numbers are unique
        string serialNum = serNum + randNum;
        return serNum;
    }

    public override void EmptyCargo()
    {
        
    }

    public override void LoadCargo(double mass)
    {
        
    }

    public void SendNotification(string notification)
    {
        Console.WriteLine(notification);
        // TODO should it be virtual?
    }
}