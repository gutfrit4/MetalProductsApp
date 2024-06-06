using System.ComponentModel.DataAnnotations;
using MetalProducts.Domain.Enum;

namespace MetalProducts.Domain.ViewModels.Order;

public class OrderViewModel
{
    
    public long Id { get; set; }
    
    [Display(Name = "Назва замовлення")]
    public string orderName { get; set; }
    
    [Display(Name = "Ім'я замовника/Компанії")]
    public string companyName { get; set; }
    
    [Display(Name = "Електрона пошта")]
    public string Email { get; set; }
    
    [Display(Name = "Номер телефону")]
    public string phoneNumber { get; set; }
    
    [Display(Name = "Пріоритет")]
    public string Priority { get; set; }
    
    [Display(Name = "Вартість")]
    public int Price { get; set; }
    
    [Display(Name = "Опис замовлення")]
    public string Description { get; set; }
    
    [Display(Name = "Дата створення")]
    public string Created { get; set; }
    
    [Display(Name = "Готовність")]
    public string isDone { get; set; }
}