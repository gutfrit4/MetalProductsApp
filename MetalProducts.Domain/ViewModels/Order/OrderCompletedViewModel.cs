using MetalProducts.Domain.Enum;

namespace MetalProducts.Domain.ViewModels.Order;

public class OrderCompletedViewModel
{
    public long Id { get; set; }
    
    public string orderName { get; set; }
  
    public string Description { get; set; }
    
}