using Assignment315F.Enums;

namespace Assignment315F;

public class Board
{
    private readonly List<int> _numbers;
    private const int NumbersPerRow = 3;
    private const int EmptyNumber = -1;
    private readonly List<BoardRow> _rows;

    public Board(IEnumerable<int> numbers)
    {
        _numbers = AddEmptyAndRandomize(numbers);
        _rows = CreateRows();
    }
    
    public void Move(MoveDirection direction)
    {
        var currentRowWithEmpty = _rows.First(x => x.Numbers.Contains(EmptyNumber));
        var currentEmptyIndexInRow = currentRowWithEmpty.Numbers.Index().FirstOrDefault(x => x.Item == EmptyNumber).Index;

        var isValidMove = IsValidMove(direction, currentRowWithEmpty, currentEmptyIndexInRow);

        if (!isValidMove)
        {
            Console.WriteLine("Invalid move. Try again");
            return;
        }

        var moveToRowAndIndex = GetMoveToRowAndIndex(direction, currentRowWithEmpty, currentEmptyIndexInRow);

        MoveNumbers(currentRowWithEmpty, moveToRowAndIndex);
    }

    private List<int> AddEmptyAndRandomize(IEnumerable<int> numbers)
    {
        return numbers
            .Prepend(-1)
            .OrderBy(_ => Guid.NewGuid())
            .ToList();
    }

    public bool IsCompleted()
    {
        var currentOrder = _rows.SelectMany(x => x.Numbers).ToList().SkipLast(1).ToList();
        var correctOrder = _numbers.Where(x => x != EmptyNumber).OrderBy(x => x).ToList();
        
        for (var i = 0; i < currentOrder.Count; i++)
        {
            if (currentOrder[i] != correctOrder[i])
                return false;
        }

        return true;
    }

    private MoveToRowAndIndex GetMoveToRowAndIndex(MoveDirection direction, BoardRow boardRow, int currentEmptyIndexInRow)
    {
        var moveToRowType = boardRow.RowType;
        var moveToRowIndex = -1;

        switch (direction)
        {
            case MoveDirection.Up:
            {
                moveToRowType = boardRow.RowType switch
                {
                    RowType.Middle => RowType.Top,
                    RowType.Bottom => RowType.Middle,
                };
                moveToRowIndex = currentEmptyIndexInRow;
                break;
            }
            case MoveDirection.Down:
                moveToRowType = boardRow.RowType switch
                {
                    RowType.Middle => RowType.Bottom,
                    RowType.Top => RowType.Middle
                };
                moveToRowIndex = currentEmptyIndexInRow;
                break;
            case MoveDirection.Left:
                moveToRowIndex = currentEmptyIndexInRow - 1;
                break;
            case MoveDirection.Right:
                moveToRowIndex = currentEmptyIndexInRow + 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
        
        return new MoveToRowAndIndex(moveToRowType, moveToRowIndex);
    }

    private void MoveNumbers(BoardRow boardRow, MoveToRowAndIndex moveToRowAndIndex)
    {
        var rowToChange = _rows.First(x => x.RowType == moveToRowAndIndex.RowType);
        var originalValue = rowToChange.Numbers[moveToRowAndIndex.MoveToIndex];
        if (rowToChange.RowType == boardRow.RowType)
        {
            var indexToMoveOriginalValue =  rowToChange.Numbers.FindIndex(x => x == EmptyNumber);
            rowToChange.Numbers[indexToMoveOriginalValue] = originalValue;
            rowToChange.Numbers[moveToRowAndIndex.MoveToIndex] = -1;
        }
        else
        {
            rowToChange.Numbers[moveToRowAndIndex.MoveToIndex] = -1;
            boardRow.Numbers[moveToRowAndIndex.MoveToIndex] = originalValue;    
        }
        
    }

    private bool IsValidMove(MoveDirection direction, BoardRow boardRow, int currentEmptyIndexInRow)
    {
        var isValidMove = true;
        switch (direction)
        {
            case MoveDirection.Up:
                if (boardRow.RowType == RowType.Top)
                {
                    isValidMove = false;
                }

                break;
            case MoveDirection.Down:
                if (boardRow.RowType == RowType.Bottom)
                {
                    isValidMove = false;
                }

                break;
            case MoveDirection.Left:
                if (currentEmptyIndexInRow == 0)
                {
                    isValidMove = false;
                }

                break;
            case MoveDirection.Right:
                if (currentEmptyIndexInRow == 2)
                {
                    isValidMove = false;
                }

                break;
        }

        return isValidMove;
    }

    private List<BoardRow> CreateRows()
    {
        var rows = _numbers.Chunk(NumbersPerRow).ToList();
        var boardRows = rows.Select((x, i) => new BoardRow(x.ToList(), (RowType)i));

        return boardRows.ToList();
    }

    public void PrintBoard()
    {
        Console.WriteLine(" ----------- ");
        foreach (var boardRow in _rows)
        {
            foreach (var number in boardRow.Numbers)
            {
                Console.Write(number == EmptyNumber ? "|   " : $"| {number} ");
            }

            Console.WriteLine("|");
        }
        Console.WriteLine(" ----------- ");
    }

    private record BoardRow(List<int> Numbers, RowType RowType);

    private record MoveToRowAndIndex(RowType RowType, int MoveToIndex);
}