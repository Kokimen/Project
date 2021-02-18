
using Core.Entities;

namespace Entities.Concrete
{
    //Çıplak Class Kalmasın, ileride büyük ihtimal sorun çıkaracaktır
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        
    }
}
