using FluentValidation.Attributes;

namespace SimpleRestApiEntity
{
    [Validator(typeof())]
    public class SellerInputParams
    {
        public string SellerName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string SellerAddress { get; set; }
        public int CityId { get; set; }
    }
}
