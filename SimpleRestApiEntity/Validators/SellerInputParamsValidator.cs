using FluentValidation;

namespace SimpleRestApiEntity.Validators
{
    public class SellerInputParamsValidator : AbstractValidator<SellerInputParams>
    {
        public SellerInputParamsValidator()
        {
            RuleFor(x => x.CityId).GreaterThan(0);
            RuleFor(x => x.SellerAddress).NotEmpty();
            RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Must(x=>true);
            RuleFor(x => x.ContactNumber).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Must(x=>true);
            RuleFor(x => x.SellerName).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Must(x=>true);
        }
    }
}
