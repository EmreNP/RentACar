using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {

            RuleFor(c => c.CarName).MinimumLength(2).NotEmpty();
            RuleFor(c=>c.DailyPrice).NotEmpty().GreaterThan(50);
            RuleFor(c => c.DailyPrice).NotEmpty().GreaterThan(75).When(c => c.BrandId == 4);
            RuleFor(c => c.CarName).Must(StartsNotWithZ);

        }

        private bool StartsNotWithZ(string arg)
        {
            if (arg.StartsWith('Z') || arg.StartsWith('z'))
            {
                return false;
            }
            return true;
        }
    }
}
