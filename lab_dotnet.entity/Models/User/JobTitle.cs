namespace lab_dotnet.entity.Models.User;

public class JobTitle : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<AppUser> AppUsers { get; set; }
}