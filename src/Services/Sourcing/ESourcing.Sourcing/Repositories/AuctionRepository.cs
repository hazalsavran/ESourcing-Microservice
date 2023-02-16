using ESourcing.Sourcing.Data.Interfaces;
using ESourcing.Sourcing.Entities;
using ESourcing.Sourcing.Repositories.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ESourcing.Sourcing.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ISourcingContext _sourcingContext;

        public AuctionRepository(ISourcingContext sourcingContext)
        {
            _sourcingContext = sourcingContext;
        }

        public async Task Create(Auction auction)
        {
            await _sourcingContext.Auctions.InsertOneAsync(auction);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(x => x.Id, id);
            DeleteResult deleteResult = await _sourcingContext.Auctions.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Auction> GetAuction(string id)
        {
            return await _sourcingContext.Auctions.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Auction> GetAuctionByName(string name)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(x => x.Name, name);
            return await _sourcingContext.Auctions.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Auction>> GetAuctions()
        {
            return await _sourcingContext.Auctions.Find(x => true).ToListAsync();
        }

        public async Task<bool> Update(Auction auction)
        {
            var updatedResult = await _sourcingContext.Auctions.ReplaceOneAsync(a => a.Id.Equals(auction.Id), auction);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }
    }
}
