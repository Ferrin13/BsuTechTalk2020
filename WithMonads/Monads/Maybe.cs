using System;
using System.Collections.Generic;
using System.Text;

namespace WithMonads.Monads
{
  public class Maybe<T>
  {
    private Maybe(T value, bool isDefined)
    {
      Value = value;
      IsDefined = isDefined;
    }

    public static Maybe<T> Nothing = new Maybe<T>(default, false);
    public static Maybe<T> Just(T value) => new Maybe<T>(value, true);

    public T Value { get; }
    public bool IsDefined { get; }

    public Maybe<R> Map<R>(Func<T, R> func) =>
      Bind(t => Maybe<R>.Just(func(t)));

    public Maybe<R> Bind<R>(Func<T, Maybe<R>> func) =>
      IsDefined ? func(Value) : Maybe<R>.Nothing;
  }
}
