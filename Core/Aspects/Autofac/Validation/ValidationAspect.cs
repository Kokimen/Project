using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect: Metodun herhangi bir yerinde (baş,orta,son) hata veren yapı.
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //DefensiveCoding
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //Kullanıcı kafasına göre doğrulama yollamasın diye kontrol ediyor.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Çalışma anında product için validator create eder.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
