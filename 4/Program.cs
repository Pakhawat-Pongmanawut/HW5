using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int row = 1;
        int column = 1;
        Stack<Tuple<int, int>> undoStack = new Stack<Tuple<int, int>>();
        Stack<Tuple<int, int>> redoStack = new Stack<Tuple<int, int>>();

        while (true)
        {
            int move = int.Parse(Console.ReadLine());
            
            if (move == 11)
            {
                break;
            }
            else if (move == 9 && undoStack.Count > 0)
            {
                Tuple<int, int> previousPosition = undoStack.Pop();
                redoStack.Push(new Tuple<int, int>(row, column));
                row = previousPosition.Item1;
                column = previousPosition.Item2;
            }
            else if (move == 10 && redoStack.Count > 0)
            {
                Tuple<int, int> nextPosition = redoStack.Pop();
                undoStack.Push(new Tuple<int, int>(row, column));
                row = nextPosition.Item1;
                column = nextPosition.Item2;
            }
            else if (move >= 1 && move <= 8)
            {
                int steps = int.Parse(Console.ReadLine());
                if (CanMove(move, row, column, steps))
                {
                    Tuple<int, int> previousPosition = new Tuple<int, int>(row, column);
                    Move(move, ref row, ref column, steps);
                    undoStack.Push(previousPosition);
                    redoStack.Clear();
                }
            }
        }

        Console.WriteLine(Convert.ToChar(column - 1 + 'A') + " " + row);
    }

    static bool CanMove(int move, int row, int column, int steps)
    {
        switch (move)
        {
            case 1:
                return row + steps <= 8;
            case 2:
                return row + steps <= 8 && column - steps >= 1;
            case 3:
                return column - steps >= 1;
            case 4:
                return row - steps >= 1 && column - steps >= 1;
            case 5:
                return row - steps >= 1;
            case 6:
                return row - steps >= 1 && column + steps <= 8;
            case 7:
                return column + steps <= 8;
            case 8:
                return row + steps <= 8 && column + steps <= 8;
            default:
                return false;
        }
    }

    static void Move(int move, ref int row, ref int column, int steps)
    {
        switch (move)
        {
            case 1:
                row += steps;
                break;
            case 2:
                row += steps;
                column -= steps;
                break;
            case 3:
                column -= steps;
                break;
            case 4:
                row -= steps;
                column -= steps;
                break;
            case 5:
                row -= steps;
                break;
            case 6:
                row -= steps;
                column += steps;
                break;
            case 7:
                column += steps;
                break;
            case 8:
                row += steps;
                column += steps;
                break;
        }
    }
}
