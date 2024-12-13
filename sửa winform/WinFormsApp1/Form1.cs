namespace WinFormsApp1
{
    public partial class form1 : Form
    {
        // Danh sách email được phép chuyển qua Form3
        private readonly List<string> allowedEmails = new List<string>
        {
            "linhdan@ueh.edu.vn",
            "minhtam@ueh.edu.vn",
            "vankhanh@ueh.edu.vn"
        };
        public form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // Kiểm tra xem email và password có bỏ trống không
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Bạn chưa nhập xong!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            // Kiểm tra email
            if (allowedEmails.Contains(email))
            {
                // Mở KetQuaBauChon nếu email hợp lệ
                KetQuaBauChon ketQuaBauChon = new KetQuaBauChon();
                ketQuaBauChon.ShowDialog();
            }
            else
            {
                // Mở Nhapthongtin nếu email không hợp lệ
                Nhapthongtin nhapthongtin = new Nhapthongtin();
                nhapthongtin.ShowDialog();
            }

            // Đóng form hiện tại sau khi chuyển
            this.Close();
        }

        private void form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
