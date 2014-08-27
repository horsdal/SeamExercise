namespace SeamExercise
{
  public static class StringExtensions
  {
    public static string ShortenUrl(this string longUrl)
    {
      var datastore = new UrlStore();
      var shortUrlPath = longUrl.GetHashCode().ToString();
      datastore.SaveUrl(longUrl, shortUrlPath);
      return shortUrlPath;
    }
  }
}
