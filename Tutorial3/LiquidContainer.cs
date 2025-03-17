namespace Tutorial3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool ContainsHazard { get; set; }
    public LiquidContainer(int mass, double height, double tareWeight, double depth, double maxPayload, bool containsHazard) : 
        base(mass, height, tareWeight, depth, maxPayload)
    {
        SerialNumber = CreateSerialNumber();
        ContainsHazard = containsHazard;
    }


    public override string CreateSerialNumber()
    {
        string serNum = "KON-L";
        int randNum = new Random().Next();
        // TODO make sure the numbers are unique
        string serialNum = serNum + randNum;
        return serNum;
    }

    public override void EmptyCargo()
    {
        
    }

    public override void LoadCargo(double addMass)
    {
        if (ContainsHazard)
        {
            if (addMass + Mass <= 0.5 * MaxPayload)
            {
                Mass += addMass;
            }
            else
            {
                Console.WriteLine("Attempt to perform a dangerous operation: weight of hazardous cargo can't exceed 50%");
            }
        }
        else
        {
            if (addMass + Mass <= 0.9 * MaxPayload)
            {
                Mass += addMass;
            }
            else
            {
                Console.WriteLine("Attempt to perform a dangerous operation: weight of cargo can't exceed 90%");
            }
        }
    }

    public void SendNotification(string notification)
    {
        Console.WriteLine(notification + SerialNumber);
        // TODO should it be virtual?
        // how to implement serial number?
    }
}