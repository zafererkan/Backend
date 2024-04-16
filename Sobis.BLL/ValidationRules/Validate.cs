using FluentValidation;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using System;

namespace Sobis.BLL.ValidationRules
{
    public class Validate
    {
        public static IResult ValidateEntity(Type _validatorType, object entities)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var context = new ValidationContext<object>(entities);
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                string message = null;
                foreach (var item in result.Errors)
                {
                    message += $"{item} {Environment.NewLine}";
                }
                return new ErrorResult(message);
            }
            return new SuccessResult();
        }
    }
}
