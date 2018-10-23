﻿using SimpleRestApiEntity;

namespace SimpleRestApiInterfaces.Seller
{
    public interface ISellersRepository
    {
        SellerInfo GetSellerInfo(int sellerId);
        int? InsertSellerInfo(SellerInputParams sellerInputParams);
        bool UpdateSellerInfo(int sellerId, SellerInputParams sellerInputParams);
        bool DeleteSellerInfo(int sellerId);
    }
}