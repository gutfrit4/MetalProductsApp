

using System.ComponentModel.DataAnnotations;

namespace MetalProducts.Domain.Enum
{
    public enum Priority
    {
        [Display(Name = "Легка")]
        Easy = 1,
        [Display(Name = "Важлива")]
        Madium = 2,
        [Display(Name = "Термінова")]
        Hard = 3
    }
}
