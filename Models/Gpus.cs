using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace KPT_back.Models;

public class Gpu {

  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  [BsonElement("name")]
  public string name { get; set;} = null!;

  [BsonElement("price")]
  public string price { get; set;} = null!;

  [BsonElement("priceInt")]
  public int priceInt { get; set;}

  [BsonElement("model")]
  public string model { get; set;} = null!;

  [BsonElement("serie")]
  public string serie { get; set;} = null!;

  [BsonElement("manufactor")]
  public string manufactor { get; set;} = null!;

  [BsonElement("brand")]
  public string brand { get; set;} = null!;

  [BsonElement("store")]
  public string store { get; set;} = null!;

  [BsonElement("link")]
  public string link { get; set;} = null!;
}