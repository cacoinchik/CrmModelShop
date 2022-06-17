using System.Collections.Generic;

namespace CrmBl.Model
{
    //Класс модели(Продукт/Товар)
    public class Product
    {
        //Id товара
        public int ProductId { get; set; }
        //Имя
        public string Name { get; set; }
        //Цена
        public decimal Price { get; set; }
        //Количество на складе
        public int Count { get; set; }
        //Связь с продажами
        public virtual ICollection<Sell> Sells { get; set; }
        //Установка имени
        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return ProductId;
        }
        public override bool Equals(object obj)
        {
            if(obj is Product product)
            {
                return ProductId.Equals(product.ProductId);
            }
            return false;
            
        }



    }
}
