
namespace Docgia_giaodien
{
    partial class Form1
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
            this.btnSapTheoTen = new System.Windows.Forms.Button();
            this.btnSapTheoMaThe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTrangThai = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHieuChinh = new System.Windows.Forms.Button();
            this.txtPhai = new System.Windows.Forms.RichTextBox();
            this.txtTen = new System.Windows.Forms.RichTextBox();
            this.txtMaDG = new System.Windows.Forms.RichTextBox();
            this.txtHo = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DataGrid_DocGia = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_DocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(446, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH SÁCH ĐỘC GIẢ";
            // 
            // btnSapTheoTen
            // 
            this.btnSapTheoTen.Location = new System.Drawing.Point(115, 51);
            this.btnSapTheoTen.Name = "btnSapTheoTen";
            this.btnSapTheoTen.Size = new System.Drawing.Size(95, 47);
            this.btnSapTheoTen.TabIndex = 2;
            this.btnSapTheoTen.Text = "Tên";
            this.btnSapTheoTen.UseVisualStyleBackColor = true;
            this.btnSapTheoTen.Click += new System.EventHandler(this.btnSapTheoTen_Click);
            // 
            // btnSapTheoMaThe
            // 
            this.btnSapTheoMaThe.Location = new System.Drawing.Point(225, 50);
            this.btnSapTheoMaThe.Name = "btnSapTheoMaThe";
            this.btnSapTheoMaThe.Size = new System.Drawing.Size(100, 47);
            this.btnSapTheoMaThe.TabIndex = 3;
            this.btnSapTheoMaThe.Text = "Mã thẻ";
            this.btnSapTheoMaThe.UseVisualStyleBackColor = true;
            this.btnSapTheoMaThe.Click += new System.EventHandler(this.btnSapTheoMaThe_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sắp xếp theo ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.txtTrangThai);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnHieuChinh);
            this.panel1.Controls.Add(this.txtPhai);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.txtMaDG);
            this.panel1.Controls.Add(this.txtHo);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(743, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 399);
            this.panel1.TabIndex = 5;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(153, 256);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(223, 40);
            this.txtTrangThai.TabIndex = 13;
            this.txtTrangThai.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(13, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Trạng Thái[0,1]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(13, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Phái[0,1]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(13, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(13, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Họ và tên đệm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(13, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "MaDG";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(312, 333);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 47);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(174, 333);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 47);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHieuChinh
            // 
            this.btnHieuChinh.Location = new System.Drawing.Point(34, 333);
            this.btnHieuChinh.Name = "btnHieuChinh";
            this.btnHieuChinh.Size = new System.Drawing.Size(95, 47);
            this.btnHieuChinh.TabIndex = 7;
            this.btnHieuChinh.Text = "Hiệu Chỉnh";
            this.btnHieuChinh.UseVisualStyleBackColor = true;
            this.btnHieuChinh.Click += new System.EventHandler(this.btnHieuChinh_Click);
            // 
            // txtPhai
            // 
            this.txtPhai.Location = new System.Drawing.Point(153, 197);
            this.txtPhai.Name = "txtPhai";
            this.txtPhai.Size = new System.Drawing.Size(223, 40);
            this.txtPhai.TabIndex = 4;
            this.txtPhai.Text = "";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(153, 140);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(223, 40);
            this.txtTen.TabIndex = 3;
            this.txtTen.Text = "";
            // 
            // txtMaDG
            // 
            this.txtMaDG.Location = new System.Drawing.Point(153, 32);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.Size = new System.Drawing.Size(223, 40);
            this.txtMaDG.TabIndex = 2;
            this.txtMaDG.Text = "";
            // 
            // txtHo
            // 
            this.txtHo.Location = new System.Drawing.Point(153, 84);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(223, 40);
            this.txtHo.TabIndex = 1;
            this.txtHo.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(740, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hiệu Chỉnh Độc Giả";
            // 
            // DataGrid_DocGia
            // 
            this.DataGrid_DocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_DocGia.Location = new System.Drawing.Point(12, 118);
            this.DataGrid_DocGia.Name = "DataGrid_DocGia";
            this.DataGrid_DocGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid_DocGia.Size = new System.Drawing.Size(550, 559);
            this.DataGrid_DocGia.TabIndex = 7;
            this.DataGrid_DocGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_DocGia_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 689);
            this.Controls.Add(this.DataGrid_DocGia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSapTheoMaThe);
            this.Controls.Add(this.btnSapTheoTen);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_DocGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSapTheoTen;
        private System.Windows.Forms.Button btnSapTheoMaThe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtTrangThai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHieuChinh;
        private System.Windows.Forms.RichTextBox txtPhai;
        private System.Windows.Forms.RichTextBox txtTen;
        private System.Windows.Forms.RichTextBox txtMaDG;
        private System.Windows.Forms.RichTextBox txtHo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DataGrid_DocGia;
    }
}

