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

   
    public partial class CreatDeliever : Form
    {
        string temp ="";
        string Emp;
        public string startStation;
        //下一站仓库的名字
        public string endStationname;
        //中转站
        List<string> transferr = new List<string>();
        //车站的名字
        

        public int deliverid;
        public CreatDeliever()
        {
            InitializeComponent();
        }
        public CreatDeliever(string str) : this()
        {
            Emp = str;
        }

        public List<string> Del = new List<string>();

        DataTable incombox;
        DataTable incomcoxGood;

        private void CreatDeliever_Load(object sender, EventArgs e)
        {
            incombox = DBHelper.GetTable(DBHelper.TransReporatoryName());
            incomcoxGood = DBHelper.GetTable(DBHelper.GOODnam());
            label8.Text = Emp;
            comboBox1.DataSource = incombox;
            cb_GoodsName.DataSource = incomcoxGood;
            this.comboBox1.DisplayMember = "TransReporatoryName";
            this.cb_GoodsName.DisplayMember = "GoodsName";

        }

        //创建大订单数据
        private void DelIver()
        
        {
                    int Rt = listView1.Items.Count;
                    string startID = DBHelper.GetTable(DBHelper.GetReID(listView1.Items[0].Text)).Rows[0][0].ToString();
                    string endID = DBHelper.GetTable(DBHelper.GetReID(listView1.Items[listView1.Items.Count - 1].Text)).Rows[0][0].ToString();
                    this.Del.Add(startID);
                    this.Del.Add(DBHelper.GetTable(DBHelper.EmpolyeeID(label8.Text)).Rows[0][0].ToString());
                    this.Del.Add(endID);
                    this.Del.Add("0");
                    this.Del.Add("0");
                    this.Del.Add(DateTime.Now.ToString());
                    this.Del.Add(Transferrstr());
        }

        public int delid;//DelieverID的全局变量
        
        //创建大运单
        private void btn_creatDliver_Click(object sender, EventArgs e)
        {
            bool delflag = false;
            bool num1flag = true;
            bool numflag = true;
      

                if (listView1.Items.Count > 1)
                {
                    DelIver();
                    //获取最后一个大运单的ID
                    delid = DBHelper.SelectId(DBHelper.AddDel(Del));
                    if (delid != 0)
                        delflag = true;
                    //添加进deliever表中
                    foreach (ListViewItem lvi in listView2.Items)
                    {
                        string name = lvi.SubItems[0].Text;
                        int number = Convert.ToInt32(lvi.SubItems[1].Text);
                        string goodsid = DBHelper.GetTable(DBHelper.GoodsID(name)).Rows[0][0].ToString();
                        string trid = DBHelper.GetTable(DBHelper.TransReporatoryId(listView1.Items[0].Text)).Rows[0][0].ToString();
                        //添加到仓库
                        int num1 = DBHelper.ExcuteSQL(
                            DBHelper.AddToTrabsReporGoods(goodsid, trid, number, delid));
                        if (num1 == 0)
                        {
                            num1flag = false;
                            break;
                        }
                        //添加到大运单
                        int num = DBHelper.ExcuteSQL(
                        DBHelper.Addbiggood(goodsid, delid, number));
                        if (num == 0)
                        {
                            numflag = false;
                            break;
                        }

                    }
                    if (num1flag == true && numflag == true && delflag == true)
                    {
                        MessageBox.Show("运单创建成功");
                    }
                }
                else
                {
                    MessageBox.Show("添加站的不足两个");

                }
            
         
          

        }

        private void btn_addstation_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count != 0)
            {
                temp = comboBox1.Text;
                List<string> ls = new List<string>();
                ListViewItem lvi = new ListViewItem(comboBox1.Text);
                listView1.Items.Add(lvi);
                transferr.Add(comboBox1.Text);
                Tool.DeletComboxData(incombox, comboBox1.Text);
            }
            else
            { 
                MessageBox.Show("无添加站");
            }
           

        }

        //中转站字符串
        private string Transferrstr()
        {
            string result="";
            if(transferr.Count!=0)
            {
                int i;
                for (i = 1; i < transferr.Count - 1; i++)
                {
                    result += transferr[i] + ",";
                }
                if(result!="")
                    result = result.Substring(0, result.Length - 1);
            }
            return result;
        }

        //在listview里面添加货物
        private void btn_addGoods_Click(object sender, EventArgs e)
        {
            if (text_Amount.Text.Trim() != null)
            {
                ListViewItem lvi = new ListViewItem(cb_GoodsName.Text);
                listView2.Items.Add(lvi);
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, text_Amount.Text));
                text_Amount.Clear();
            }
            else
            {
                MessageBox.Show("请输入货物量");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //temp = comboBox1.Text;
            //List<string> ls = new List<string>();
            //DataTable incombox = DBHelper.GetTable(DBHelper.TransReporatoryName());
            //foreach (DataRow dr in incombox.Rows)
            //{
            //    if(!dr.ToString().Equals(temp))
            //    { 
            //    ls.Add(dr["TransReporatory"].ToString());
                
            //    }
            //}
            //comboBox1.DataSource = ls;

        }

        //删除listview里面的数据
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = this.listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem item = this.listView1.SelectedItems[i];
                this.listView1.Items.Remove(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = this.listView2.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem item = this.listView2.SelectedItems[i];
                this.listView2.Items.Remove(item);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
        }

    }
}
