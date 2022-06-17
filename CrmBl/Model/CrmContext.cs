using System.Data.Entity;

namespace CrmBl.Model
{
    //Класс контекст
    public class CrmContext :DbContext
    {
        //Установка связи с базой данных
        public CrmContext() : base("CrmConnection") { }
        //Установка связи с таблицами
        public DbSet<Check> Checks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Seller> Sellers { get; set; }


    }
}
