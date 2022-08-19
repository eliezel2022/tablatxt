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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("id", "Id");
            dataGridView1.Columns.Add("name", "Nombre");
            dataGridView1.Columns.Add("pricein", "Nombre del libro");
            dataGridView1.Columns.Add("priceout", "Fecha de prestamo");
            dataGridView1.Columns.Add("q", "Fecha de devolución");

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";



            filldg(dataGridView1);
        }

      

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }


        public static void filldg(DataGridView dg)
        {
            Product p = new Product();
            p.fecha = DateTime.Now;
            var Date = p.fecha.Date.ToString("dd-MM.yyyy");
            var nuevafecha = Convert.ToDateTime(p.fecha);
            nuevafecha = nuevafecha.AddDays(30);
            string cx = p.fecha.ToString("dd-MM-yyyy");
            string cc = nuevafecha.ToString("dd-MM-yyyy");
           



            var db = Db.connect();
            var col = db.GetCollection<Product>("product");
            var col2 = db.GetCollection<Operation>("operation");
            var qs = col2.FindAll();
            dg.Rows.Clear();
            foreach (var r in col.FindAll())
            {
                int qx = 0;
                
                foreach (var q in qs)
                {
                    if (q.ProductId == r.Id)
                    {
                        if (q.Kind == 1)
                        {
                            qx += q.Q;
                        }else if (q.Kind == 2)
                        {
                            qx -= q.Q;
                        }
                    }
                }
 
                dg.Rows.Add(r.Id, r.Name, r.PriceIn, cx,cc);
            }
        }



        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnprestar_Click(object sender, EventArgs e)
        {
            ProductForm plf = new ProductForm();
            plf.ghostdg = dataGridView1;
            plf.ShowDialog();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int c_id = int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            EditProductForm.id = c_id;
            EditProductForm ec = new EditProductForm();
            ec.ghostdg = dataGridView1;
            ec.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
