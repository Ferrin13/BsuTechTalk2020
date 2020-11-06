using System;
using System.Collections.Generic;
using BsuTechTalk2020;

namespace NoMonads
{
  public class Program
  {
    public static void Main(string[] args)
    {
      while (true)
      {
        var input = GetInput();
        var transformations = GetTransformations(input);
        PrintTransformations(transformations);
      }
    }

    private static string GetInput()
    {
      Console.WriteLine("Enter string to transform:");
      return Console.ReadLine();
    }

    private static List<string> GetTransformations(string input)
    {
      return new List<string>
      {
        $"String reversed: {GetReversedString(input)}",
        $"String numerically doubled: {GetStringNumericallyDoubled(input)}",
        $"String stacked: {GetStringStacked(input)}",
        $"String numerically tripled and stacked: {GetTripledAndStacked(input)}",
      };
    }

    private static string GetReversedString(string input)
    {
      if (input == null)
      {
        return "Invalid";
      }

      return StringTransformers.ReverseString(input);
    }

    private static string GetStringNumericallyDoubled(string input)
    {
      var intValue = StringTransformers.StringToInt(input);
      if (intValue == null)
      {
        return "Invalid";
      }

      return (intValue.Value * 2).ToString();
    }

    private static string GetStringStacked(string input)
    {
      var stackedString = StringTransformers.StackString(input);
      if (stackedString == null)
      {
        return "Invalid";
      }

      return stackedString;
    }

    private static string GetTripledAndStacked(string input)
    {
      if (input == null)
      {
        return "Invalid";
      }

      var intValue = StringTransformers.StringToInt(input);
      if (intValue == null)
      {
        return "Invalid";
      }

      var tripledAndStackedString = GetStringStacked((intValue * 3).ToString());
      if (tripledAndStackedString == null)
      {
        return "Invalid";
      }

      return tripledAndStackedString;
    }

    private static void PrintTransformations(List<string> transformations)
    {
      transformations.ForEach(Console.WriteLine);
      Console.WriteLine();
    }
  }
}
