using ESourcing.Sourcing.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System;
namespace ESourcing.Sourcing.Data
{
    public class SourcingContextSeed
    {
        public static void SeedData(IMongoCollection<Auction> auctionCollection)
        {
            bool existAuct = auctionCollection.Find(p => true).Any();
            if (!existAuct)
            {
                auctionCollection.InsertManyAsync(GetConfiguredAuctions());
            }
        }

        private static IEnumerable<Auction> GetConfiguredAuctions()
        {
            return new List<Auction>()
            {
                new Auction()
                {
                    Name="Auction 1",
                    Description="A",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(10),
                    ProductId="38475937539",
                    IncludedSellers=new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    },
                    Quantity=5,
                    Status=(int)Status.Active
                },
                new Auction()
                {
                    Name="Auction 2",
                    Description="B",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(10),
                    ProductId="38475937539",
                    IncludedSellers=new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    },
                    Quantity=5,
                    Status=(int)Status.Active
                }
            };
        }
    }
}
