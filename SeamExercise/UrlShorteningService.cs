namespace SeamExercise 
{
  using System;
  using System.Configuration;
  using System.IO;

  public class UrlShorteningService
  {
    public void ShortenUrl(string url)
    {
      if (url == null)
        throw new ArgumentException("url cannot be null");
      if (url == string.Empty)
        throw new ArgumentException("url cannot be an empty string");
      if (string.IsNullOrWhiteSpace(url))
        throw new ArgumentException("url cannot be whitespace");
      try
      {
        var parsedUrl = new Uri(url, UriKind.Absolute);
        if (!parsedUrl.Scheme.EndsWith("s"))
        {
          var shortened =
            ConfigurationManager.AppSettings["scheme"] + "://" + ConfigurationManager.AppSettings["host"] + "/" + parsedUrl.ToString().ShortenUrl();
          var parsedShortUrl = new Uri(shortened, UriKind.Absolute);
        }
        else // https
        {
          try
          {
            var shortened =
              ConfigurationManager.AppSettings["secure-scheme"] + "://" + ConfigurationManager.AppSettings["host"] + "/" + parsedUrl.ToString().ShortenUrl();
            var parsedShortUrl = new Uri(shortened, UriKind.Absolute);
          }
          catch (UriFormatException)
          {
            // just retry, shortening algo is flaky. WTH it's friday I'm off in bit. Really should fix at some point.
            var shortened =
              ConfigurationManager.AppSettings["secure-scheme"] + "://" + ConfigurationManager.AppSettings["host"] + "/" + parsedUrl.ToString().ShortenUrl();
          }
        }
      }
      catch (UriFormatException e)
      {
        throw new ArgumentException("url must be absolute", e); 
      }
    }

    public string BuildUrlFromPath(string path, bool secure = false)
    {
      if (secure)
        return ConfigurationManager.AppSettings["secure-scheme"] + "://" + ConfigurationManager.AppSettings["host"] + "/" + path;
      return ConfigurationManager.AppSettings["scheme"] + "://" + ConfigurationManager.AppSettings["host"] + "/" + path;
    }
  }
}
