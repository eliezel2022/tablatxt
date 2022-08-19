using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LiteDB;

namespace XventoryLDB
{
    public partial class ProductForm : Form
    {
        public DataGridView ghostdg;
        public ProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pname.Text!=""  && ppricein.Text != "")
            {
                Product p = new Product();
               
                p.Name = pname.Text; 
                p.PriceIn = ppricein.Text;
                
                var db = Db.connect();
                var col = db.GetCollection<Product>("product");
                col.Insert(p);

                
                MessageBox.Show("Agregado correctamente");
                Form1.filldg(ghostdg);
            }
            else
            {
                MessageBox.Show("No puedes dejar campos vacios");
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
