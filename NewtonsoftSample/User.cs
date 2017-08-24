using Newtonsoft.Json;

namespace NewtonsoftSample
{
  class User
  {
    [JsonProperty("name2")]
    public string Name { get; set; }

    public int Age { get; set; }
  }
}
