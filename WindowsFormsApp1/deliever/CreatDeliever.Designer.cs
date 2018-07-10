namespace WindowsFormsApp1
{
    partial class CreatDeliever
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.text_Amount = new System.Windows.Forms.TextBox();
            this.cb_GoodsName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.gb_address = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_addstation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_addGoods = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_creatDliver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.gb_address.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // text_Amount
            // 
            this.text_Amount.Location = new System.Drawing.Point(288, 58);
            this.text_Amount.Name = "text_Amount";
            this.text_Amount.Size = new System.Drawing.Size(92, 25);
            this.text_Amount.TabIndex = 16;
            // 
            // cb_GoodsName
            // 
            this.cb_GoodsName.DisplayMember = "GoodsID";
            this.cb_GoodsName.FormattingEnabled = true;
            this.cb_GoodsName.Location = new System.Drawing.Point(76, 61);
            this.cb_GoodsName.Name = "cb_GoodsName";
            this.cb_GoodsName.Size = new System.Drawing.Size(130, 23);
            this.cb_GoodsName.TabIndex = 14;
            this.cb_GoodsName.ValueMember = "GoodsID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "货物名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "建单人";
            // 
            // gb_address
            // 
            this.gb_address.Controls.Add(this.button2);
            this.gb_address.Controls.Add(this.button1);
            this.gb_address.Controls.Add(this.label8);
            this.gb_address.Controls.Add(this.listView1);
            this.gb_address.Controls.Add(this.label1);
            this.gb_address.Controls.Add(this.comboBox1);
            this.gb_address.Controls.Add(this.label2);
            this.gb_address.Controls.Add(this.btn_addstation);
            this.gb_address.Location = new System.Drawing.Point(12, 12);
            this.gb_address.Name = "gb_address";
            this.gb_address.Size = new System.Drawing.Size(554, 304);
            this.gb_address.TabIndex = 19;
            this.gb_address.TabStop = false;
            this.gb_address.Text = "地址选择";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(416, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 44);
            this.button2.TabIndex = 18;
            this.button2.Text = "全部删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 48);
            this.button1.TabIndex = 17;
            this.button1.Text = "删除选中站";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "label8";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(25, 83);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(384, 215);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "仓库显示";
            this.columnHeader1.Width = 380;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "选择仓库";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(330, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 23);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_addstation
            // 
            this.btn_addstation.Location = new System.Drawing.Point(416, 83);
            this.btn_addstation.Name = "btn_addstation";
            this.btn_addstation.Size = new System.Drawing.Size(74, 94);
            this.btn_addstation.TabIndex = 6;
            this.btn_addstation.Text = "添加途径站";
            this.btn_addstation.UseVisualStyleBackColor = true;
            this.btn_addstation.Click += new System.EventHandler(this.btn_addstation_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btn_addGoods);
            this.groupBox1.Controls.Add(this.listView2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb_GoodsName);
            this.groupBox1.Controls.Add(this.text_Amount);
            this.groupBox1.Location = new System.Drawing.Point(13, 403);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 275);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加货物";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(472, 187);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 44);
            this.button4.TabIndex = 25;
            this.button4.Text = "全部删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(472, 103);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 48);
            this.button3.TabIndex = 19;
            this.button3.Text = "删除选中货物";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_addGoods
            // 
            this.btn_addGoods.Location = new System.Drawing.Point(386, 45);
            this.btn_addGoods.Name = "btn_addGoods";
            this.btn_addGoods.Size = new System.Drawing.Size(81, 39);
            this.btn_addGoods.TabIndex = 16;
            this.btn_addGoods.Text = "添加货物";
            this.btn_addGoods.UseVisualStyleBackColor = true;
            this.btn_addGoods.Click += new System.EventHandler(this.btn_addGoods_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(24, 103);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(424, 151);
            this.listView2.TabIndex = 24;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "货物名称";
            this.columnHeader2.Width = 149;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "数量";
            // 
            // btn_creatDliver
            // 
            this.btn_creatDliver.Location = new System.Drawing.Point(6, 684);
            this.btn_creatDliver.Name = "btn_creatDliver";
            this.btn_creatDliver.Size = new System.Drawing.Size(560, 39);
            this.btn_creatDliver.TabIndex = 25;
            this.btn_creatDliver.Text = "创建大运单";
            this.btn_creatDliver.UseVisualStyleBackColor = true;
            this.btn_creatDliver.Click += new System.EventHandler(this.btn_creatDliver_Click);
            // 
            // CreatDeliever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 726);
            this.Controls.Add(this.btn_creatDliver);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_address);
            this.Name = "CreatDeliever";
            this.Text = "CreatDeliever";
            this.Load += new System.EventHandler(this.CreatDeliever_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.gb_address.ResumeLayout(false);
            this.gb_address.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox text_Amount;
        private System.Windows.Forms.ComboBox cb_GoodsName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_address;
        private System.Windows.Forms.Button btn_addstation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.Button btn_creatDliver;
        private System.Windows.Forms.Button btn_addGoods;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}