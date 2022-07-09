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
    public partial class SellerForm : Form
    {
        DBConnect dBCon = new DBConnect();
        public SellerForm()
        {
            InitializeComponent();
        }
        private void gettable()
        {
            string selectQuerry = "SELECT * FROM Seller";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_seller.DataSource = table;
        }

        private void clear()
        {
            textBox_id.Clear();
            textBox_name.Clear();   
            textBox_age.Clear();
            textBox_phone.Clear();
            textBox_pass.Clear();
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Seller VALUES(" + textBox_id.Text + ",'" + textBox_name.Text + "','" + textBox_age.Text + "','" + textBox_phone.Text + "','" + textBox_pass.Text + "')";
                SqlCommand command = new SqlCommand(insertQuery, dBCon.GetCon());
                dBCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Seller added successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBCon.CloseCon();
                gettable();
               clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            gettable();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_id.Text == "" || textBox_name.Text == "" || textBox_age.Text == "" || textBox_phone.Text == "" || textBox_pass.Text=="")
                {
                    MessageBox.Show("Missing Information", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    string updateQuery = "UPDATE Seller SET SellerName='" + textBox_name.Text + "',SellerAge='" + textBox_age.Text + "',SellerPhone='" + textBox_phone.Text + "',SellerPass='" + textBox_pass.Text + "'WHERE SellerId=" + textBox_id.Text + " ";
                    SqlCommand command = new SqlCommand(updateQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Seller updated successfully", "update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DataGridView_seller_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView_seller_Click(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_seller.SelectedRows[0].Cells[0].Value.ToString();
            textBox_name.Text = DataGridView_seller.SelectedRows[0].Cells[1].Value.ToString();
            textBox_age.Text = DataGridView_seller.SelectedRows[0].Cells[2].Value.ToString();
            textBox_phone.Text = DataGridView_seller.SelectedRows[0].Cells[3].Value.ToString();
            textBox_pass.Text=DataGridView_seller.SelectedRows[0].Cells[4].Value.ToString();

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
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM Seller WHERE Sellerid=" + textBox_id.Text + "";
                        SqlCommand command = new SqlCommand(deleteQuery, dBCon.GetCon());
                        dBCon.OpenCon();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Seller deleted successfully", "delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dBCon.CloseCon();
                        gettable();
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void button_Product_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show();
            this.Hide();
        }

        private void button_category_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.Show();
            this.Hide();
        }
    }
}
