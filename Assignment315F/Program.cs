
using Assignment315F;
using Assignment315F.Enums;

var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

var board = new Board(numbers);

var input = string.Empty;
while (input != "e")
{
    board.PrintBoard();
    input = Console.ReadLine();
    if (!Enum.TryParse(input, out MoveDirection direction))
    {
        Console.WriteLine("Invalid choice. Valid: 'Up', 'Down', 'Left', 'Right'.");
        continue;
    }
    
    board.Move(direction);
    
    if (board.IsCompleted())
    {
        Console.WriteLine("You did it!");
        break;
    }
}