using System;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUi
{
    public partial class Main : Form
    {
        //Объекто на основе класса контекста для связи с БД
        CrmContext db;
        public Main()
        {
            InitializeComponent();
            //Объявление объекта
            db = new CrmContext();
        }
        //Открытие БД Товары
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products,db);
            catalogProduct.Show();
        }
        //Открытие БД Продавцов
        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<Seller>(db.Sellers,db);
            catalogSeller.Show();
        }
        //Открытие БД Покупателя
        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers,db);
            catalogCustomer.Show();
        }
        //Открытие БД Чек
        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks,db);
            catalogCheck.Show();
        }
        //Добавление покупателя
        private void CustomerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Создание и открытие формы
            var form = new CustomerForm();
            //если внесены данные
            if (form.ShowDialog() == DialogResult.OK)
            {
                //Добавление записи в БД
                db.Customers.Add(form.Customer);
                //Сохранение изменений
                db.SaveChanges();
            }
        }
        //Добавление продавца
        private void SellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Создание и открытие формы
            var form = new SellerForm();
            //если внесены данные
            if (form.ShowDialog() == DialogResult.OK)
            {
                //Добавление записи в БД
                db.Sellers.Add(form.Seller);
                //Сохранение изменений
                db.SaveChanges();
            }
        }
        //Добавление продукта/товара
        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Создание и открытие формы
            var form = new ProductForm();
            //если внесены данные
            if (form.ShowDialog() == DialogResult.OK)
            {
                //Добавление записи в БД
                db.Products.Add(form.Product);
                //Сохранение изменений
                db.SaveChanges();
            }
        }
    }
}
