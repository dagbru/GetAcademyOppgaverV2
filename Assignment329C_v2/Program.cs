var firstBottle = new Bottle(1);
var secondBottle = new Bottle(2);
const int wantedVolume = 1;

var numberOfOperations = 1;
var maxOperations = 20;
int[] operations;

var attempts = 0;
var isSolved = false;

while (numberOfOperations < maxOperations)
{
    operations = new int[numberOfOperations];
    numberOfOperations++;
    while (!isSolved)
    {
        firstBottle.Empty();
        secondBottle.Empty();

        var operationsPerformed = new List<string>();
        foreach (var operation in operations)
        {
            switch (operation)
            {
                case 0:
                    firstBottle.FillToTopFromTap();
                    operationsPerformed.Add("Fylte først flaske");
                    break;
                case 1:
                    secondBottle.FillToTopFromTap();
                    operationsPerformed.Add("Fylte andre flaske");
                    break;
                case 2:
                    secondBottle.Fill(firstBottle.Empty());
                    operationsPerformed.Add("Tømme første flaske i andre flaske");
                    break;
                case 3:
                    firstBottle.Fill(secondBottle.Empty());
                    operationsPerformed.Add("Tømme andre flaske i første flaske");
                    break;
                case 4:
                    secondBottle.FillToTop(firstBottle);
                    operationsPerformed.Add("Fylle opp andre flaske med første flaske");
                    break;
                case 5:
                    firstBottle.FillToTop(secondBottle);
                    operationsPerformed.Add("Fylle opp første flaske med andre flaske");
                    break;
                case 6:
                    firstBottle.Empty();
                    operationsPerformed.Add("Tømme første flaske");
                    break;
                case 7:
                    secondBottle.Empty();
                    operationsPerformed.Add("Tømme andre flaske");
                    break;
            }

            if (firstBottle.Content == wantedVolume || secondBottle.Content == wantedVolume)
            {
                Console.WriteLine($"Fant ønsket volum ved operasjon {operation}. Forsøk nr {attempts}");
                Console.WriteLine("Operations performed: ");
                foreach (var performedOperation in operationsPerformed)
                {
                    Console.WriteLine(performedOperation);
                }

                isSolved = true;
            }
        }

        if (!UpdateOperations())
        {
            break;
        }

        attempts++;
    }
}


bool UpdateOperations()
{
    int i;
    for (i = operations.Length - 1; i >= 0; i--)
    {
        if (operations[i] < 7)
        {
            operations[i]++;
            break;
        }

        operations[i] = 0;
    }

    return i != -1;
}