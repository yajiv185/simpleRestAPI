using FluentValidation;
using SimpleRestApiUtility;

namespace SimpleRestApiEntity.Validators
{
    public class SellerInputParamsValidator : AbstractValidator<SellerInputParams>
    {
        public SellerInputParamsValidator()
        {
            RuleFor(x => x.CityId).GreaterThan(0);
            RuleFor(x => x.SellerAddress).NotEmpty();
            RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Must(y => RegExValidation.IsValidEmail(y)).WithMessage("Either email valid.");
            RuleFor(x => x.ContactNumber).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Must(y => RegExValidation.IsValidMobile(y)).WithMessage("Mobile is not valid. It should contain 10 digit and start with 6 or 7 or 8 or 9.");
            RuleFor(x => x.SellerName).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Must(y => RegExValidation.IsValidName(y)).WithMessage("Name is not valid. It should be atleast 3 character and start it should only contain ('`','.','-',' ','_', a-z, A-Z) characters.");
        }
    }
}
