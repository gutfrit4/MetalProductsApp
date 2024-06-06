using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MetalProducts.Domain.Enum;

namespace MetalProducts.Domain.Extentions;

public static class EnumExtention
{
    public static string GetDisplayName(this System.Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            ?.GetName() ?? "Невизначений";
    }
}