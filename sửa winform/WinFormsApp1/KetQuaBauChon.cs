using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using static WinFormsApp1.Form2;

namespace WinFormsApp1
{
    public partial class KetQuaBauChon : Form
    {
        public KetQuaBauChon()
        {
            InitializeComponent();
            LoadDataFromJson();
        }
        private void KetQuaBauChon_Load(object sender, EventArgs e)
        {

        }
        // Đọc dữ liệu từ JSON và hiển thị vào DataGridView
        private void LoadDataFromJson()
        {
            // Đọc dữ liệu từ file JSON
            string filePath = @"F:\CTDL CUỐI KỲ\sửa winform\WinFormsApp1\bin\Debug\net8.0-windows\ThongTinBauCu.json";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File không tồn tại.");
                return;
            }

            var jsonData = File.ReadAllText(filePath);

            // Deserialize dữ liệu JSON thành danh sách các đối tượng ThongTinBauCu
            var votes = JsonConvert.DeserializeObject<List<ThongTinBauCu>>(jsonData);

            // Kiểm tra xem có dữ liệu không
            if (votes == null || votes.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong file JSON.");
                return;
            }

            // Gán dữ liệu vào DataGridView
            dataGridView.DataSource = votes;

            // Cải thiện hiển thị cột
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    // Lớp để biểu diễn thông tin bầu cử
    public class ThongTinBauCu
    {
        public string Ten { get; set; }
        public string MSSV { get; set; }
        public string Khoa { get; set; }
        public string Lop { get; set; }
        public string ChucVu { get; set; }
        public string PhieuBau1 { get; set; }
        public string PhieuBau2 { get; set; }
        public string ThoiGianBauChon { get; set; }
    }
}