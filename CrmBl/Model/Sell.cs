
namespace CrmBl.Model
{
    //Класс модели(Продажи)
    public class Sell
    {
        //Id продажи
        public int SellId { get; set; }
        //Id чека по свзяи
        public int CheckId { get; set; }
        //Id продукта по связи
        public int ProductId { get; set; }
        //Связь с чеком
        public virtual Check Check { get; set; }
        //Связь с продуктом
        public virtual Product Product { get; set; }
    }
}
