using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace 数据库信息管理系统
{
    public partial class EmployeeAdd : Form
    {
        public EmployeeAdd()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeAdd_Load(object sender, EventArgs e)
        {
            string sqlStr = "select department,departmentid from Department";
            DataTable dataTable = SqlHelper.GetDataTable(sqlStr);
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember= "department";
            comboBox1.ValueMember = "departmentid";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            //string department = comboBox1.Text.Trim();
            int departmentid = (int)comboBox1.SelectedValue;
            string sex = radioButton1.Checked ? "男" : "女";
            string birthday = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string age = numericUpDown1.Value.ToString();
            string sqlStr = $"insert into Employees values ('{name}', {departmentid}, '{sex}', '{birthday}', {age})";

            bool b = SqlHelper.ExecuteSql(sqlStr);
            if (b)
            {
                MessageBox.Show("添加成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}
