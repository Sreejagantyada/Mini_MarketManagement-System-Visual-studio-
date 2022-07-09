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

namespace Mini_MarketManagement_System
{
    public partial class ProductForm : Form
    {
        DBConnect dBCon = new DBConnect();
        public ProductForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label_exit_Click(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            getcategory();
            gettable();
        }
        private void getcategory()
        {
            string selectQuerry = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox_category.DataSource = table;
            comboBox_category.ValueMember = "CatName";
            comboBox_search.DataSource = table;
            comboBox_search.ValueMember = "CatName";
        }

        private void button_category_Click(object sender, EventArgs e)
        {
            CategoryForm category = new CategoryForm();
            category.Show();
            this.Hide();
        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void gettable()
        {
            string selectQuerry = "SELECT * FROM Product";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;
        }
        private void clear()
        {
            textBox_id.Clear();
            textBox_name.Clear();   
            textBox_price.Clear();
            textBox_qty.Clear();
            comboBox_category.SelectedIndex = 0;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Product VALUES(" + textBox_id.Text + ",'" + textBox_name.Text + "','" + textBox_price.Text + "','" + textBox_qty.Text + "','" + comboBox_category.Text + "')";
                SqlCommand command = new SqlCommand(insertQuery, dBCon.GetCon());
                dBCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Product added successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBCon.CloseCon();
                gettable();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_id.Text == "" || textBox_name.Text == "" || textBox_price.Text == "" || textBox_qty.Text == "")
                {
                    MessageBox.Show("Missing Information", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    string updateQuery = "UPDATE Product SET ProdName='" + textBox_name.Text + "',ProdPrice='" + textBox_price.Text + "',ProdQty='" + textBox_qty.Text + "',ProdCat='" + comboBox_category.Text + "'WHERE Prodid='" + textBox_id.Text + "' ";
                    SqlCommand command = new SqlCommand(updateQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product updated successfully", "update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBCon.CloseCon();
                    gettable();
                    clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

      

       

        private void DataGridView_product_Click(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            textBox_name.Text = DataGridView_product.SelectedRows[0].Cells[1].Value.ToString();
            textBox_price.Text = DataGridView_product.SelectedRows[0].Cells[2].Value.ToString();
            textBox_qty.Text = DataGridView_product.SelectedRows[0].Cells[3].Value.ToString();
            comboBox_category.SelectedValue = DataGridView_product.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (textBox_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    string deleteQuery = "DELETE FROM Product WHERE Prodid=" + textBox_id.Text + "";
                    SqlCommand command = new SqlCommand(deleteQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product deleted successfully", "delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBCon.CloseCon();
                    gettable();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            gettable();
        }

        private void comboBox_search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectQuerry = "SELECT * FROM Product WHERE ProdCat='" + comboBox_search.SelectedValue.ToString() + "'";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_qty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_seller_Click(object sender, EventArgs e)
        {
            SellerForm sellerForm = new SellerForm();
            sellerForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button_selling_Click(object sender, EventArgs e)
        {

        }
    }
}
