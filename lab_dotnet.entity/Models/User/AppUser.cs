namespace lab_dotnet.entity.Models.User;

public class AppUser : BaseEntity
{
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
    public int AccessLevel { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public virtual JobTitle JobTitle { get; set; }
}