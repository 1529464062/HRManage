using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace HRManage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 cla=new Class1();
            string userName = textBox1.Text.Trim();
            string userPassword = textBox2.Text.Trim();
            string userType = textBox3.Text.Trim();                        
            MessageBox.Show(cla.returnMD5Value(userName, userPassword, userType));
            DataBind();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBind();
        }
        private void DataBind()
        {
            DAL.Class1 cla = new Class1();
            dataGridView1.DataSource = cla.returnDataTable();
        }
    }
}
