using SimpleRestApiEntity;

namespace SimpleRestApiInterfaces.Seller
{
    public interface ISellersCache
    {
        SellerInfo GetSellerInfo(int sellerId);
        bool UpdateSellerInfo(int sellerId, SellerInputParams sellerInputParams);
        void DeleteSellerInfo(int sellerId);
    }
}
