using Markdig;
using MarkdigSample.Properties;
using System;

namespace MarkdigSample
{
  class Program
  {
    static void Main(string[] args)
    {
      var resource = System.Text.Encoding.Default.GetString(Resources.readme);
      var pipeline = new MarkdownPipelineBuilder().UseGridTables().UseEmphasisExtras().UseFootnotes().UseMediaLinks().Build();
      var result = Markdown.ToHtml(resource, pipeline);
      Console.WriteLine(result);
    }
  }
}
