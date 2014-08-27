namespace ShortenerApplication
{
  using System;
  using SeamExercise;

  public class Program
  {
    static void Main(string[] args)
    {
      string input = string.Empty;
      var shorteningService = new UrlShorteningService();
      var dataStore = new UrlStore();
      while (input != "exit")
      {
        Console.WriteLine("type url to shorten (or 'exit' to exit):");
        input = Console.ReadLine();
        try
        {
          shorteningService.ShortenUrl(input);
          var result = dataStore.GetShortUrlFor(input);
          Console.WriteLine("The shortened url is {0}", shorteningService.BuildUrlFromPath(result, input.StartsWith("https")));
        }
        catch (Exception e)
        {
          Console.WriteLine("Oh noooeessss. Something went wrong! \\O/");
          Console.WriteLine("Error {0}", e.Message);
        }
      }
      Console.WriteLine("");
    }
  }
}
