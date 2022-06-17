using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    //Класс модели(Чек)
    public class Check
    {
        //Id чека
        public int CheckId { get; set; }
        //Связь с покупателем
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        //Связь с продавцом
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
        //Дата и время покупки на чеке
        public DateTime Created { get; set; }
        //Связь с списком продаж
        public virtual ICollection<Sell> Sells { get; set; }
        //Определение формата чека
        public override string ToString()
        {
            return $"#{CheckId} от {Created.ToString("dd.MM.yy hh:mm:ss")}";
        }

    }
}
