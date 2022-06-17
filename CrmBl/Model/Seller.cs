using System.Collections.Generic;

namespace CrmBl.Model
{
    //Класс модели(Продавец)
    public class Seller
    {
        //Id продавца
        public int SellerId { get; set; }
        //Имя продавца
        public string Name { get; set; }
        //Связь с чеком
        public virtual ICollection<Check> Checks { get; set; }
        //Установка имени
        public override string ToString()
        {
            return Name;
        }

    }
}
