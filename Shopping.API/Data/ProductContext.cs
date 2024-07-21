using MongoDB.Driver;
using Shopping.API.Models;

namespace Shopping.Client.Data
{
    public class ProductContext
    {
        public IMongoCollection<Product> Products { get; }
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabseSettings:CollectionName"]);
        }

        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProdcuts = productCollection.Find(p => true).Any();

            if (!existProdcuts)
            {
                productCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>
            {
                new Product()
                {
                    name = "IPhone X",
                    description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    imageFile = "product-1.png",
                    price = 950.00M,
                    category = "Smart Phone"
                },
                new Product()
                {
                    name = "Samsung 10",
                    description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    imageFile = "product-2.png",
                    price = 840.00M,
                    category = "Smart Phone"
                },
                new Product()
                {
                    name = "Huawei Plus",
                    description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    imageFile = "product-3.png",
                    price = 650.00M,
                    category = "White Appliances"
                },
                new Product()
                {
                    name = "Xiaomi Mi 9",
                    description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    imageFile = "product-4.png",
                    price = 470.00M,
                    category = "White Appliances"
                },
                new Product()
                {
                    name = "HTC U11+ Plus",
                    description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    imageFile = "product-5.png",
                    price = 380.00M,
                    category = "Smart Phone"
                },
                new Product()
                {
                    name = "LG G7 ThinQ EndofCourse",
                    description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    imageFile = "product-6.png",
                    price = 240.00M,
                    category = "Home Kitchen"
                }
            };
        }
    }
}
