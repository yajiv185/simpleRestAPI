using SimpleRestApiEntity;

namespace SimpleRestApiInterfaces.Seller
{
    public interface ISellersCache
    {
        SellerInfo GetSellerInfo(int sellerId);
        bool UpdateSellerInfo(int sellerId, SellerInputParams sellerInputParams);
        bool DeleteSellerInfo(int sellerId);
    }
}
