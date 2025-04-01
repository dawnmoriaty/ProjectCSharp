using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharp
{
    public partial class themgiaodich : Form
    {
        public themgiaodich()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedItem.ToString() == "Khoản chi")
            {
                DataTable expenseCategories = DatabaseHelper.GetExpenseCategories();
                foreach (DataRow row in expenseCategories.Rows)
                {
                    comboBox2.Items.Add(row["CategoryName"].ToString());
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Khoản thu")
            {
                DataTable incomeCategories = DatabaseHelper.GetIncomeCategories();
                foreach (DataRow row in incomeCategories.Rows)
                {
                    comboBox2.Items.Add(row["CategoryName"].ToString());
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtSotien.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            try
            {
                var result = new DataTable().Compute(txtSotien.Text, null);
                txtSotien.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid expression: " + ex.Message);
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "0";
        }

        private void btn000_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "000";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "9";
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "+";
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "-";
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "*";
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "/";
        }

        private void btnPhay_Click(object sender, EventArgs e)
        {
            txtSotien.Text += ".";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSotien.Text.Length > 0)
            {
                txtSotien.Text = txtSotien.Text.Remove(txtSotien.Text.Length - 1);
            }
        }
    }
}
