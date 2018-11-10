namespace QLHH_CN_HD
{
    partial class Import_File
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNCC = new System.Windows.Forms.ComboBox();
            this.tbpath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbTonghop = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã NCC";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(0, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(630, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Note: Khi lấy dữ liệu file excel thì tên sheet phải mặc định là: Sheet1";
            // 
            // cbNCC
            // 
            this.cbNCC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbNCC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNCC.FormattingEnabled = true;
            this.cbNCC.Location = new System.Drawing.Point(65, 22);
            this.cbNCC.Name = "cbNCC";
            this.cbNCC.Size = new System.Drawing.Size(121, 21);
            this.cbNCC.TabIndex = 2;
            // 
            // tbpath
            // 
            this.tbpath.Location = new System.Drawing.Point(65, 52);
            this.tbpath.Name = "tbpath";
            this.tbpath.Size = new System.Drawing.Size(432, 20);
            this.tbpath.TabIndex = 3;
            this.tbpath.Click += new System.EventHandler(this.tbpath_Click);
            this.tbpath.TextChanged += new System.EventHandler(this.tbpath_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Path";
            // 
            // chbTonghop
            // 
            this.chbTonghop.AutoSize = true;
            this.chbTonghop.Location = new System.Drawing.Point(207, 25);
            this.chbTonghop.Name = "chbTonghop";
            this.chbTonghop.Size = new System.Drawing.Size(106, 17);
            this.chbTonghop.TabIndex = 5;
            this.chbTonghop.Text = "Từ file tổng hợp?";
            this.chbTonghop.UseVisualStyleBackColor = true;
            this.chbTonghop.CheckedChanged += new System.EventHandler(this.chbTonghop_CheckedChanged);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnImport.Location = new System.Drawing.Point(533, 10);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(85, 42);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Lấy Dữ Liệu";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnthoat.Location = new System.Drawing.Point(533, 58);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(85, 42);
            this.btnthoat.TabIndex = 7;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // Import_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(630, 108);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.chbTonghop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbpath);
            this.Controls.Add(this.cbNCC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Import_File";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import_File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNCC;
        private System.Windows.Forms.TextBox tbpath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbTonghop;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnthoat;
    }
}