using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidatinRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.DailyPrice).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(2);
            RuleFor(x => x.DailyPrice).GreaterThan(0);
            //RuleFor(x => x.CarName).Must(StartWithA).WithMessage("Masinlar  A herfi ile baslamalidir");
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
