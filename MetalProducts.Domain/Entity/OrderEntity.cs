using MetalProducts.Domain.Enum;


namespace MetalProducts.Domain.Entity
{
    public class OrderEntity
    {
        public long Id { get; set; }
        public string orderName { get; set; }
        public string companyName { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public Priority Priority { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public bool isDone { get; set; }
        
    }
}
