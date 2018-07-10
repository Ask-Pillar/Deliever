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
        public static void DeletComboxData(DataTable dt,string str)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[2].ToString() ==str)
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }
            }
          
        }

        //正则手机号码
        public static bool  regularPhone(string phnumber)
        {
            Regex rx = new Regex(@"^(\d{3,4}-)?\d{6,8}$");
            bool result= rx.IsMatch(phnumber);
            return result;
            
        }
        public static bool regularnumber(string number)
        {
            Regex rx8 = new Regex(@"/^\d{8}$/");
            bool result = rx8.IsMatch(number);
            return result;
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
