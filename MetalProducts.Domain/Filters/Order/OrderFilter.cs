using MetalProducts.Domain.Enum;

namespace MetalProducts.Domain.Filters.Order;

public class OrderFilter
{
    public string companyName { get; set; }
    public Priority? Priority { get; set; }
}