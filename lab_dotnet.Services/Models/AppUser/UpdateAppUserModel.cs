namespace lab_dotnet.Services.Models;

public class UpdateAppUserModel
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
}