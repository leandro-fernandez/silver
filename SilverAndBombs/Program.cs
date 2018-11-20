using System;

namespace SilverAndBombs
{
  class Program
  {
    static void Main(string[] args)
    {
      Tile[,] board = new Tile[,]
      {
        { Tile._, Tile._, Tile._, Tile._, Tile._, Tile._, Tile._, Tile._ },
        { Tile._, Tile._, Tile._, Tile._, Tile.Silver, Tile._, Tile._, Tile._ },
        { Tile._, Tile._, Tile._, Tile.Bomb, Tile._, Tile.Silver, Tile._, Tile._ },
        { Tile._, Tile._, Tile._, Tile._, Tile._, Tile.Bomb, Tile.Silver, Tile._ },
        { Tile._, Tile.Silver, Tile._, Tile._, Tile.Silver, Tile._, Tile._, Tile.Silver},
        { Tile.Silver, Tile._, Tile.Silver, Tile.Bomb, Tile._, Tile.Bomb, Tile.Silver, Tile._ },
        { Tile._, Tile._, Tile._, Tile._, Tile._, Tile._, Tile._, Tile._ },
        { Tile._, Tile._, Tile._, Tile._, Tile.Silver, Tile._, Tile._, Tile._ },
      };

      int maxSilvers = GetMaxSilver(board);

      Console.WriteLine($"Max Silvers: {maxSilvers}");
      Console.WriteLine("Press any key to finish...");
      Console.Read();
    }

    public static int GetMaxSilver(Tile[,] board)
    {
      int maxSilver = -1;

      for (int i = 0; i < board.GetLength(0); i++)
      {
        for (int j = 0; j < board.GetLength(1); j++)
        {
          int silverNum = GetNumberOfSilver(i, j, board);

          if (silverNum > maxSilver)
          {
            maxSilver = silverNum;
            Console.WriteLine($"New max {maxSilver} found at {i}, {j}");
          }
        }
      }

      return maxSilver;
    }

    private static int GetNumberOfSilver(int line, int column, Tile[,] board)
    {
      int numberOfSilvers = 0;

      for (int i = line + 1; i < board.GetLength(0); i++)
      {
        if (board[i, column] == Tile.Bomb)
          break;
        else if (board[i, column] == Tile.Silver)
          numberOfSilvers++;
      }

      for (int i = line - 1; i > 0; i--)
      {
        if (board[i, column] == Tile.Bomb)
          break;
        else if (board[i, column] == Tile.Silver)
          numberOfSilvers++;
      }

      for (int j = column + 1; j < board.GetLength(1); j++)
      {
        if (board[line, j] == Tile.Bomb)
          break;
        else if (board[line, j] == Tile.Silver)
          numberOfSilvers++;
      }

      for (int j = column - 1; j > 0; j--)
      {
        if (board[line, j] == Tile.Bomb)
          break;
        else if (board[line, j] == Tile.Silver)
          numberOfSilvers++;
      }

      return numberOfSilvers;
    }
  }

  public enum Tile
  {
    _, Bomb, Silver
  }
}