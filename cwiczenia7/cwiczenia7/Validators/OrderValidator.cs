using cwiczenia7.DTO;
using FluentValidation;

namespace cwiczenia7.Validators;

public class OrderValidator : AbstractValidator<GetOrder>
{
    public OrderValidator()
    {
        RuleFor(e => e.ProductId).GreaterThan(0).NotEmpty().NotNull();
        RuleFor(e => e.WareHouseId).GreaterThan(0).NotEmpty().NotNull();
        RuleFor(e => e.Amount).GreaterThan(0).NotEmpty().NotNull();
        RuleFor(e => e.CreatedAt).NotEmpty().NotNull().GreaterThanOrEqualTo(DateTime.Now);
    }
}