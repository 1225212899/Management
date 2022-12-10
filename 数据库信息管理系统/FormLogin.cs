using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 数据库信息管理系统
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); //系统退出
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string LoginID = this.textBox1.Text.Trim();
            string pwd = this.textBox2.Text.Trim();
            string sqlStr = $"select LoginID,pwd from UserTable where LoginID='{LoginID}' and pwd='{pwd}'";

            SqlDataReader sqlDataReader = SqlHelper.Reader(sqlStr);
            if (sqlDataReader.Read() == true)
            {
                this.Hide();
                MessageBox.Show("欢迎","提示",MessageBoxButtons.OK);
                FormMain formMain = new FormMain();
                formMain.Show();
                User.UserID = LoginID;
            }
            else
            {
                this.textBox1.Clear();
                this.textBox2.Clear();
                DialogResult dr = MessageBox.Show("用户不存才，是否注册", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    FormRegister formRegister = new FormRegister();
                    formRegister.Show();
                }
                else
                {
                    textBox1.Focus();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出系统", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }
    }
}
