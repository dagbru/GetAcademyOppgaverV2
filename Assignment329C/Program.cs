using Assignment329C;

var simulation = new Simulation(1, 2, 2);
var operationSet = simulation.Run();
Console.WriteLine(operationSet.GetDescription());