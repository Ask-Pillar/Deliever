using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using WindowsFormsApp1.common;

namespace WindowsFormsApp1
{
    public partial class DelieverGoodsForm : Form
    {

        //当前仓库名字
        public string ReName;

        //人员名字
        public string peopleName;

        public DelieverGoodsForm()
        {
            InitializeComponent();
        }

        public DelieverGoodsForm(string str,string name):this()
        {
            ReName = str;
            peopleName = name;
        }

        private void SubDelieverGoodsForm_Load(object sender, EventArgs e)
        {
            
            //当前仓库名字
            label2.Text = ReName;
            //填充待发运单
            this.dataGridView1.DataSource = Table(DBHelper.GetTable(DBHelper.Delieversql(ReName)));
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            //填充代收货物
            
        }

        //选中某行内容，得到此行内容
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {  
            DataGridViewCellCollection dgrc = dataGridView1.CurrentRow.Cells;
            new SubDeliverGoodsForm(dgrc, ReName,peopleName).Show();
        }


        //显示仓库名字
        private DataTable Table(DataTable dt_temp)
        {
            int length = dt_temp.Rows.Count;
            if (length> 0)
            {
                dt_temp.Columns.Add(new DataColumn("起始地"));
                dt_temp.Columns.Add(new DataColumn("目的地"));
                for (int i=0; i<length;i++)
                {
                    int startRepID = (int)dt_temp.Rows[i]["起始地ID"];
                    int destRepID = (int)dt_temp.Rows[i]["目的地ID"];
                    string startRepName = DBHelper.GetTable(DBHelper.GetStartDestName(startRepID)).Rows[0][0].ToString();
                    string destRepName = DBHelper.GetTable(DBHelper.GetStartDestName(destRepID)).Rows[0][0].ToString();
                    dt_temp.Rows[i]["起始地"] = startRepName;
                    dt_temp.Rows[i]["目的地"] = destRepName;
                }
            }
            return dt_temp;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        //切换事件显示要收获的订单（志）
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id1 = DBHelper.GetTable(DBHelper.TransReporatoryId(label2.Text)).Rows[0][0].ToString();
            int id = Convert.ToInt32(id1);
            data_DeliverRe.DataSource = DBHelper.GetTable(DBHelper.selectbigsta(label2.Text,id));

        }


        public int delid;//DelieverID的全局变量

        //将中转站的货物表添加进去
        public List<string> teans = new List<string>();
        public int delID;
        private void data_DeliverRe_DoubleClick(object sender, EventArgs e)
        {

            disply();

        }

