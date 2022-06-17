using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class CustomerForm : Form
    {
        //Объект на основе класса покупатель
        public Customer Customer { get; set; }
        public CustomerForm()
        {
            InitializeComponent();
        }
        public CustomerForm(Customer customer):this()
        {
            //Установка данных в конструктор
            Customer = customer;
            //Присвоение имени
            textBox1.Text = Customer.Name;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявление объекта если его не сущетсвует
            var c = Customer ?? new Customer();
            //Присвоение имени
            c.Name = textBox1.Text;
            Close();
        }
    }
}
