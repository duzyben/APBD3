namespace Tutorial3;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }
    public double RequiredTemp { get; private set; }
    public double CurrentTemp { get; private set; }
    
    public RefrigeratedContainer(int mass, double height, double tareWeight, double depth, double maxPayload, string productType, double requiredTemp) : 
        base(mass, height, tareWeight, depth, maxPayload)
    {
        ProductType = productType;
        RequiredTemp = requiredTemp;
    }

    public void SetTemp(double temp)
    {
        if (temp < RequiredTemp)
        {
            throw new InvalidOperationException($"Temperature is too low for {ProductType} in {SerialNumber}");
        }
        CurrentTemp = temp;
    }
    
    public void Store(string product, double requiredTemp)
    {
        if (ProductType != null && ProductType != product)
        {
            throw new InvalidOperationException("You can only store one type of product in the container.");
        }
        ProductType = product;
        RequiredTemp = requiredTemp;
    }

    protected override string GetContType() => "C";
    
    public override void EmptyCargo()
    {
        Mass = 0;
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