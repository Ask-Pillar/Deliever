using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.common;
using WindowsFormsApp1.linq;

namespace WindowsFormsApp1
{
    public partial class GoodsNameAdd : Form
    {
        public GoodsNameAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            linqtosqlDataClasses1DataContext linq;
            linq = new linqtosqlDataClasses1DataContext(SysConfig.constring);
            Goods good = new Goods();
            good.GoodsName = textBox1.Text+'*'+textBox2.Text;
            good.GoodsCode = textBox3.Text;
            int num= Convert.ToInt32(DBHelper.GetTable(DBHelper.goodsName(textBox1.Text + textBox2.Text)).Rows[0][0].ToString());
            if (num==0&&Tool.TextBoxExpression1(textBox1)&& Tool.TextBoxExpression1(textBox2)&& Tool.TextBoxExpression1(textBox3))//添加的语句是否已经有
            {
                linq.Goods.InsertOnSubmit(good);
                linq.SubmitChanges();
                MessageBox.Show(textBox1.Text + '*'+ textBox2.Text + "添加成功");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("该货物已有，添加失败");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void GoodsNameAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
