using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace lab_dotnet.Entities.Models.CreditHistory;

public class Credit : BaseEntity
{
    public Guid CreditApplicationId { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Range(0, 101)]
    public int InterestRate { get; set; }

    [JsonIgnore]
    public virtual CreditApplication? CreditApplication { get; set; }
    [JsonIgnore]
    public virtual ICollection<Payment>? Payments { get; set; }
}