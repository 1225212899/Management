using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 数据库信息管理系统
{
    public partial class EmployeeModify : Form
    {
        public int Id { get; set; }
        public EmployeeModify()
        {
            InitializeComponent();
        }
        public EmployeeModify(int id)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            int departmentid = (int)comboBox1.SelectedValue;
            string sex = radioButton1.Checked ? "男" : "女";
            string birthday = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string age = numericUpDown1.Value.ToString();
            //string sqlStr = $"insert into Employees values ('{name}', {departmentid}, '{sex}', '{birthday}', {age})";
            string sqlStr = $"update Employees set name='{name}',departmentid='{departmentid}',sex='{sex}',birthday='{birthday}',age='{age}' where id='{Id}'";

            bool b = SqlHelper.ExecuteSql(sqlStr);
            if (b)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void EmployeeModify_Load(object sender, EventArgs e)
        {
            string sqlStr = "select department,departmentid from Department";
            DataTable dataTable2 = SqlHelper.GetDataTable(sqlStr);
            comboBox1.DataSource = dataTable2;
            comboBox1.DisplayMember = "department";
            comboBox1.ValueMember = "departmentid";

            #region 获取原信息
            string sqlStrByid = $"select * from Employees where id={Id}";
            var dataTable = SqlHelper.GetDataTable(sqlStrByid);
            DataRow dataRow = dataTable.Rows[0];
            //MessageBox.Show(dataRow["id"].ToString());
            textBox1.Text = dataRow["name"].ToString();
            comboBox1.SelectedValue = dataRow["departmentid"].ToString();
            if (dataRow["sex"].ToString() == "男")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            dateTimePicker1.Value = (DateTime)dataRow["birthday"];
            numericUpDown1.Value = (int)dataRow["age"];
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
