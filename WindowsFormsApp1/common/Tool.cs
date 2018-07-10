using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.common
{
    class Tool
    {
        //删除combobox里面的内容
        public static void DeletComboxData(DataTable dt,string str)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[0].ToString() ==str)
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }
            }
          
        }
        //添加combobox里面的内容
        public static void addComboxData(DataTable dt, string str)
        {
                    dt.Rows.Add(str);
        }



        //正则手机号码
        public static bool  regularPhone(TextBox textBox, string Expression)
        {
            bool re = false;
            Regex reg = new Regex(Expression);
            if (textBox.Text == "" || !reg.Match(textBox.Text).Success)
            {
                MessageBox.Show("请输入正确的电话号码");
            }
            else
            {
                re = true;
            }
            return re;
        }
       
        public static bool regularnumber(TextBox textBox, string Expression)
        {
          
            bool re = false;
            Regex reg = new Regex(Expression);
            if (textBox.Text == "" || !reg.Match(textBox.Text).Success)
            {
                MessageBox.Show("请输入8位有效数字");
            }
            else
            {
                re = true;
            }
            return re;
        }

        //获取listview中的索引
        public static int GoodsNumber(ListView list,string goodsname)
        {
            int i=-1;
            foreach (ListViewItem lvi in list.Items)
            {
                if (goodsname == lvi.SubItems[0].Text)
                {
                    i = list.Items.IndexOf(lvi);
                }
            }
            return i;
        }

        //输入格式限制
        public static bool TextBoxExpression(TextBox textBox, string Expression)
        {
            bool re = false;
            Regex reg = new Regex(Expression);
            if (textBox.Text=="" || !reg.Match(textBox.Text).Success)
            {
                MessageBox.Show("请输入正确的输入格式");
            }
            else
            {
                re = true;
            }
            return re;

        }
    }
}
