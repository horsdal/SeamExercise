using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  using SeamExercise;

  [TestClass]
  public class UnitTest1
  {
    [TestMethod, ExpectedException(typeof(ArgumentException))]
    public void TestMethod1()
    {
      var s = new UrlShorteningService();
      s.ShortenUrl("foo");
    }
  }
}
