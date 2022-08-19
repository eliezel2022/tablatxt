using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XventoryLDB
{
    public partial class EditProductForm : Form
    {
        public static int id;
        public DataGridView ghostdg;
        public EditProductForm()
        {
            InitializeComponent();
            id_label.Text = id + "";

            var db = Db.connect();
            var col = db.GetCollection<Product>("product");
            Product p = new Product();
            foreach (var r in col.FindAll())
            {
                if (r.Id == id)
                {
                    p = r;
                    break;
                }
            }
            pname.Text = p.Name;
            ppricein.Text = p.PriceIn;
            string a = p.fecha.ToString();
            var nuevafecha = Convert.ToDateTime(p.fecha);
            nuevafecha = nuevafecha.AddDays(30);
            string cc = nuevafecha.ToString("dd-MM-yyyy");
            txtdevolucion.Text = cc.ToString();
            txtprestamo.Text = a.ToString();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pname.Text != ""  && ppricein.Text != "")
            {
                Product p = new Product();
                p.Id = id;
                p.Name = pname.Text;
                p.PriceIn = ppricein.Text;
                
                
               

                var db = Db.connect();
                var col = db.GetCollection<Product>("product");
                col.Update(p);

                MessageBox.Show("Actualizado exitosamente!");
                Form1.filldg(ghostdg);
            }
            else
            {
                MessageBox.Show("No puedes dejar campos vacios!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            


            var db = Db.connect();
            var col = db.GetCollection<Product>("product");
            var col2 = db.GetCollection<Operation>("operation");

            foreach(var c in col2.FindAll())
            {
                if (c.ProductId == id)
                {
                    col2.Delete(c.Id);
                }
            }

            col.Delete(id);
            MessageBox.Show("Eliminado exitosamente!");
            Form1.filldg(ghostdg);
            this.Close();
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
