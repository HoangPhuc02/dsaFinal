using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Docgia_giaodien
{
    public class DauSach
    {
        public string ISBN;
        public string TenSach;
        public int SoTrang;
        public string TacGia;
        public int NamXB;
        public string TheLoai;
        public int soluong;
        public DauSach NextBook;
        public DanhMucSach SachTrongThuVien = new DanhMucSach();
        public List<MuonTra> DanhSachMuonTra = new List<MuonTra>();

    }

    public class BookFunc
    {
        public static DauSach[] books;
        public static List<DauSach> ListDauSach = new List<DauSach>();
        public int soluong;
        public BookFunc(int size)
        {
            books = new DauSach[size];
        }
        public IEnumerator<DauSach> GetEnumerator()
        {
            return ListDauSach.GetEnumerator();
        }

        public void AddBook(DauSach book)
        {
            int index = GetIndexForNewBook(book);
            books[index] = book;
        }

        public DauSach GetBookByISBN(string isbn)
        {
            foreach (DauSach book in books)
            {
                if (book != null && book.ISBN == isbn)
                {
                    return book;
                }
            }
            return null;
        }
        public void SortByISBN()
        {
            int n = books.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(books[j].ISBN, books[j + 1].ISBN) > 0)
                    {
                        DauSach temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }
        }
        private int GetIndexForNewBook(DauSach book)
        {
            int index = 0;
            while (books[index] != null)
            {
                index++;
            }
            book.NextBook = books[index];
            return index;
        }
        private string GetISBN(string TenSach)
        {
            string[] words = TenSach.Split(' ');
            StringBuilder isbn = new StringBuilder();
            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    isbn.Append(char.ToUpper(word[0]));
                }
            }
            return isbn.ToString();
        }
        public DauSach NhapThongTinSach(string tensach, int sotrang, string tacgia, int namxb, string theloai)
        {
            DauSach book = new DauSach();
            book.TenSach = tensach;
            book.SoTrang = sotrang;
            book.TacGia = tacgia;
            book.NamXB = namxb;
            book.TheLoai = theloai;

            book.ISBN = GetISBN(book.TenSach);
            return book;
        }
        public void HienThiThongTinSach(DauSach book)
        {
            Console.WriteLine("Thong tin sach:");
            Console.WriteLine("ISBN: {0}", book.ISBN);
            Console.WriteLine("Ten sach: {0}", book.TenSach);
            Console.WriteLine("So trang: {0}", book.SoTrang);
            Console.WriteLine("Tac gia: {0}", book.TacGia);
            Console.WriteLine("Nam xuat ban: {0}", book.NamXB);
            Console.WriteLine("The loai: {0}", book.TheLoai);
            Console.WriteLine("Sach co trong thu vien :");
            Console.WriteLine("================================");
            book.SachTrongThuVien.display();
            Console.WriteLine("");
        }
        public static void HienThiThongTinSachKhiTimMaSach(DauSach book, int masach)
        {
            Console.WriteLine("Thong tin sach:");
            Console.WriteLine("ISBN: {0}", book.ISBN);
            Console.WriteLine("Ten sach: {0}", book.TenSach);
            Console.WriteLine("So trang: {0}", book.SoTrang);
            Console.WriteLine("Tac gia: {0}", book.TacGia);
            Console.WriteLine("Nam xuat ban: {0}", book.NamXB);
            Console.WriteLine("The loai: {0}", book.TheLoai);
            foreach (Sach sach in book.SachTrongThuVien)
            {
                if (sach.masach == masach)
                {
                    Console.WriteLine("Trang thai sach: {0}", sach.trangthai);
                    Console.WriteLine("Vi tri sach: {0}", sach.vitri);
                    break;
                }
            }
            Console.WriteLine("");
        }
        public void LuuDanhSachSachVaoFile()
        {
            using (StreamWriter writer = new StreamWriter("danh-sach-sach.txt"))
            {
                foreach (DauSach book in books)
                {
                    if (book != null)
                    {
                        writer.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}", book.ISBN, book.TenSach, book.SoTrang, book.TacGia, book.NamXB, book.TheLoai);
                    }
                }
            }
            Console.WriteLine("Da luu danh sach sach vao file danh-sach-sach.txt");
        }
        public void DocFileSach(string path)
        {

            string filePath = path; // đường dẫn đến tập tin text

            StreamReader reader = new StreamReader(filePath); // khởi tạo đối tượng StreamReader để đọc tập tin

            while (!reader.EndOfStream) // đọc tới hết tập tin
            {

                string line = reader.ReadLine(); // đọc từng dòng trong tập tin

                string[] splitLine = line.Split('|'); // tách thông tin trong dòng ra theo ký tự '|'

                // nếu đây là thông tin về một đầu sách
                if (splitLine[0] == "DAUSACH")
                {
                    string maDauSach = (splitLine[1]);
                    string tenDauSach = splitLine[2];
                    string tacGia = splitLine[3];
                    int sotrang = int.Parse(splitLine[6]);
                    int namXuatBan = int.Parse(splitLine[4]);
                    string theloai = splitLine[5];
                    int soLuong = int.Parse(splitLine[7]);

                    DauSach dauSach = new DauSach(); // tạo đối tượng DauSach
                    dauSach.ISBN = maDauSach;
                    dauSach.TenSach = tenDauSach;
                    dauSach.TacGia = tacGia;
                    dauSach.NamXB = namXuatBan;
                    dauSach.TheLoai = theloai;
                    dauSach.soluong = soluong;
                    dauSach.SoTrang = sotrang;

                    // đọc danh sách sách của đầu sách này
                    for (int i = 0; i < soLuong; i++)
                    {
                        line = reader.ReadLine();
                        splitLine = line.Split('|');

                        int maSach = int.Parse(splitLine[0]);
                        int trangThai = int.Parse(splitLine[1]);
                        int viTri = int.Parse(splitLine[2]);

                        Sach sach = new Sach(maSach, trangThai, viTri, null); // tạo đối tượng Sach

                        dauSach.SachTrongThuVien.ThemSachKhiNapFile(sach); // thêm sách vào danh sách sách của đầu sách
                    }

                    ListDauSach.Add(dauSach); // thêm đầu sách vào danh sách các đầu sách trong thư viện
                }
            }
            reader.Close(); // đóng
        }
        public void Transfer(BookFunc list)
        {
            foreach (DauSach dausach in ListDauSach)
            {
                list.AddBook(dausach);
            }
        }
        public DauSach FindBookByISBN(string isbn)
        {
            BookFunc bookFunc = new BookFunc(100); // Tạo đối tượng BookFunc với kích thước 100

            try
            {
                using (StreamReader reader = new StreamReader("danh-sach-sach.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split('|');
                        DauSach book = new DauSach();
                        book.ISBN = fields[0];
                        book.TenSach = fields[1];
                        book.SoTrang = int.Parse(fields[2]);
                        book.TacGia = fields[3];
                        book.NamXB = int.Parse(fields[4]);
                        book.TheLoai = fields[5];

                        bookFunc.AddBook(book); // Thêm sách vào danh sách
                    }
                }

                bookFunc.SortByISBN(); // Sắp xếp sách theo ISBN để tìm kiếm

                return bookFunc.GetBookByISBN(isbn); // Tìm sách theo ISBN
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi doc file: " + ex.Message);
                return null;
            }
        }
        public static Sach SearchMaSach(int masach)
        {
            bool found = false;
            foreach (DauSach dausach in ListDauSach)
            {
                if (found == true) break;
                foreach (Sach sach in dausach.SachTrongThuVien)
                {

                    if (sach.masach == masach)
                    {
                        found = true;
                        Console.WriteLine("Tìm kiếm thông tin có mã sách là: " + masach);
                        HienThiThongTinSachKhiTimMaSach(dausach, masach);
                        return sach;

                    }
                }
            }
            if (found == false) Console.WriteLine("Khong tim thay ma sach");
            return null;
        }
        public void ChinhSuaSach(string path, string ISBN, Sach sach)
        {
            try
            {
                List<string> lines = File.ReadAllLines(path).ToList();
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] line = lines[i].Split('|');
                    if (line[0] == "DAUSACH" && line[1] == ISBN)
                    {
                        int soluong = int.Parse(line[7]);
                        soluong++;
                        line[7] = soluong.ToString();
                        string newLine = string.Join("|", line);
                        lines.Insert(i + 1, sach.masach.ToString() + "|" + sach.trangthai.ToString() + "|" + sach.vitri.ToString());
                        lines[i] = newLine;
                        break;
                    }
                }
                File.WriteAllLines(path, lines);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
