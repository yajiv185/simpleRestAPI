using FluentValidation.Attributes;

namespace SimpleRestApiEntity
{
    [Validator(typeof())]
    public class CarInputParams
    {
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public string Fuel { get; set; }
        public double Price { get; set; }
        public int Km { get; set; }
        public int Year { get; set; }
        public int SellerId { get; set; }
    }
}
