using CrmBl.Model;
using System;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class SellerForm : Form
    {
        //Объект на основе класса продавец
        public Seller Seller { get; set; }
        public SellerForm()
        {
            InitializeComponent();
        }
        public SellerForm(Seller seller) : this()
        {
            //Установка данных в конструктор
            Seller = seller;
            //Присовение имени
            textBox1.Text = Seller.Name;
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявление объекта если его не сущетсвует
            var s = Seller ?? new Seller();
            //Присовение имени
            s.Name = textBox1.Text;
            Close();
        }
    }
}
