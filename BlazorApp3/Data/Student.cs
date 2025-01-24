using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp3.Data
{
    public class Student
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }=MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string Name { get; set; } = "";
        public byte[] Photo { get; set; }
       // public string ImageUrl { get; set; } = "";
    }
}
