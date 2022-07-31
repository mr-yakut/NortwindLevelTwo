using FluentValidation;
using MvcWebUI.Models;

namespace MvcWebUI.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator:AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
        }
    }
}
