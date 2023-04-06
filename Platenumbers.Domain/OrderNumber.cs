using Platenumbers.Domain;
using Platenumbers.Domain.Common;

public class OrderNumber : BaseEntity
{
    public DateTime ExpireDate { get; set; }
    public ICollection<PlateNumber> PlateNumbers { get; set; }
}

