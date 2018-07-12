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

    public partial class SubDeliverGoodsForm : Form
    {
        //delievergoodsform传过来的参数
        public DataGridViewCellCollection dgrc;
        //大运单ID
        public int delId;
        //当前仓库名字
        public string ThisStation;
        //下一站仓库的名字
        public string NextStationname;
        //路线中所含仓库
        public string[] TSname;
        //子运单信息
        public List<string> SubDel=new List<string>();
        //人员名字
        public string people;
        
        public SubDeliverGoodsForm()
        {
            InitializeComponent();
        }

        public SubDeliverGoodsForm(DataGridViewCellCollection dgrc,string str,string name):this()
        {
            this.ThisStation = str;
            this.dgrc = dgrc;
            this.delId = (int)dgrc[0].Value;
            people = name;
            TSName();
        }

        //栋修改
        private void butdeliver_Click(object sender, EventArgs e)
        {

            bool tishi = false;
           
            try
            {
                 
                {
                    string ex = @"^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$";
                    if (Tool.TextBoxExpression(textBox2, ex))
                    {
                        SubDelIver();
                    }
                    else
                    {
                        textBox2.Text = "";
                        MessageBox.Show("请输入正确格式的车牌号");

                    }
                    int SubID = DBHelper.SelectId(DBHelper.AddSubDelieversql(SubDel));
                    tishi = true;

                    //添加货物
                    foreach (ListViewItem lvi in listView1.Items)
                    {
                        string name = lvi.SubItems[0].Text;
                        int number = Convert.ToInt32(lvi.SubItems[1].Text);
                        if (tishi == true)
                        {
                            try
                            {
                                //子订单添加货物
                                int num = DBHelper.ExcuteSQL(
                                DBHelper.AddSubGoods(DBHelper.GetTable(DBHelper.GoodsID(name)).Rows[0][0].ToString(),
                                SubID, number));
                                //修改当前仓库的货物数量
                                int num1 = DBHelper.ExcuteSQL(DBHelper.GoodsReduce(delId, ThisStation, name, number));
                                tishi = true;

                            }
                            catch
                            {
                                tishi = false;
                                MessageBox.Show("添加货物失败");
                            }
                        }
                        else
                            break;

                    }
                    if (tishi == true)
                    {
                        try
                        {

                            //修改大订单状态
                            DataTable dt = DBHelper.GetTable(DBHelper.HaveStatu(delId));
                            int have = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            DBHelper.ExcuteSQL(DBHelper.Modify(have, 1, delId));
                            tishi = true;
                        }
                        catch
                        {
                            tishi = false;
                            MessageBox.Show("修改大运单状态失败");
                        }
                    }
                }

            }
            catch
            {
                tishi = false;
                MessageBox.Show("运单创建失败");
            }

            if(tishi==true)
            {
                MessageBox.Show("子运单发货成功");
                Display();
            }
        }

        private void SubDeliverGoodsForm_Load(object sender, EventArgs e)
        {
            //显示路线
            int i = 0;
            for(;i<TSname.Length-1;i++)
            {
                Routes_lab.Text += TSname[i] + " --> ";
            }
            Routes_lab.Text += TSname[i++];

            //填充子运单数据
            Display();

            //目的仓库
            label10.Text = ThisStation;
            label13.Text=(this.NextStationname = TSname[NextStation()]);

            //现在仓库中已有的货物
            comboBox2.DataSource = DBHelper.GetTable(DBHelper.Goods(delId, ThisStation));
            this.comboBox2.DisplayMember = "GoodsName";           
        }


        //填充路线仓库
        private void TSName()
        {
            string str;
            string sql = "select DelieverTransferReporatory from Deliever where DelieverID=" + delId;
            DataTable table = DBHelper.GetTable(sql);
            if(table.Rows[0][0].ToString()!="")
            {
                str = dgrc[5].Value.ToString() + ",";
                str += table.Rows[0][0].ToString();
                str += "," + dgrc[6].Value.ToString();
            }
            else
            {
                str = dgrc[5].Value.ToString() + "," + dgrc[6].Value.ToString();
            }
            TSname = str.Split(new char[] { ',' });
        }

        //寻找下一站
        private int NextStation()
        {
            int i;
            for(i=0;i<TSname.Length;i++)
            {
                if (ThisStation == TSname[i])
                    break;    
            }
            if (i<TSname.Length-1)
            {
                return i + 1;
            }
            else
            {
                return i;
            }
            
        }

        //添加货物
        private void button1_Click(object sender, EventArgs e)
        {

            if (Tool.TextBoxExpression(textBox1, @"^\+?[1-9][0-9]*$") && Convert.ToInt32(textBox1.Text) > 0) 
            {
                if (GoodsNumber()[0] - Convert.ToInt32(textBox1.Text) >= 0)
                {
                    if (GoodsNumber()[1]!= -1)
                    {
                        int num =Convert.ToInt32( listView1.Items[GoodsNumber()[1]].SubItems[1].Text);
                        num += Convert.ToInt32(textBox1.Text);
                        listView1.Items[GoodsNumber()[1]].SubItems[1].Text = num.ToString();                  
                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem(comboBox2.Text);
                        listView1.Items.Add(lvi);
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, textBox1.Text));
                    }
                    tishi();
                    textBox1.Text = "";

                }
                else
                {
                    MessageBox.Show("现有该货物不足以发货" + textBox1.Text+"件");
                }
            }
            else
            {
                MessageBox.Show("货物的数量请输入正确格式");
            }



        }

        //添加运单
        private void SubDelIver()
        {
                SubDel.Clear();

                string ThisID = DBHelper.GetTable(DBHelper.GetReID(ThisStation)).Rows[0][0].ToString();
                string NextID = DBHelper.GetTable(DBHelper.GetReID(NextStationname)).Rows[0][0].ToString();
                //添加数据
                this.SubDel.Add(this.delId.ToString());
                this.SubDel.Add(DBHelper.GetTable(DBHelper.EmpolyeeID(people)).Rows[0][0].ToString());
                this.SubDel.Add(ThisID);
                this.SubDel.Add(NextID);
                this.SubDel.Add(comboBox3.Text);
                this.SubDel.Add(textBox2.Text);
                this.SubDel.Add("0");
                this.SubDel.Add(DateTime.Now.ToString());

        }

        //添加货物
        private List<string> Addgoods(string id, string number)
        {
            List<string> str = new List<string>();
            str.Add(id);
            str.Add(SubDel[0]);
            str.Add(number);
            str.Add("");
            return str;
         }

        //创建子订单ID
        private string SubID(string deid,string Thisid,string Nextid )
        {
            return Thisid + deid + Nextid;
        }

        //显示仓库名字
        private DataTable Table(DataTable dt_temp)
        {
            int length = dt_temp.Rows.Count;
            if (length > 0)
            {
                dt_temp.Columns.Add(new DataColumn("本站"));
                dt_temp.Columns.Add(new DataColumn("下一站"));
                dt_temp.Columns.Add(new DataColumn("状态"));
                for (int i = 0; i < length; i++)
                {
                    int startRepID = (int)dt_temp.Rows[i]["本站ID"];
                    int destRepID = (int)dt_temp.Rows[i]["下一站ID"];
                    string startRepName = DBHelper.GetTable(DBHelper.GetStartDestName(startRepID)).Rows[0][0].ToString();
                    string destRepName = DBHelper.GetTable(DBHelper.GetStartDestName(destRepID)).Rows[0][0].ToString();
                    dt_temp.Rows[i]["本站"] = startRepName;
                    dt_temp.Rows[i]["下一站"] = destRepName;
                    if((int)dt_temp.Rows[i]["状态码"]==0)
                    {
                        dt_temp.Rows[i]["状态"] = "已发";
                    }
                    else
                    {
                        dt_temp.Rows[i]["状态"] = "完成";
                    }           
                }
            }
            return dt_temp;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewCellCollection dgrc = dataGridView1.CurrentRow.Cells;

        }

        //提示货物剩余多少(栋)
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tishi();   
        }

        //显示子订单(栋)
        private void Display()
        {
            dataGridView1.DataSource = Table(DBHelper.GetTable(DBHelper.SubDelieversql(delId, ThisStation)));
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        //删除
        private void DeleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            for (int i = this.listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem item = this.listView1.SelectedItems[i];
                this.listView1.Items.Remove(item);
            }
            tishi();
        }

        //修改
        private void ModifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        
        private List<int> GoodsNumber()
        {
            List<int> vs = new List<int>();
             int number = Convert.ToInt32(DBHelper.GetTable(
              DBHelper.GoodsNumber(delId, ThisStation, comboBox2.Text)).Rows[0][0]);
            int i = -1;
            foreach (ListViewItem lvi in listView1.Items)
            {
                if (comboBox2.Text == lvi.SubItems[0].Text)
                {
                    number -= Convert.ToInt32(lvi.SubItems[1].Text);
                    i = listView1.Items.IndexOf(lvi);
                  
                }
            }
            vs.Add(number);
            vs.Add(i);
            return vs;
        }

        private void tishi()
        {
            try
            {
                int number = GoodsNumber()[0];
                Over_Lab.Text = "您选定的货物剩余：" + number;

            }
            catch
            {
                Over_Lab.Text = "您选定的货物剩余：";
            }
        }
    }
}
