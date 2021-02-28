using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() //hangi nesne için ne kuralı yazılacaksa buraya yazılır.
        {
            RuleFor(p => p.ProductName).NotEmpty(); //productname boş olamaz.
            RuleFor(p => p.ProductName).MinimumLength(2); //productname minumum iki karakter olmalıdır. p => product temsil eder.
            RuleFor(p => p.UnitPrice).NotEmpty(); //product fiyatı boş olamaz.
            RuleFor(p => p.UnitPrice).GreaterThan(0); //product fiyatı 0'dna büyük olmalıdır.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A Harfi ile Başlamalıdır"); //kendi kuralımızı yazdık.
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //when burada where gibi bir anlam taşıyor.
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
