using System.Linq;
using WithMonads2.Monads;

namespace WithMonads2
{
  public static class StringTransformers
  {
    public static string ReverseString(string input) =>
      string.Join("", input.Reverse());

    public static Maybe<int> StringToInt(string input) =>
      int.TryParse(input, out var result)
        ? Maybe<int>.Just(result)
        : Maybe<int>.Nothing;

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
