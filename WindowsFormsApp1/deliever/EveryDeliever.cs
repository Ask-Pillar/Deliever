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
    public partial class EveryDeliever : Form
    {
        public EveryDeliever()
        {
            InitializeComponent();
        }

        private void EveryDeliever_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DBHelper.GetTable(DBHelper.EveryDel());
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewCellCollection dgrc = dataGridView1.CurrentRow.Cells;
            new SubAndRep(dgrc).Show();
        }
    }
}
