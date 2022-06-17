using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    //Класс модели (Касса)
    public class CashDesk
    {
        //класс для доступа к Бд
        CrmContext db = new CrmContext();
        //номер кассы
        public int Number { get; set; }
        //продавец на кассе
        public Seller Seller {get;set;}
        //очередь на кассу
        public Queue <Cart> Queue { get; set; }
        //максимальная длина очереди
        public int MaxQueueLenght { get; set; }
        //счётчик для учёта покупателей
        public int ExitCustomer { get; set; }
        //условие для проверки и добавления в БД
        public bool IsModel { get; set; }
        //переменная для определения очереди с наименьшим количеством
        public int Count => Queue.Count;
        public CashDesk(int number,Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
        }
        //добавление покупателя в очередь
        public void Enqueue(Cart cart)
        {
            //если касса не перегружена, добавляется покупатель
            if (Queue.Count <= MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            //если очередь максимальная покупатель уходит
            else
            {
                ExitCustomer++;
            }
        }
        //извлечение покупателя из очереди
        public decimal Dequeue()
        {
            decimal sum = 0;
            if (Queue.Count == 0)
            {
                return 0;
            }
            //самый первый покупатель из очереди
            var card= Queue.Dequeue();
            if (card != null)
            {
                //добавление значений в чек
                var check = new Check() { SellerId = Seller.SellerId, Seller = Seller, Customer = card.Customer, CustomerId = card.Customer.CustomerId, Created = DateTime.Now };
                if(!IsModel)
                {
                    //добавление чека в БД
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }
                //список продаж 
                var sells = new List<Sell>();
                //перебор всех продуктов в корзине покупателя
                foreach (Product product in card)
                {
                    if (product.Count > 0)
                    {
                        //добавление значений в БД продаж
                        var sell = new Sell() { CheckId = check.CheckId, Check = check, ProductId = product.ProductId, Product = product };
                        sells.Add(sell);
                        if (!IsModel)
                        {
                            //добавление информации о продаже
                            db.Sells.Add(sell);
                        }
                        product.Count--;
                        sum += product.Price;
                    }
                }
                //сохранение изменений в БД
                if(!IsModel)
                {
                    db.SaveChanges();
                }
            }
            return sum;
        }
    }
}
