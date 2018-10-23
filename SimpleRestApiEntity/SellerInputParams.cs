using FluentValidation.Attributes;
using SimpleRestApiEntity.Validators;

namespace SimpleRestApiEntity
{
    [Validator(typeof(SellerInputParamsValidator))]
    public class SellerInputParams
    {
        public string SellerName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string SellerAddress { get; set; }
        public int CityId { get; set; }
    }
}
