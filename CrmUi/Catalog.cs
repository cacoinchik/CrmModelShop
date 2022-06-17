using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    //Определение каталога для вывода данных с БД
    public partial class Catalog<T> : Form
        where T : class //Т определяется как класс (Продавец,Чек и т.д.)
    {
        //Объявление объекта на основе класса контекста
        CrmContext db;
        DbSet<T> set;
        //Неуниверсальная версия DbSet<>, которую можно использовать, когда тип сущности неизвестен во время сборки.
        public Catalog(DbSet<T> set,CrmContext db)
        {
            InitializeComponent();
            //Установка данных в конструктор
            this.db = db;
            this.set = set;
            //Загрузка  данных из БД
            set.Load();
            //Привязка получаемых данных из БД к листу
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }
        //Кнопка добавить
        private void button1_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {

            }
            else if (typeof(T) == typeof(Seller))
            {

            }
            else if (typeof(T) == typeof(Customer))
            {

            }
        }
        //Кнопка изменить
        private void button2_Click(object sender, EventArgs e)
        {
            //идентификатор записи
            var id=dataGridView.SelectedRows[0].Cells[0].Value;

            //Если выбранная таблицы Product, идет изменение записи в БД
            if (typeof(T) == typeof(Product))
            {
                //определение выбранной записи
                var product=set.Find(id) as Product;
                //если запись не пустая
                if (product!=null)
                {
                    //создание формы
                    var form = new ProductForm(product);
                    //если внесены данные
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //обновление данных
                        product = form.Product;
                        //сохранение изменений
                        db.SaveChanges();
                        //обновление формы
                        dataGridView.Update();
                    }
                }
            }
            //Если выбранная таблицы Product, идет изменение записи в БД
            else if (typeof(T) == typeof(Seller))
            {
                //определение выбранной записи
                var seller = set.Find(id) as Seller;
                //если запись не пустая
                if (seller != null)
                {
                    //создание формы
                    var form = new SellerForm(seller);
                    //если внесены данные
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //обновление данных
                        seller = form.Seller;
                        //сохранение изменений
                        db.SaveChanges();
                        //обновление формы
                        dataGridView.Update();
                    }
                }
            }
            //Если выбранная таблицы Product, идет изменение записи в БД
            else if (typeof(T) == typeof(Customer))
            {
                //определение выбранной записи
                var customer = set.Find(id) as Customer;
                //если запись не пустая
                if (customer != null)
                {
                    //создание формы
                    var form = new CustomerForm(customer);
                    //если внесены данные
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //обновление данных
                        customer = form.Customer;
                        //сохранение изменений
                        db.SaveChanges();
                        //обновление формы
                        dataGridView.Update();
                    }
                }
            }
        }
        //Кнопка удалить
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
