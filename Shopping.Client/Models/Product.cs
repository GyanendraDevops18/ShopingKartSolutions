﻿using System.Text.Json.Serialization;

namespace Shopping.Client.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("category")]
        public string category { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("imageFile")]
        public string imageFile { get; set; }

        [JsonPropertyName("price")]
        public decimal price { get; set; }
    }
}
