﻿using Castle.DynamicProxy;
using FluentValidation;
using Sobis.Core.CrossCunttingConcerns.Validation.FluentValidation;
using Sobis.Core.Utilities.Interceptors;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception($"Gerçersiz Doğrulama Kodu Sınıfı. ({validatorType} Gerçeli bir validator değil)");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidatorTool.Validate(validator, entity);
            }
        }
    }
}