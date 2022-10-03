namespace KPT_back.Models;

  public class MongoDBSettings : IMongoDBSettings
  {
      public string ConnectionURI { get; set; } = null!;
      public string DatabaseName { get; set; } = null!;
      public string CollectionName { get; set; } = null!;
  }

  public interface IMongoDBSettings
  {
      string ConnectionURI { get; set; }
      string DatabaseName { get; set; }
      string CollectionName { get; set; }
  }