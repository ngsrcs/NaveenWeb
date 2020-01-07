﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DSAL.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
        public string DbType { get; set; }
    }
}