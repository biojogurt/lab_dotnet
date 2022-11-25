using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class AppUser : BaseEntity
{
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
    public int AccessLevel { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    [JsonIgnore]
    public virtual JobTitle JobTitle { get; set; }
}