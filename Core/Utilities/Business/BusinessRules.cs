using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //Params verildiğinde run içerisinde virgül ile sınırsız IResult verebilirsin ve array içerisine atılırlar.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success) //Ünlem negatifi tersi anlamına gelir, yani burada başarılı değilse demek.
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
