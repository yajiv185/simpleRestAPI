using SimpleRestApiDAL;
using SimpleRestApiEntity;
using SimpleRestApiInterfaces.Seller;

namespace SimpleRestApiCache
{
    public class SellersCache : ISellersCache
    {
        private readonly ISellersRepository _sellersRepository = new SellersRepository();

        public SellerInfo GetSellerInfo(int sellerId)
        {
            //Here currently I don't have cache so I am just returning object by calling database, in case of cache
            //first look into cache if you don't find it in cache then pass database method as callback which will fetch 
            //info from database and store into cache and return that object
            return _sellersRepository.GetSellerInfo(sellerId);
        }

        public bool UpdateSellerInfo(int sellerId, SellerInputParams sellerInputParams)
        {
            //In case of cache server, after updating info to the database, just delete cache key from cache,
            //So next time it will try to fetch info it will not get from cache and database will be called and 
            //it will store the object return by database into cache(so that way cache has updated data)
            return _sellersRepository.UpdateSellerInfo(sellerId, sellerInputParams);
        }

        public bool DeleteSellerInfo(int sellerId)
        {
            //In case of cache server, after updating info to the database, just delete cache key from cache.
            return _sellersRepository.DeleteSellerInfo(sellerId);
        }
    }
}
