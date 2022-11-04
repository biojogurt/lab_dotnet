using System.Text.Json.Serialization;

namespace lab_dotnet.entity.Models.CreditHistory;

public class PassportIssuer : BaseEntity
{
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Borrower>? Borrowers { get; set; }
}