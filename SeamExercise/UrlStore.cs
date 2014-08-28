namespace SeamExercise
{
  using System.Linq;
  using MongoDB.Bson;
  using MongoDB.Driver;
  using MongoDB.Driver.Builders;
   
  public class UrlStore 
  {
    private MongoCollection<BsonDocument> urls;

    public UrlStore()
    {
      var database = new MongoClient("mongodb://nnit:123456789@kahana.mongohq.com:10070/shortUrl").GetServer().GetDatabase("shortUrl");
      this.urls = database.GetCollection("urls");
    }

    public virtual void SaveUrl(string url, string shortenedUrl)
    {
      this.urls.Save(new { Id = url, url, shortenedUrl });
    }

    public string GetUrlFor(string shortenedUrl)
    {
      var urlDocument =
          this.urls
          .Find(Query.EQ("shortenedUrl", shortenedUrl))
          .FirstOrDefault();

      return
          urlDocument == null ?
          null : urlDocument["url"].AsString;
    }

    public string GetShortUrlFor(string longUrl)
    {
      var urlDocument =
          this.urls
          .Find(Query.EQ("url", longUrl))
          .FirstOrDefault();

      return
          urlDocument == null ?
          null : urlDocument["shortenedUrl"].AsString;
    }
  }
}