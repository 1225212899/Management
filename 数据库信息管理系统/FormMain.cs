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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //选中整行
            dataGridView1.AllowUserToAddRows = false; //删除空白多余行
            dataGridView1.AutoGenerateColumns = false; //不允许自动添加列
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Search();
            IntiDepartment();
        }

        private void Search()
        {
            dataGridView1.DataSource = null;
            string sqlStr = "select id,name,Department.department,sex,birthday,age from Employees inner join Department on Employees.departmentid=Department.departmentid";
            DataTable dataTable = SqlHelper.GetDataTable(sqlStr);
            dataGridView1.DataSource = dataTable;
        }

        private void IntiDepartment()
        {
            string sqlStr = $"select department,departmentid from Department";
            DataTable dataTable = SqlHelper.GetDataTable(sqlStr);
            comboBox1.DataSource = dataTable;

            DataRow dataRow = dataTable.NewRow();
            dataRow["department"] = "请选择";
            dataRow["departmentid"] = 0;
            dataTable.Rows.InsertAt(dataRow, 0);

            comboBox1.DisplayMember = "department";
            comboBox1.ValueMember = "departmentid";
            comboBox1.SelectedIndex = 0;
        }

        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string department = comboBox1.Text.Trim();
            string sqlStr = $"select id,name,Department.department,sex,birthday,age from Employees inner join Department on Employees.departmentid=Department.departmentid where department ='{department}' and name='{name}'";

            if (!string.IsNullOrWhiteSpace(name) && department!="请选择")
            {
                DataTable dataTable = SqlHelper.GetDataTable(sqlStr);
                dataGridView1.DataSource = dataTable;
            }
            else if (!string.IsNullOrWhiteSpace(name) && department == "请选择")
            {
                string sqlStr3 = $"select id,name,Department.department,sex,birthday,age from Employees inner join Department on Employees.departmentid=Department.departmentid where name ='{name}'";
                DataTable dataTable = SqlHelper.GetDataTable(sqlStr3);
                dataGridView1.DataSource = dataTable;
            }
            else if (string.IsNullOrWhiteSpace(name) && department != "请选择")
            {
                string sqlStr2 = $"select id,name,Department.department,sex,birthday,age from Employees inner join Department on Employees.departmentid=Department.departmentid where department ='{department}'";
                DataTable dataTable = SqlHelper.GetDataTable(sqlStr2);
                dataGridView1.DataSource = dataTable;
            }
            
        }

        //刷新
        private void button2_Click(object sender, EventArgs e)
        {
            Search();
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
        }

        //切换账号
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            User.UserID = null;
            formLogin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRePassword formRePassword = new FormRePassword();
            formRePassword.Show();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridView1.ClearSelection(); //清除当前选择
                        dataGridView1.Rows[e.RowIndex].Selected = true; //选择当前右键点击目标
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]; //将选中的目标设置为活跃状态
                        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请选择内容");
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeAdd employeeAdd = new EmployeeAdd();
            employeeAdd.Show();
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            EmployeeModify employeeModify = new EmployeeModify(Convert.ToInt32(id));
            employeeModify.Show();
        }
    }
}
