using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ScnContactApiV2.Models
{
    public class Contact
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Opinion { get; set; }
        public DateTime DateCreated { get; set; }

    }
}