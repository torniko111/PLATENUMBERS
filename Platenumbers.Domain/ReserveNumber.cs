using Platenumbers.Domain;
using Platenumbers.Domain.Common;

public class ReserveNumber: BaseEntity
{
    public string Number { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public DateTime DateEnd { get; set; }
    public ICollection<PlateNumber>? PlateNumbers { get; set; }
}
