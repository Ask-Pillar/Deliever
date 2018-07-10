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

namespace WindowsFormsApp1
{
    public partial class SubAndRep : Form
    {
        //传过来大运单的参数
        public DataGridViewCellCollection dgrc;
        public int DelID;
        public SubAndRep()
        {
            InitializeComponent();
        }

        public SubAndRep(DataGridViewCellCollection dgrc):this()
        {
            this.dgrc = dgrc;
            DelID= (int)this.dgrc[0].Value;
        }

        private void SubAndRep_Load(object sender, EventArgs e)
        {
            label1.Text = "当前大运单："+DelID;
            dataGridView1.DataSource = DBHelper.GetTable(DBHelper.EverySubDel(DelID));
            dataGridView2.DataSource = DBHelper.GetTable(DBHelper.GoodsInTranRe(DelID));
        }
    }
}
