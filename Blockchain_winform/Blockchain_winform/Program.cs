using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

public class Block
{
    //Tạo lớp ThongTinBauCu
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

    //Tạo thuộc tính của lớp Block
    public int Index { get; set; }
    public ThongTinBauCu Data { get; set; }
    public string PreviousHash { get; set; }
    public string Hash { get; set; }

    //Tạo lớp Block 
    public Block(int index, ThongTinBauCu data, string previousHash)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data), "ThongTinBauCu cannot be null");

        Index = index;
        Data = data;
        PreviousHash = previousHash;
        Hash = CalculateHash();
    }

    public string CalculateHash()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Kết hợp các thông tin cần tính hash
            string rawData = $"{Index}{Data.Ten}{Data.MSSV}{Data.Khoa}{Data.Lop}{Data.ChucVu}{Data.PhieuBau1}{Data.PhieuBau2}{Data.ThoiGianBauChon}{PreviousHash}";

            // Chuyển rawData thành byte[]
            byte[] bytes = Encoding.UTF8.GetBytes(rawData);

            // Tính toán hash của dữ liệu
            byte[] hashBytes = sha256.ComputeHash(bytes);

            // Chuyển kết quả hash thành chuỗi hex
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }
    }
}

public class BucketHash
{
    private const int SIZE = 10;
    public ArrayList[] data;
    private int currentIndex;

    public BucketHash()
    {
        data = new ArrayList[SIZE];
        for (int i = 0; i < SIZE; i++)
            data[i] = new ArrayList(4);

        currentIndex = 0;  // Bắt đầu từ index 0
    }

    // Hash function
    public int Hash(string s)
    {
        long tot = 0;
        char[] chararray = s.ToCharArray();
        for (int i = 0; i < s.Length; i++)
            tot += 37 * tot + (int)chararray[i];
        tot = tot % data.GetUpperBound(0);
        if (tot < 0)
            tot += data.GetUpperBound(0);
        return (int)tot;
    }

    // Insert 1 block 
    public void Insert(Block.ThongTinBauCu data)
    {
        string previousHash = GetLastBlockHash();
        Block newBlock = new Block(currentIndex++, data, previousHash);

        int hash_value = Hash(newBlock.Hash);

        if (!this.data[hash_value].Contains(newBlock))
            this.data[hash_value].Add(newBlock);
    }

    // Get 1 block từ hashtable bằng hash 
    public Block GetBlockByHash(string blockHash)
    {
        if (string.IsNullOrEmpty(blockHash))
            throw new ArgumentException("Hash cannot be null or empty.", nameof(blockHash));

        // Xác định bucket chứa hash
        int hash_value = Hash(blockHash);

        // Duyệt qua bucket tương ứng
        foreach (Block block in data[hash_value])
        {
            if (block.Hash == blockHash)
                return block;
        }
        return null; // Không tìm thấy
    }

    // Tải dữ liệu từ file JSON vào lưu chúng vào Hashtable 
    public void LoadBlocksFromJson(string filePath)
    {
        // Đọc nội dung từ file JSON
        string jsonData = File.ReadAllText(filePath);

        // Deserialize dữ liệu JSON thành danh sách các ThongTinBauCu
        var votes = JsonConvert.DeserializeObject<List<Block.ThongTinBauCu>>(jsonData);

        if (votes == null || votes.Count == 0)
        {
            Console.WriteLine("No data found in JSON.");
            return;
        }

        foreach (var vote in votes)
        {
            Insert(vote);  // Thêm các thông tin bầu cử vào blockchain
        }
    }

    // Hàm này sẽ trả về hash của block cuối cùng trong blockchain
    public string GetLastBlockHash()
    {
        foreach (var bucket in data)
        {
            if (bucket.Count > 0)
            {
                Block lastBlock = (Block)bucket[bucket.Count - 1];
                return lastBlock.Hash;
            }
        }
        return "0";  // Block đầu tiên sẽ có PreviousHash là "0"
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        try
        {
            // Khởi tạo Hashtable cho blockchain
            BucketHash blockchain = new BucketHash();

            // Đọc và thêm các block từ file JSON vào hashtable
            string filePath = @"F:\\CTDL CUỐI KỲ\\sửa winform\\WinFormsApp1\\bin\\Debug\\net8.0-windows\\ThongTinBauCu.json";  // Đường dẫn đến file JSON
            blockchain.LoadBlocksFromJson(filePath);

            // Hiển thị các block đã được thêm vào blockchain
            Console.WriteLine("Các block đã được thêm vào blockchain:");
            for (int i = 0; i < 10; i++) // Kiểm tra các bucket (có thể điều chỉnh tùy theo nhu cầu)
            {
                Console.WriteLine($"Bucket {i}:");
                foreach (Block block in blockchain.data[i])
                {
                    Console.WriteLine($"Block {block.Index}: ");
                    Console.WriteLine($"                   - {block.Data.PhieuBau1}");
                    Console.WriteLine($"                   - {block.Data.PhieuBau2}");
                    Console.WriteLine($"                   - Hash: {block.Hash}");
                    Console.WriteLine($"                   - Previous Hash: {block.PreviousHash}");
                }
            }

            // Hỏi người dùng có muốn truy xuất block theo hash không
            Console.Write("Bạn có muốn tìm block theo hash không? (y/n): ");
            string choice = Console.ReadLine()?.ToLower();

            if (choice == "y")
            {
                Console.Write("Nhập Hash cần truy xuất: ");
                string searchHash = Console.ReadLine();

                Block foundBlock = blockchain.GetBlockByHash(searchHash);

                if (foundBlock != null)
                {
                    Console.WriteLine($"Tìm thấy block {foundBlock.Index}:");
                    Console.WriteLine($"  Tên: {foundBlock.Data.Ten}");
                    Console.WriteLine($"  MSSV: {foundBlock.Data.MSSV}");
                    Console.WriteLine($"  Khoa: {foundBlock.Data.Khoa}");
                    Console.WriteLine($"  Lớp: {foundBlock.Data.Lop}");
                    Console.WriteLine($"  Chức vụ: {foundBlock.Data.ChucVu}");
                    Console.WriteLine($"  Hash: {foundBlock.Hash}");
                    Console.WriteLine($"  Previous Hash: {foundBlock.PreviousHash}");
                }
                else
                {
                    Console.WriteLine("Không tìm thấy block nào với Hash đã nhập.");
                    Console.WriteLine("Danh sách các hash hiện có:");
                    foreach (var bucket in blockchain.data)
                    {
                        foreach (Block block in bucket)
                        {
                            Console.WriteLine($"  - Block {block.Index}: {block.Hash}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
