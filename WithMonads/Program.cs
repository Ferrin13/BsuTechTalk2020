using System;
using System.Collections.Generic;
using WithMonads.Monads;

namespace WithMonads
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

    private static Maybe<string> GetInput()
    {
      Console.WriteLine("Enter string to transform:");
      var input = Console.ReadLine();
      return input == null ? Maybe<string>.Nothing : Maybe<string>.Just(input);
    }

    private static List<string> GetTransformations(Maybe<string> input)
    {
      return new List<string>
      {
        $"String reversed: {GetReversedString(input)}",
        $"String numerically doubled: {GetStringNumericallyDoubled(input)}",
        $"String stacked: {GetStringStacked(input)}",
        $"String numerically tripled and stacked: {GetTripledAndStacked(input)}",
      };
    }

    private static string GetStringIfDefined(Maybe<string> str)
    {
      return str.IsDefined ? str.Value : "Invalid";
    }

    private static string GetReversedString(Maybe<string> input)
    {
      var reversedString = input.Map(str => StringTransformers.ReverseString(str));
      return GetStringIfDefined(reversedString);
    }

    private static string GetStringNumericallyDoubled(Maybe<string> input)
    {
      var intValue = input.Bind(StringTransformers.StringToInt);
      var doubledString = intValue.Map(i => (i * 2).ToString());
      return GetStringIfDefined(doubledString);
    }

    private static string GetStringStacked(Maybe<string> input)
    {
      var stackedString = input.Bind(StringTransformers.StackString);
      return GetStringIfDefined(stackedString);
    }

    private static string GetTripledAndStacked(Maybe<string> input)
    {
      var tripledAndStacked = input
        .Bind(StringTransformers.StringToInt)
        .Map(i => (i * 3).ToString())
        .Bind(StringTransformers.StackString);

      return GetStringIfDefined(tripledAndStacked);
    }

    private static void PrintTransformations(List<string> strings)
    {
      strings.ForEach(Console.WriteLine);
      Console.WriteLine();
    }
  }
}
