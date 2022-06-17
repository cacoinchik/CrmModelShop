using System.Collections;
using System.Collections.Generic;

namespace CrmBl.Model
{
    //Класс модели(Корзина)
    public class Cart : IEnumerable
    {
        public Customer Customer { get; set; }
        //Словарь для записи товаров в корзине
        public Dictionary <Product,int> Products { get; set; }
        public Cart(Customer customer)
        {
            //Инициализация объектов
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }
        //Метод для добавления продуктов в корзину
        public void Add (Product product)
        {
            //если товар такого типа уже добавлен, то увеличиваем его количество
            if(Products.TryGetValue(product,out int count))
            {
                Products[product] = ++count;
            }
            //если товара нет, добавляем его
            else
            {
                Products.Add(product, 1);
            }
        }
        //Итоговый список продуктов в корзине
        public IEnumerator GetEnumerator()
        {
           foreach(var product in Products.Keys)
           {
                for( int i = 0; i < Products[product]; i++)
                {
                    yield return product;
                }
           }
        }
        //Добавление продуктов
        public List<Product> GetAll()
        {
            var result = new List<Product>();
            foreach(Product i in this)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
