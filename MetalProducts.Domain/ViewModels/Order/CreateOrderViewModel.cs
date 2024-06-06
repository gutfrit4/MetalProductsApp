using MetalProducts.Domain.Enum;

namespace MetalProducts.Domain.ViewModels.Order;

public class CreateOrderViewModel
{
    public long Id { get; set; }
    public string orderName { get; set; }
    public string companyName { get; set; }
    public string Email { get; set; }
    public string phoneNumber { get; set; }
    public Priority Priority { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }

    public void Validate()
    {
        
        if (string.IsNullOrWhiteSpace(orderName))
        {
            throw new ArgumentNullException(orderName, "Заповніть 'Назва замовлення'");
        }
        if (string.IsNullOrWhiteSpace(companyName))
        {
            throw new ArgumentNullException(companyName, "Заповніть 'Ім'я замовника/Компанії'");
        }
        if (string.IsNullOrWhiteSpace(Email))
        {
            throw new ArgumentNullException(Email, "Заповніть 'Електрона пошта'");
        }
        
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentNullException(phoneNumber, "Заповніть 'Номер телефону'");
        }
        if (string.IsNullOrWhiteSpace(Price.ToString()))
        {
            throw new ArgumentNullException(Price.ToString(), "Заповніть 'Вартість'");
        }
      
    }
}