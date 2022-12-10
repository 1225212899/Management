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
    public partial class FormRePassword : Form
    {
        public FormRePassword()
        {
            InitializeComponent();
        }

        private void FormRePassword_Load(object sender, EventArgs e)
        {
            label1.Text = "账号"+User.UserID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldPwd = textBox1.Text.Trim();
            string newPwd = textBox2.Text.Trim();
            string newPwd2 = textBox3.Text.Trim();
            string sqlStr = $"update UserTable set Pwd='{newPwd2}' where LoginID='{User.UserID}'";

            if (TestOldPwd(oldPwd))
            {
                if (newPwd == newPwd2)
                {
                    SqlHelper.ExecuteSql(sqlStr);
                    MessageBox.Show("修改成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("两次密码不一致");
                }
            }
            else
            {
                MessageBox.Show("原密码错误");
            }



        }

        private bool TestOldPwd(string oldPwd)
        {
            string sqlStr = $"select LoginID,Pwd from UserTable where LoginID='{User.UserID}' and Pwd='{oldPwd}'";
            var dataTable = SqlHelper.GetDataTable(sqlStr);
            if (dataTable.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