        //收获（志）
        private void btn_receive_Click(object sender, EventArgs e)
        {
            string id1 = DBHelper.GetTable(DBHelper.TransReporatoryId(label2.Text)).Rows[0][0].ToString();
            int id = Convert.ToInt32(id1);
            //获取大运单的ID
            int redelieverID = delID;
            //获取大运单中的目的ID
            string endID = DBHelper.GetTable(DBHelper.endtranID(redelieverID)).Rows[0][0].ToString();
            int reendID = Convert.ToInt32(endID);
            if (id != reendID)//该中转站不是终点站
            {

                try
                {
                    DataTable dt = DBHelper.GetTable(DBHelper.goodid(Convert.ToInt32(data_SubDeliverRe.SelectedCells[0].Value.ToString())));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //ru为TrabsReporGoods表的字段的ID
                        List<string> ru = new List<string>();
                        ru.Add(dt.Rows[i][0].ToString()); //货物ID
                        ru.Add(id1);//TransReporatoryID
                        ru.Add(dt.Rows[i][1].ToString());
                        ru.Add(redelieverID.ToString());
                        DBHelper.ExcuteSQL(DBHelper.AddTrabsReporGoods(ru));
                    }
                    DBHelper.ExcuteSQL(DBHelper.ChangesSubStatus(1, Convert.ToInt32(data_SubDeliverRe.SelectedCells[0].Value.ToString())));
                    //获取子订单的个数
                    string number = DBHelper.GetTable(DBHelper.havenum(redelieverID)).Rows[0][0].ToString();
                    int renumber = Convert.ToInt32(number);
                    //修改个数
                    DBHelper.ExcuteSQL(DBHelper.alterhave(renumber - 1, redelieverID));
                    MessageBox.Show("子运单已经完成收货");
                    disply();
                    data_DeliverRe.DataSource = DBHelper.GetTable(DBHelper.selectbigsta(label2.Text, id));
                   
                }
                catch (Exception)
                {
                    MessageBox.Show("收货失败");
                }

            }
            else
            {
                DataTable dt = DBHelper.GetTable(DBHelper.goodid(Convert.ToInt32(data_SubDeliverRe.SelectedCells[2].Value.ToString())));
                DataTable remp = DBHelper.GetTable(DBHelper.tranName(id));
                string reanname=remp.Rows[0][0].ToString();
                DataTable rename = DBHelper.GetTable(DBHelper.retranName(reanname));
                string reid = rename.Rows[0][0].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //ru为TrabsReporGoods表的字段的ID
                    List<string> ru = new List<string>();
                    ru.Add(dt.Rows[i][0].ToString()); //货物ID
                    ru.Add(id1);//TransReporatoryID
                    ru.Add(dt.Rows[i][1].ToString());
                    ru.Add(redelieverID.ToString());
                    DBHelper.ExcuteSQL(DBHelper.AddTrabsReporGoods(ru));
                }
                //修改子订单状态
                DBHelper.ExcuteSQL(DBHelper.ChangesSubStatus(1, Convert.ToInt32(data_SubDeliverRe.SelectedCells[0].Value.ToString())));
                //虚拟仓库的货物量和大订单的货物量相等的情况   条件需要改
                if (DBHelper.GetTable(DBHelper.sunnum(data_SubDeliverRe.SelectedCells[1].Value.ToString(), id)).Rows[0][0].ToString() 
                    == DBHelper.GetTable(DBHelper.renum(data_SubDeliverRe.SelectedCells[1].Value.ToString())).Rows[0][0].ToString())
                {
                    try
                    {
                        DataTable dt1 = DBHelper.GetTable(DBHelper.NumAndGoodID(redelieverID, id1));
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //ru为TrabsReporGoods表的字段的ID
                            List<string> ru = new List<string>();
                            ru.Add(reid);//真实仓库的ID
                            ru.Add(dt1.Rows[i][1].ToString()); //货物ID
                            ru.Add(dt1.Rows[i][0].ToString());//货物总量
                            DBHelper.ExcuteSQL(DBHelper.AddToReallyReporGoods(ru));
                        }
                        DBHelper.ExcuteSQL(DBHelper.Modify(0, 2, Convert.ToInt32(data_DeliverRe.SelectedCells[0].Value.ToString())));
                        MessageBox.Show("大运单已经完全收货");
                        disply();
                        data_DeliverRe.DataSource = DBHelper.GetTable(DBHelper.selectbigsta(label2.Text, id));
                  
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("收货失败");
                    }

                }
                else //是终点站数量还不够的时候
                {
                    try
                    {

                        //获取子订单的个数
                        string number = DBHelper.GetTable(DBHelper.havenum(redelieverID)).Rows[0][0].ToString();
                        int renumber = Convert.ToInt32(number);
                        //修改个数
                        DBHelper.ExcuteSQL(DBHelper.alterhave(renumber - 1, redelieverID));
                        MessageBox.Show("子运单已经完成收货");
                        disply();
                        data_DeliverRe.DataSource = DBHelper.GetTable(DBHelper.selectbigsta(label2.Text, id));
                       

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("收货失败");
                    }
                }
            }

        }
        private void disply()
        {
            if (data_DeliverRe.Rows.Count != 0)
            {
                int id = Convert.ToInt32(data_DeliverRe.SelectedCells[1].Value.ToString());
                delID = id;
                DataTable waitTempTable = DBHelper.GetTable(DBHelper.WaitReaichSubDliver(id, label2.Text));
                DataTable waitTempTable_SubDelID = DBHelper.GetTable(DBHelper.WaitReaichSubDliver_OnlyID(id, label2.Text));
                DataTable waitTable = new DataTable();
                foreach (DataColumn dc in waitTempTable.Columns)
                {
                    waitTable.Columns.Add(dc.ColumnName);
                }
                foreach (DataRow dr1 in waitTempTable_SubDelID.Rows)
                {
                    DataRow dr = waitTable.NewRow();
                    waitTable.Rows.Add(dr);
                }
                for (int i = 0; i < waitTable.Rows.Count; i++)
                {
                    foreach (DataRow dr2 in waitTempTable.Rows)
                    {
                        if (dr2[0].Equals(waitTempTable_SubDelID.Rows[i][0]))
                        {
                            for (int j = 0; j < waitTempTable.Columns.Count && j != 3; j++)
                            {
                                waitTable.Rows[i][j] = dr2[j];
                            }
                            waitTable.Rows[i][3] = dr2[3] + "/" + waitTable.Rows[i][3];
                            for (int k = 4; k < waitTempTable.Columns.Count; k++)
                            {
                                waitTable.Rows[i][k] = dr2[k];
                            }
                        }
                    }
                }

                data_SubDeliverRe.DataSource = waitTable;
            }
        }
          
    }
}


