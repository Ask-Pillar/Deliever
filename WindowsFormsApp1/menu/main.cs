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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CreatDeliever(comboBox1.Text).Show();
            CreatDeliever cd = new CreatDeliever();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CreatRepory cr = new CreatRepory();
            cr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectcangku ck = new selectcangku(comboBox1.Text);
            ck.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EveryDeliever ed = new EveryDeliever();
            ed.Show();
        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“delieverDataSet7.Employee”中。您可以根据需要移动或删除它。
            this.employeeTableAdapter.Fill(this.delieverDataSet7.Employee);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new empoly().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new GoodsNameAdd().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            new ChangeDeliver().Show();
        }
    }
}
