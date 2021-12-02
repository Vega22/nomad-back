using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nomad.Models
{
    public class cityModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string city { get; set; }
    }
}
