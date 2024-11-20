namespace Assignment329C;

public class BottleFillOperationRunner
{
    private readonly Bottle _firstBottle;
    private readonly Bottle _secondBottle;

    public static BottleFillOperation[] BottleFillOperations = [
        new("Fylle flaske 1 fra springen", 0),
        new("Fylle flaske 2 fra springen", 1),
        new("Tømme flaske 1 i flaske 2", 2),
        new("Tømme flaske 2 i flaske 1", 3),
        new("Fylle opp flaske 2 med flaske 1", 4),
        new("Fylle opp flaske 1 med flaske 2", 5),
        new("Tømme flaske 1 (kaste vannet)", 6),
        new("Tømme flaske 2 (kaste vannet)", 7),
    ];

    

    public BottleFillOperationRunner(Bottle firstBottle, Bottle secondBottle)
    {
        _firstBottle = firstBottle;
        _secondBottle = secondBottle;
    }
    
    public void Run()
    {
        _firstBottle.Empty();
        _secondBottle.Empty();
        foreach (var bottleFillOperation in BottleFillOperations)
        {
            var operation = bottleFillOperation.Id;
            
            if (operation == 0) _firstBottle.FillToTopFromTap();         // Fylle flaske 1 fra springen
            else if (operation == 1) _secondBottle.FillToTopFromTap();    // Fylle flaske 2 fra springen
            else if (operation == 2) _secondBottle.Fill(_firstBottle.Empty()); // Tømme flaske 1 i flaske 2 - 
            // Tanken er at Empty() returnerer hvor mye det var i flasken før den ble tømt
            else if (operation == 3) _firstBottle.Fill(_secondBottle.Empty()); // Tømme flaske 2 i flaske 1
            else if (operation == 4) _secondBottle.FillToTop(_firstBottle);    // Fylle opp flaske 2 med flaske 1
            // Tanken er at FillToTop tar en annen Bottle som parameter. Hvis det er nok, fyller den 
            // bottle2 og reduserer bottle1 tilsvarende. Hvis ikke gjør den ingenting.
            else if (operation == 5) _firstBottle.FillToTop(_secondBottle);    // Fylle opp flaske 1 med flaske 2
            else if (operation == 6) _firstBottle.Empty();               // Tømme flaske 1 (kaste vannet)
            else if (operation == 7) _secondBottle.Empty();               // Tømme flaske 2 (kaste vannet)
        }
    }
}