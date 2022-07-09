using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace Mini_MarketManagement_System
{
    public partial class SellingForm : Form
    {
        readonly DBConnect dBCon= new DBConnect();
        readonly DGVPrinter printer= new DGVPrinter();
        public SellingForm()
        {
            InitializeComponent();
        }
        private void Getcategory()
        {
            string selectQuerry = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox_category.DataSource = table;
            comboBox_category.ValueMember = "CatName";
        }

        private void DataGridView_seller_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     
        private void Gettable()
        {
            string selectQuerry = "SELECT ProdName,ProdPrice FROM Product";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;
        }
        private void GetSelltable()
        {
            string selectQuerry = "SELECT * FROM Bill";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_sellList.DataSource = table;
        }
        private void SellingForm_Load(object sender, EventArgs e)
        {
            label_date.Text = DateTime.Today.ToShortDateString();
            label_seller.Text = LoginForm.sellerName;
            Gettable();
            Getcategory();
            GetSelltable();
        }

       

        private void DataGridView_product_Click(object sender, EventArgs e)
        {
            textBox_name.Text=DataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            textBox_price.Text = DataGridView_product.SelectedRows[0].Cells[1].Value.ToString();

        }
        int grandTotal = 0, n = 0;

        private void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Bill VALUES(" + textBox_id.Text + ",'" + label_seller.Text + "','" + label_date.Text + "','" + grandTotal.ToString()+ "')";
                SqlCommand command = new SqlCommand(insertQuery, dBCon.GetCon());
                dBCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Order added successfully", "Order Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBCon.CloseCon();
                GetSelltable();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_print_Click(object sender, EventArgs e)
        {
            //we need DGVPrinter helper for PDF file
            printer.Title = "Serene Supermarket Sell Lists";
            printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "foxlearn";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_sellList); 
        }

        private void Label_logout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void Button_refresh_Click(object sender, EventArgs e)
        {
            Gettable();
        }

        private void ComboBox_category_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectQuerry = "SELECT ProdName,Prodprice FROM Product WHERE ProdCat='" + comboBox_category.SelectedValue.ToString() + "'";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;

        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_addOrder_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text == "" || textBox_qty.Text == "")
            {
                MessageBox.Show("Missing Information","Information Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                int Total = Convert.ToInt32(textBox_price.Text) * Convert.ToInt32(textBox_qty.Text);
                DataGridViewRow addRow = new DataGridViewRow();
                addRow.CreateCells(DataGridView_order);
                addRow.Cells[0].Value = ++n;
                addRow.Cells[1].Value = textBox_custName.Text;
                addRow.Cells[2].Value = textBox_name.Text;
                addRow.Cells[3].Value = textBox_price.Text;
                addRow.Cells[4].Value = textBox_qty.Text;
                addRow.Cells[5].Value = Total;
                DataGridView_order.Rows.Add(addRow);
                grandTotal += Total;
                label_amount.Text = grandTotal + " Rs";
            }
        }
    }
}
