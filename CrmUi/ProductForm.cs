using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class ProductForm : Form
    {
        //Объект на основе класса продукт
        public Product Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }
        public ProductForm(Product product):this()
        {
            //Установка данных в конструктор
            Product = product;
            //Присовение имени,цены,количества товара на складе
            textBox1.Text = Product.Name;
            numericUpDown1.Value = Product.Price;
            numericUpDown2.Value = Product.Count;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявление объекта если его не сущетсвует
            var p = Product ?? new Product();
            //Присовение имени,цены,количества товара на складе
            p.Name = textBox1.Text;
            p.Price = numericUpDown1.Value;
            p.Count = (int)numericUpDown2.Value;
            Close();
        }
    }
}
