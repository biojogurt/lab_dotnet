using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateAppUserRequest
{
    #region Model

    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateAppUserRequest>
    {
        public Validator()
        {
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