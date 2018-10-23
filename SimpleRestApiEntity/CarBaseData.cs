using System;

namespace SimpleRestApiEntity
{
    public class CarBaseData
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string Fuel { get; set; }
        public double Price { get; set; }
        public int Km { get; set; }
        public int Year { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string SellerAddress { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string MakeLogoUrl { get; set; }
        public string StateName { get; set; }
        public DateTime InsertionTime { get; set; }
        public int Pincode { get; set; }
    }
}
