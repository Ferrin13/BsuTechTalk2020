using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using WithMonads2.Monads;

namespace WithMonads2
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

    private static List<string> GetTransformations(Maybe<string> input) =>
     new List<(string name, Func<Maybe<string>, Maybe<string>> transformer)>
        {
          ("String reversed", GetReversedString),
          ("String numerically doubled", GetStringNumericallyDoubled),
          ("String stacked", GetStringStacked),
          ("String numerically tripled and stacked", GetTripledAndStacked)
        }
        .Select(t => $"{t.name}: {GetStringIfDefined(t.transformer(input))}").ToList();

    private static string GetStringIfDefined(Maybe<string> str) =>
      str.IsDefined ? str.Value : "Invalid";

    private static Maybe<string> GetReversedString(Maybe<string> input) =>
      input.Map(StringTransformers.ReverseString);

    private static Maybe<string> GetStringNumericallyDoubled(Maybe<string> input) =>
      input
        .Bind(StringTransformers.StringToInt)
        .Map(i => (i * 2).ToString());

    private static Maybe<string> GetStringStacked(Maybe<string> input) =>
      input.Bind(StringTransformers.StackString);

    private static Maybe<string> GetTripledAndStacked(Maybe<string> input) =>
     input
        .Bind(StringTransformers.StringToInt)
        .Map(i => (i * 3).ToString())
        .Bind(StringTransformers.StackString);

    private static void PrintTransformations(List<string> strings)
    {
      strings.ForEach(Console.WriteLine);
      Console.WriteLine();
    }
  }
}
