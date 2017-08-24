using Newtonsoft.Json;
using NewtonsoftSample.Properties;
using System;

namespace NewtonsoftSample
{
  class Program
  {
    static void Main(string[] args)
    {
      var fileContent = System.Text.Encoding.UTF8.GetString(Resources.user);
      var user = JsonConvert.DeserializeObject<User>(fileContent);
      Console.WriteLine(string.Format("User: {0}, Age: {1}", user.Name, user.Age));
    }
  }
}
