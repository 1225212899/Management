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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string LoginID = this.textBox1.Text.Trim();
            string Pwd1 = this.textBox2.Text.Trim();
            string Pwd2 = this.textBox3.Text.Trim();
            string sqlStr = $"insert into userTable values('{LoginID}', '{Pwd2}'); ";
            if (Pwd1 == Pwd2)
            {
                bool b = SqlHelper.ExecuteSql(sqlStr);
                if (b)
                {
                    MessageBox.Show("注册成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败");
                }
            }
            else
            {
                MessageBox.Show("输入密码不一致");
                this.textBox2.Clear();
                this.textBox3.Clear();
            }
            

        }
    }
}
