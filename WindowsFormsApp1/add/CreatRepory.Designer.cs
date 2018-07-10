namespace WindowsFormsApp1
{
    partial class CreatRepory
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
            this.btn_creatreporty = new System.Windows.Forms.Button();
            this.text_city = new System.Windows.Forms.TextBox();
            this.text_reportyname = new System.Windows.Forms.TextBox();
            this.text_reportycode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_creatreporty
            // 
            this.btn_creatreporty.Location = new System.Drawing.Point(121, 353);
            this.btn_creatreporty.Margin = new System.Windows.Forms.Padding(2);
            this.btn_creatreporty.Name = "btn_creatreporty";
            this.btn_creatreporty.Size = new System.Drawing.Size(154, 18);
            this.btn_creatreporty.TabIndex = 13;
            this.btn_creatreporty.Text = "创建仓库";
            this.btn_creatreporty.UseVisualStyleBackColor = true;
            this.btn_creatreporty.Click += new System.EventHandler(this.btn_creatreporty_Click);
            // 
            // text_city
            // 
            this.text_city.Location = new System.Drawing.Point(201, 272);
            this.text_city.Margin = new System.Windows.Forms.Padding(2);
            this.text_city.Name = "text_city";
            this.text_city.Size = new System.Drawing.Size(76, 21);
            this.text_city.TabIndex = 12;
            // 
            // text_reportyname
            // 
            this.text_reportyname.Location = new System.Drawing.Point(201, 189);
            this.text_reportyname.Margin = new System.Windows.Forms.Padding(2);
            this.text_reportyname.Name = "text_reportyname";
            this.text_reportyname.Size = new System.Drawing.Size(76, 21);
            this.text_reportyname.TabIndex = 11;
            // 
            // text_reportycode
            // 
            this.text_reportycode.Location = new System.Drawing.Point(201, 105);
            this.text_reportycode.Margin = new System.Windows.Forms.Padding(2);
            this.text_reportycode.Name = "text_reportycode";
            this.text_reportycode.Size = new System.Drawing.Size(76, 21);
            this.text_reportycode.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 274);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "仓库所在城市";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "仓库名字";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "仓库编号";
            // 
            // CreatRepory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 477);
            this.Controls.Add(this.btn_creatreporty);
            this.Controls.Add(this.text_city);
            this.Controls.Add(this.text_reportyname);
            this.Controls.Add(this.text_reportycode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreatRepory";
            this.Text = "创建仓库";
            this.Load += new System.EventHandler(this.CreatRepory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_creatreporty;
        private System.Windows.Forms.TextBox text_city;
        private System.Windows.Forms.TextBox text_reportyname;
        private System.Windows.Forms.TextBox text_reportycode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}