using System.Linq;

namespace StringFormatter
{
  public static class StringTransformers
  {
    public static string ReverseString(string input)
    {
      if (input == null)
      {
        //throw new ArgumentNullException(nameof(s));
        return null;
      }

      return string.Join("", input.Reverse());
    }

    public static int? StringToInt(string input)
    {
      if (input == null)
      {
        //throw new ArgumentNullException(nameof(s));
        //return 0;
        return null;
      }

      var successfulParse = int.TryParse(input, out var result);

      return successfulParse ? (int?)result : null; // Same questions here, exception? 0? 
    }

    public static string StackString(string input)
    {
      if (input == null || input.Length % 2 != 0)
      {
        //throw new ArgumentNullException(nameof(s));
        return null;
      }
      
      var top = input.Substring(0, input.Length / 2);
      var bottom = input.Substring(input.Length / 2, input.Length / 2);

      return $"\n{top}\n{bottom}";
    }
  }
}
