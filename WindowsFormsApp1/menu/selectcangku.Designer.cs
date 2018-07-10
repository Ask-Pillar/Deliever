using WindowsFormsApp1.dataset;

namespace WindowsFormsApp1
{
    partial class selectcangku
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.transReporatoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delieverDataSet = new WindowsFormsApp1.dataset.DelieverDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.transReporatoryTableAdapter = new WindowsFormsApp1.dataset.DelieverDataSetTableAdapters.TransReporatoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.transReporatoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delieverDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.transReporatoryBindingSource;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // transReporatoryBindingSource
            // 
            this.transReporatoryBindingSource.DataMember = "TransReporatory";
            this.transReporatoryBindingSource.DataSource = this.delieverDataSet;
            // 
            // delieverDataSet
            // 
            this.delieverDataSet.DataSetName = "DelieverDataSet";
            this.delieverDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "选择此仓库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // transReporatoryTableAdapter
            // 
            this.transReporatoryTableAdapter.ClearBeforeFill = true;
            // 
            // selectcangku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 473);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "selectcangku";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transReporatoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delieverDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private DelieverDataSet delieverDataSet;
        private System.Windows.Forms.BindingSource transReporatoryBindingSource;
        private dataset.DelieverDataSetTableAdapters.TransReporatoryTableAdapter transReporatoryTableAdapter;
    }
}