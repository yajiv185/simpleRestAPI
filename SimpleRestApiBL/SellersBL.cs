using SimpleRestApiCache;
using SimpleRestApiDAL;
using SimpleRestApiEntity;
using SimpleRestApiInterfaces.Seller;

namespace SimpleRestApiBL
{
    public class SellersBL : ISellersBL
    {
        private readonly ISellersRepository _sellersRepository = new SellersRepository();
        private readonly ISellersCache _sellersCache = new SellersCache();

        public SellerInfo GetSellerInfo(int sellerId)
        {
            //Currently we don't have any business logic, that's why directly calling cache layer and returning object from there
            return _sellersCache.GetSellerInfo(sellerId);
        }

        public int? InsertSellerInfo(SellerInputParams sellerInputParams)
        {
            //No need to go through cache layer as we are inserting new object(databse row) and there is nothing in cache
            //although we can go through cache layer, if we want to store object in cache as soon as we add data into database
            return _sellersRepository.InsertSellerInfo(sellerInputParams);
        }

        public bool UpdateSellerInfo(int sellerId, SellerInputParams sellerInputParams)
        {
            //Currently we don't have any business logic, that's why calling cache layer and deleteing object from there and updating
            //data into database
            return _sellersCache.UpdateSellerInfo(sellerId, sellerInputParams);
        }

        public bool DeleteSellerInfo(int sellerId)
        {
            //Calling cache, it will delete cache object from cache and also delete object(row) from database 
            return _sellersCache.DeleteSellerInfo(sellerId);
        }
    }
}
