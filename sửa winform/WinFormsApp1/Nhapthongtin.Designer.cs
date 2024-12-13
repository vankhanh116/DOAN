namespace WinFormsApp1
{
    partial class Nhapthongtin
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
            button1 = new Button();
            txtTen = new TextBox();
            txtMSSV = new TextBox();
            txtKhoa = new TextBox();
            txtLop = new TextBox();
            txtChucvu = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLight;
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(861, 691);
            button1.Name = "button1";
            button1.Size = new Size(210, 39);
            button1.TabIndex = 0;
            button1.Text = "LƯU THÔNG TIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtTen
            // 
            txtTen.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTen.Location = new Point(275, 7);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(345, 45);
            txtTen.TabIndex = 1;
            // 
            // txtMSSV
            // 
            txtMSSV.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMSSV.Location = new Point(275, 94);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(345, 45);
            txtMSSV.TabIndex = 2;
            // 
            // txtKhoa
            // 
            txtKhoa.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtKhoa.Location = new Point(275, 177);
            txtKhoa.Name = "txtKhoa";
            txtKhoa.Size = new Size(345, 45);
            txtKhoa.TabIndex = 3;
            // 
            // txtLop
            // 
            txtLop.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLop.Location = new Point(275, 248);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(345, 45);
            txtLop.TabIndex = 4;
            // 
            // txtChucvu
            // 
            txtChucvu.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtChucvu.Location = new Point(275, 328);
            txtChucvu.Name = "txtChucvu";
            txtChucvu.Size = new Size(345, 45);
            txtChucvu.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(636, 103);
            label1.Name = "label1";
            label1.Size = new Size(664, 68);
            label1.TabIndex = 6;
            label1.Text = "THÔNG TIN CÁ NHÂN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 10);
            label2.Name = "label2";
            label2.Size = new Size(181, 42);
            label2.TabIndex = 7;
            label2.Text = "Họ và Tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 94);
            label3.Name = "label3";
            label3.Size = new Size(123, 42);
            label3.TabIndex = 8;
            label3.Text = "MSSV";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 175);
            label4.Name = "label4";
            label4.Size = new Size(105, 42);
            label4.TabIndex = 9;
            label4.Text = "Khóa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 255);
            label5.Name = "label5";
            label5.Size = new Size(78, 38);
            label5.TabIndex = 10;
            label5.Text = "Lớp";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(17, 335);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.No;
            label6.Size = new Size(146, 38);
            label6.TabIndex = 11;
            label6.Text = "Chức Vụ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtKhoa);
            panel1.Controls.Add(txtLop);
            panel1.Controls.Add(txtChucvu);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtTen);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtMSSV);
            panel1.Location = new Point(653, 235);
            panel1.Name = "panel1";
            panel1.Size = new Size(1192, 428);
            panel1.TabIndex = 12;
            // 
            // Nhapthongtin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.f3beaf10_ac97_489e_865d_bbdfb87af13b;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1924, 1055);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Nhapthongtin";
            Text = "Nhapthongtin";
            Load += Nhapthongtin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtTen;
        private TextBox txtMSSV;
        private TextBox txtKhoa;
        private TextBox txtLop;
        private TextBox txtChucvu;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel1;
    }
}