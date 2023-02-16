using ESourcing.Products.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ESourcing.Products.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name="Xiaomi Redmi Note 8",
                    Summary="Phone",
                    Description="Phone",
                    ImageFile="product-4.png",
                    Price=3700,
                    Category="Android Phones"
                }
            };
        }
    }
}
