using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Nhapthongtin : Form
    {
        // Danh sách để lưu trữ những người đã bầu
        private static List<string> danhSachMSSV = new List<string>();  // Lưu MSSV đã bầu
        private static Dictionary<string, int> danhSachLop = new Dictionary<string, int>();  // Lưu số người bầu trong mỗi lớp

        public Nhapthongtin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các ô nhập liệu
            string ten = txtTen.Text.Trim();
            string mssv = txtMSSV.Text.Trim();
            string khoa = txtKhoa.Text.Trim();
            string lop = txtLop.Text.Trim();
            string chucVu = txtChucvu.Text.Trim();

            // Kiểm tra các trường có bị trống không
            if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(mssv) ||
                string.IsNullOrWhiteSpace(khoa) || string.IsNullOrWhiteSpace(lop) ||
                string.IsNullOrWhiteSpace(chucVu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nếu MSSV đã được bầu
            if (danhSachMSSV.Contains(mssv))
            {
                MessageBox.Show("MSSV này đã được bầu rồi. Vui lòng chọn MSSV khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nếu lớp đã đủ 2 người bầu
            if (danhSachLop.ContainsKey(lop) && danhSachLop[lop] >= 2)
            {
                MessageBox.Show("Lớp này đã có đủ 2 người bầu. Không thể bầu thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thêm thông tin vào danh sách
            danhSachMSSV.Add(mssv);
            if (danhSachLop.ContainsKey(lop))
            {
                danhSachLop[lop]++;
            }
            else
            {
                danhSachLop[lop] = 1;
            }

            // Chuyển sang Form2 và truyền dữ liệu
            Form2 form2 = new Form2(ten, mssv, khoa, lop, chucVu);
            form2.ShowDialog();
            Application.Exit();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void Nhapthongtin_Load(object sender, EventArgs e)
        {

        }
    }
}