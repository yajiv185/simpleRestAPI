using FluentValidation;
using System;

namespace SimpleRestApiEntity.Validators
{
    public class CarInputParamsValidator : AbstractValidator<CarInputParams>
    {
        public CarInputParamsValidator()
        {
            RuleFor(x => x.MakeId).GreaterThan(0);
            RuleFor(x => x.ModelId).GreaterThan(0);
            RuleFor(x => x.Fuel).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Price).InclusiveBetween(20000, 1000000000);
            RuleFor(x => x.Km).LessThanOrEqualTo(1000000);
            RuleFor(x => x.Year).LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(x => x.SellerId).GreaterThan(0);
        }
    }
}
