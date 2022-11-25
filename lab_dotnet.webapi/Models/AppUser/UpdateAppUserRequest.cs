using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateAppUserRequest
{
    #region Model

    public string? FullName { get; set; }
    public Guid? JobTitleId { get; set; }
    public int? AccessLevel { get; set; }
    public string? Email { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateAppUserRequest>
    {
        public Validator()
        {
            RuleFor(x => x.AccessLevel)
                    .InclusiveBetween(1, 3)
                    .WithMessage("Must be between 1 and 3 inclusively");
            RuleFor(x => x.Email)
                    .EmailAddress()
                    .WithMessage("Must be email");
        }
    }

    #endregion Validator
}

public static class UpdateAppUserRequestExtension
{
    public static ValidationResult Validate(this UpdateAppUserRequest model)
    {
        return new UpdateAppUserRequest.Validator().Validate(model);
    }
}