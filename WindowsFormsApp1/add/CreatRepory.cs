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
    public partial class CreatRepory : Form
    {
        public CreatRepory()
        {
            InitializeComponent();
        }

        private void btn_creatreporty_Click(object sender, EventArgs e)
        {
            try
            {
                linqtosqlDataClasses1DataContext linq;
                linq = new linqtosqlDataClasses1DataContext(SysConfig.constring);
                TransReporatory transreporatory = new TransReporatory();
                RealReportary realreportary = new RealReportary();
                transreporatory.TransReporatoryCode = text_reportycode.Text;
                transreporatory.TransReporatoryName = text_reportyname.Text;
                transreporatory.TransReporatoryCity = text_city.Text;
                realreportary.RealReportaryCode = text_reportycode.Text;
                realreportary.RealReportaryName = text_reportyname.Text;
                realreportary.RealReportaryCity = text_city.Text;
                int renum = Convert.ToInt32(DBHelper.GetTable(DBHelper.retan(text_reportyname.Text)).Rows[0][0].ToString());
                int num = Convert.ToInt32(DBHelper.GetTable(DBHelper.tan(text_reportyname.Text)).Rows[0][0].ToString());
                if (Tool.TextBoxExpression1(text_reportycode) &&Tool.TextBoxExpression1(text_reportyname) &&Tool.TextBoxExpression1(text_city)&&renum==0&&num==0)
                {
                    linq.TransReporatory.InsertOnSubmit(transreporatory);
                    linq.RealReportary.InsertOnSubmit(realreportary);
                    linq.SubmitChanges();
                    MessageBox.Show("数据添加成功");
                    text_reportycode.Clear();
                    text_reportyname.Clear();
                    text_city.Clear();
                }
            }
            catch (Exception )
            {
               MessageBox.Show("添加失败");
            }
        }

        private void CreatRepory_Load(object sender, EventArgs e)
        {

        }
    }
}
