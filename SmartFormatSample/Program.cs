using System;
using SmartFormat;

namespace SmartFormatSample
{
  class Program
  {
    static void Main(string[] args)
    {
      var str = Smart.Format("My name is {name}, I am {age} years old", new { name = "Moacir", age = 99 });
      Console.WriteLine(str);
    }
  }
}
