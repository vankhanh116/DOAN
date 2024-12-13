using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private string ten, mssv, khoa, lop, chucVu;

        public Form2(string ten, string mssv, string khoa, string lop, string chucVu)
        {
            InitializeComponent();

            this.ten = ten;
            this.mssv = mssv;
            this.khoa = khoa;
            this.lop = lop;
            this.chucVu = chucVu;
        }
        public class ThongTinBauCu
        {
            public string? Ten { get; set; }
            public string? MSSV { get; set; }
            public string? Khoa { get; set; }
            public string? Lop { get; set; }
            public string? ChucVu { get; set; }
            public string? PhieuBau1 { get; set; }
            public string? PhieuBau2 { get; set; }
            public string? ThoiGianBauChon { get; set; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bauchon1 = NguyenThuHang.Checked || PhamTheHung.Checked || DoanNgocLong.Checked;
            bool bauchon2 = PhiPhuongAnh.Checked || TrinhTranPhuongTuan.Checked || NguyenThanhTung.Checked;

            if (!bauchon1 || !bauchon2)
            {
                MessageBox.Show("Bạn chưa bỏ phiếu xong!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string phieuBau1 = NguyenThuHang.Checked ? NguyenThuHang.Text :
                                  PhamTheHung.Checked ? PhamTheHung.Text : DoanNgocLong.Text;

            string phieuBau2 = PhiPhuongAnh.Checked ? PhiPhuongAnh.Text :
                                  TrinhTranPhuongTuan.Checked ? TrinhTranPhuongTuan.Text : NguyenThanhTung.Text;

            string thoiGianBauChon = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            ThongTinBauCu thongTin = new ThongTinBauCu
            {
                Ten = this.ten,
                MSSV = this.mssv,
                Khoa = this.khoa,
                Lop = this.lop,
                ChucVu = this.chucVu,
                PhieuBau1 = phieuBau1,
                PhieuBau2 = phieuBau2,
                ThoiGianBauChon = thoiGianBauChon,
            };

            // Đọc dữ liệu cũ từ file JSON, nếu có
            string filePath = "ThongTinBauCu.json";
            List<ThongTinBauCu> danhSachBauCu = new List<ThongTinBauCu>();

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                danhSachBauCu = JsonConvert.DeserializeObject<List<ThongTinBauCu>>(jsonData) ?? new List<ThongTinBauCu>();
            }

            // Thêm đối tượng mới vào danh sách
            danhSachBauCu.Add(thongTin);

            // Chuyển danh sách thành chuỗi JSON
            string json = JsonConvert.SerializeObject(danhSachBauCu, Formatting.Indented);

            // Lưu lại vào file JSON
            File.WriteAllText(filePath, json); // Ghi đè nội dung cũ

            // Thông báo thành công
            MessageBox.Show("Cám ơn bạn đã bỏ phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            // Thoát ứng dụng
            Application.Exit();

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }
    }
}
