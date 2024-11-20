 namespace Assignment329C;

 public class OperationSet
    {
        private readonly int[] _operations;
        private readonly Simulation _simulation;
        public int Length => _operations.Length;

        private static string[] operationNames = new[]
        {
            "Fylle flaske 1 fra springen",
            "Fylle flaske 2 fra springen",
            "Tømme flaske 1 i flaske 2",
            "Tømme flaske 2 i flaske 1",
            "Fylle opp flaske 2 med flaske 1",
            "Fylle opp flaske 1 med flaske 2",
            "Tømme flaske 1 (kaste vannet)",
            "Tømme flaske 2 (kaste vannet)",
        };


        public OperationSet(int numberOfOperations, Simulation simulation)
        {
            _simulation = simulation;
            _operations = new int[numberOfOperations];
        }

        public void RunOne()
        {
            var bottle1 = _simulation.Bottle1;
            var bottle2 = _simulation.Bottle2;
            bottle1.Empty();
            bottle2.Empty();
            foreach (var operation in _operations)
            {
                if (operation == 0) bottle1.FillToTopFromTap();         // Fylle flaske 1 fra springen
                else if (operation == 1) bottle2.FillToTopFromTap();    // Fylle flaske 2 fra springen
                else if (operation == 2) bottle2.Fill(bottle1.Empty()); // Tømme flaske 1 i flaske 2 - 
                // Tanken er at Empty() returnerer hvor mye det var i flasken før den ble tømt
                else if (operation == 3) bottle1.Fill(bottle2.Empty()); // Tømme flaske 2 i flaske 1
                else if (operation == 4) bottle2.FillToTop(bottle1);    // Fylle opp flaske 2 med flaske 1
                // Tanken er at FillToTop tar en annen Bottle som parameter. Hvis det er nok, fyller den 
                // bottle2 og reduserer bottle1 tilsvarende. Hvis ikke gjør den ingenting.
                else if (operation == 5) bottle1.FillToTop(bottle2);    // Fylle opp flaske 1 med flaske 2
                else if (operation == 6) bottle1.Empty();               // Tømme flaske 1 (kaste vannet)
                else if (operation == 7) bottle2.Empty();               // Tømme flaske 2 (kaste vannet)
            }
        }

        public bool Next()
        {
            int i;
            for (i = _operations.Length - 1; i >= 0; i--)
            {
                if (_operations[i] < 7)
                {
                    _operations[i]++;
                    break;
                }
                _operations[i] = 0;
            }
            return i != -1;
        }

        public string GetDescription()
        {
            var description = "";
            for (var i = 0; i < _operations.Length; i++)
            {
                var operation = _operations[i];
                description += (i + 1) + ": " + operationNames[operation] + "\n";
            }

            return description;
        }

        public void RunAll()
        {
            Console.WriteLine("Prøver med " + _operations.Length + " operasjon(er).");
            do
            {
                RunOne();
                if (_simulation.IsSolved)
                {
                    return;
                }
            } while (Next());
        }
    }