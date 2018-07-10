using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WindowsFormsApp1.common;
using WindowsFormsApp1.linq;

namespace WindowsFormsApp1
{
    public partial class empoly : Form
    {
        public empoly()
        {
            InitializeComponent();
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            linqtosqlDataClasses1DataContext linq = new linqtosqlDataClasses1DataContext();
            Employee employee = new Employee();
            employee.EmployeeNumber = textBox5.Text;
            employee.EmployeeRole = 1;
            employee.EmployeeName = textBox3.Text;
            employee.EmployeeStatus = 1;
            employee.EmployeePhone = textBox1.Text;
            DataTable code = DBHelper.GetTable(DBHelper.employeeNumber(textBox5.Text));
            bool s = Tool.regularPhone(textBox1, @"^1([358][0-9]|4[579]|66|7[0135678]|9[89])[0-9]{8}$");
            bool t = Tool.regularnumber(textBox5, @"/^\d{8}$/");
            if (Tool.TextBoxExpression(textBox3, @"^\d+$") && Tool.TextBoxExpression(textBox1, @"^\d+$") && Tool.TextBoxExpression(textBox5, @"^\d+$") && s &&t)
            {
                linq.Employee.InsertOnSubmit(employee);
                linq.SubmitChanges();
                MessageBox.Show(textBox3.Text+"数据添加成功");
                textBox3.Clear();
                textBox1.Clear();
                textBox5.Clear();
            }
         

        }
    }
}
