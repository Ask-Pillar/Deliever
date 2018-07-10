using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class selectcangku : Form
    {
        public string pepolename;

        public selectcangku()
        {
            InitializeComponent();
        }

        public selectcangku(string name):this()
        {
            pepolename = name;
        }

        //栋修改
        private void Main_Load(object sender, EventArgs e)
        {
            
            try
            {
                //填充combobox中的仓库名字
                this.transReporatoryTableAdapter.Fill(this.delieverDataSet.TransReporatory);
                this.comboBox1.DisplayMember = "TransReporatoryName";
            }
            catch
            {
                MessageBox.Show("请连接网络");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DelieverGoodsForm(comboBox1.Text,pepolename).Show();
        }
    }
}
