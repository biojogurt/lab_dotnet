using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace lab_dotnet.entity.Models.User;

public class AppUser : BaseEntity
{
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
    [Range(1, 4)]
    public int AccessLevel { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    [JsonIgnore]
    public virtual JobTitle JobTitle { get; set; }
}