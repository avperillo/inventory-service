using FluentValidation;
using Inventory.API.Controllers.Item.Dtos;
using System;

namespace Inventory.API.Controllers.Item.Validators
{
    public class AddItemValidator : AbstractValidator<AddItemDto>
    {
        public AddItemValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("{PropertyName} should be not empty or null");
            RuleFor(p => p.ExpirationDate).GreaterThan(DateTime.Today).WithMessage("{PropertyName} sholud be greater than today");
        }
    }

}
