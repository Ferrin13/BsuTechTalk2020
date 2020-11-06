using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WithMonads.Monads;

namespace WithMonads
{
  public static class StringTransformers
  {
    public static string ReverseString(string input)
    {
      return string.Join("", input.Reverse());
    }

    public static Maybe<int> StringToInt(string input)
    {
      var successfulParse = int.TryParse(input, out var result);

      return successfulParse ? Maybe<int>.Just(result) : Maybe<int>.Nothing;
    }

    public static Maybe<string> StackString(string input)
    {
      if (input.Length % 2 != 0)
      {
        return Maybe<string>.Nothing;
      }

      var top = input.Substring(0, input.Length / 2);
      var bottom = input.Substring(input.Length / 2, input.Length / 2);
      return Maybe<string>.Just($"\n{top}\n{bottom}");
    }
  }
}
