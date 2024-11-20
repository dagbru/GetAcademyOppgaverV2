namespace Assignment329C;

public class BottleFillSimulator
{
    private readonly int _wantedVolume;
    private readonly Bottle _firstBottle;
    private readonly Bottle _secondBottle;

    public BottleFillSimulator(int wantedVolume, Bottle firstBottle, Bottle secondBottle)
    {
        _wantedVolume = wantedVolume;
        _firstBottle = firstBottle;
        _secondBottle = secondBottle;
    }

    public void RunSimulation()
    {
        var bottleFillOperationRunner = new BottleFillOperationRunner(_firstBottle, _secondBottle);
        var numberOfOperations = 1;
        
        foreach (var bottleFillOperation in BottleFillOperationRunner.BottleFillOperations)
        {
            bottleFillOperationRunner.Run();
        }
        
    }
}