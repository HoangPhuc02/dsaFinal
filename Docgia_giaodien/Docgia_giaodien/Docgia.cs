using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Docgia_giaodien
{

    public class DocGia
    {
        public int MaDG { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string Phai { get; set; }
        public int TrangThaiThe { get; set; }
       
        public List<Sach> SachMuon;
        public static List<MuonTra> SachDangMuon;
        public DocGia Left;
        public DocGia Right;
        public DocGia()
        {
            SachMuon = new List<Sach>();
            SachDangMuon = new List<MuonTra>();
        }
        public override string ToString()
        {
            return MaDG + ";" + Ho + ";" + Ten + ";" + Phai + ";" + TrangThaiThe;
        }
        public IEnumerator<Sach> GetEnumerator()
        {
            return SachMuon.GetEnumerator();
        }
    }

    public class ReaderFunc
    {
        public static List<DocGia> ListDocGia = new List<DocGia>();
        public static DocGia root;
        public static string message;
        public ReaderFunc()
        {
            root = null;
        }

        public static void AddReader(DocGia reader)
        {
            if (root == null)
            {
                root = reader;
                return;
            }

            DocGia current = root;
            while (current != null)
            {
                if (reader.MaDG < current.MaDG)
                {
                    if (current.Left == null)
                    {
                        current.Left = reader;
                        return;
                    }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = reader;
                        return;
                    }
                    current = current.Right;
                }
            }
        }

        public static DocGia GetReaderByMaDG(int madg)
        {
            DocGia current = root;
            while (current != null)
            {
                if (madg < current.MaDG)
                {
                    current = current.Left;
                }
                else if (madg > current.MaDG)
                {
                    current = current.Right;
                }
                else
                {
                    return current;
                }
            }
            return null;
        }

        public static DocGia NhapThongTinDocGia()
        {
            DocGia reader = new DocGia();

            Console.Write("Nhap ho: ");
            reader.Ho = Console.ReadLine();

            Console.Write("Nhap ten: ");
            reader.Ten = Console.ReadLine();

            Console.Write("Nhap phai (Nam/Nu): ");
            reader.Phai = Console.ReadLine();

            reader.MaDG = GetMaDG();

            reader.TrangThaiThe = 1;
            reader.SachMuon = new List<Sach>();


            return reader;
        }

        public static int GetMaDG()
        {
            Random rand = new Random();
            int madg;
            do
            {
                madg = rand.Next(10000, 99999);
            } while (GetReaderByMaDG(madg) != null);
            return madg;
        }
        public static void XoaTatCaDocGia()
        {
            root = XoaTatCaNode(root);
        }

        private static DocGia XoaTatCaNode(DocGia node)
        {
            if (node == null)
            {
                return null;
            }
            node.Left = XoaTatCaNode(node.Left);
            node.Right = XoaTatCaNode(node.Right);
            node = null;
            return node;
        }
        public static void HienThiThongTinDocGia(DocGia reader)
        {
            Console.WriteLine("Thong tin doc gia:");
            Console.WriteLine();
            Console.WriteLine("---------Ma doc gia: {0}", reader.MaDG);
            Console.WriteLine("---------Ho ten: {0} {1}", reader.Ho, reader.Ten);
            Console.WriteLine("---------Phai: {0}", reader.Phai);
            Console.WriteLine("---------Trang thai the: {0}", reader.TrangThaiThe);
            Console.WriteLine("---------Danh sach sach muon: ");
            if (reader.SachMuon != null)
            {
                foreach (Sach book in reader.SachMuon)
                {
                    Console.WriteLine("- {0}", book.masach);
                }
            }
            else Console.WriteLine(" Doc gia chua muon sach ");

        }

        public static void XoaDocGia(int madg)
        {
            DocGia parent = null;
            DocGia current = root;
            

            while (current != null)
            {
                if (madg < current.MaDG)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (madg > current.MaDG)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    if (current.SachMuon.Count > 0)
                    {
                        message = "Khong the xoa doc gia vi doc gia dang muon sach";
                        return;
                    }

                    if (parent == null)
                    {
                        root = DeleteNode(current);
                    }
                    else if (madg < parent.MaDG)
                    {
                        parent.Left = DeleteNode(current);
                    }
                    else
                    {
                        parent.Right = DeleteNode(current);
                    }

                    message="Da xoa doc gia co ma la: "+ madg ;
                    return;
                }
            }

            message="Khong tim thay doc gia co ma la :"+ madg;
        }

        private static DocGia DeleteNode(DocGia node)
        {
            if (node.Left == null && node.Right == null)
            {
                return null;
            }
            else if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }
            else
            {
                DocGia successor = GetSuccessor(node);
                successor.Left = node.Left;
                return successor;
            }
        }

        private static DocGia GetSuccessor(DocGia node)
        {
            DocGia parent = node;
            DocGia current = node.Right;

            while (current.Left != null)
            {
                parent = current;
                current = current.Left;
            }

            parent.Left = current.Right;
            current.Right = node.Right;

            return current;
        }
        public static void HienThiDanhSachDocGia()
        {
            if (root == null)
            {
                Console.WriteLine("Danh sach doc gia rong.");
                return;
            }

            Console.WriteLine("Danh sach doc gia:");
            InOrder(root);
        }

        private static void InOrder(DocGia node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                HienThiThongTinDocGia(node);
                InOrder(node.Right);
            }
        }

        private static void DuyetCay(DocGia node, List<DocGia> danhSachTam)
        {
            if (node == null) return;

            DuyetCay(node.Left, danhSachTam);
            danhSachTam.Add(node);
            DuyetCay(node.Right, danhSachTam);
        }
        public static List<DocGia> InDanhSachDocGiaTheoTen()
        {
            List<DocGia> danhSachDocGia = new List<DocGia>();
            DuyetCay(root, danhSachDocGia);
            danhSachDocGia.Sort((x, y) => string.Compare(x.Ho + x.Ten, y.Ho + y.Ten));
            return danhSachDocGia;
        }

        public static List<DocGia> InDanhSachDocGiaTheoMa()
        {
            List<DocGia> danhSachDocGia = new List<DocGia>();
            DuyetCay(root, danhSachDocGia);
            danhSachDocGia.Sort((x, y) => x.MaDG.CompareTo(y.MaDG));
            return danhSachDocGia ; 
        }
        public static void MuonSach(int maDG, int maSach)
        {
            // Tìm độc giả theo mã độc giả
            DocGia reader = GetReaderByMaDG(maDG);
            if (reader == null)
            {
                Console.WriteLine("Khong tim thay doc gia");
                return;
            }

            // Kiểm tra trạng thái thẻ thư viện của độc giả
            if (reader.TrangThaiThe != 1)
            {
                Console.WriteLine("Doc gia khong co the muon sach");
                return;
            }
            else
            {   // Tìm sách theo mã sách
                Sach book = BookFunc.SearchMaSach(maSach);
                // Kiểm tra nếu độc giả đã mượn đủ số lượng sách tối đa thì báo lỗi.
                if (reader.SachMuon.Count >= 3)
                {
                    throw new Exception("Độc giả đã mượn đủ số lượng sách tối đa.");
                }
                // Kiểm tra nếu sách đã được mượn bởi độc giả khác thì báo lỗi.
                if (book.trangthai == 1)
                {
                    throw new Exception("Sách đã được mượn bởi độc giả khác.");
                }


                if (book == null)
                {
                    Console.WriteLine("Khong tim thay sach");
                    return;
                }
                else
                {
                    // Kiểm tra số lượng sách còn lại trong thư viện
                    if (book == null)
                    {
                        Console.WriteLine("Khong du sach de muon");
                        return;
                    }

                    // Kiểm tra xem độc giả đã mượn quá số lượng sách tối đa được mượn chưa
                    if (reader.SachMuon.Count >= 3)
                    {
                        Console.WriteLine("Doc gia da muon toi da so luong sach cho phep");
                        return;
                    }

                    // Thêm sách vào danh sách sách mượn của độc giả
                    reader.SachMuon.Add(book);
                    // cập nhật trạng thái sách
                    book.trangthai = 1;
                    Console.WriteLine("Muon Sach thanh cong");
                    // Thêm thông tin vào danh sách mượn trả.
                    MuonTra muonTra = new MuonTra(book.masach, DateTime.Now);
                    book.MuonTra = muonTra;
                    DocGia.SachDangMuon.Add(muonTra);
                }

            }

        }



        public static void CapNhatDocGia()
        {
            Console.WriteLine("Nhap ma doc gia can cap nhat:");
            int maDG = int.Parse(Console.ReadLine());

            DocGia reader = GetReaderByMaDG(maDG);

            if (reader == null)
            {
                Console.WriteLine("Khong tim thay doc gia");
                return;
            }

            HienThiThongTinDocGia(reader);

            Console.WriteLine("Nhap thong tin moi:");
            Console.Write("Nhap ho: ");
            reader.Ho = Console.ReadLine();
            Console.Write("Nhap ten: ");
            reader.Ten = Console.ReadLine();
            Console.Write("Nhap gioi tinh: ");
            reader.Phai = Console.ReadLine();
            Console.Write("Nhap trang thai the (1 - Dang hoat dong, 0 - Bi khoa): ");
            reader.TrangThaiThe = int.Parse(Console.ReadLine());

            Console.WriteLine("Cap nhat doc gia thanh cong");
        }

        public static void DocFile()
        {
            string path = "..\\data_docgia.txt";
            DocGia dsdg = new DocGia();
            try
            {
                StreamReader sr = new StreamReader(path);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] arr = line.Split(';');
                    if (arr.Length == 5)
                    {
                        DocGia dg = new DocGia();
                        dg.MaDG = int.Parse(arr[0].Trim());
                        dg.Ho = arr[1].Trim();
                        dg.Ten = arr[2].Trim();
                        dg.Phai = arr[3].Trim();
                        dg.TrangThaiThe = int.Parse(arr[4].Trim());
                        ReaderFunc.AddReader(dg);
                        ListDocGia.Add(dg);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void LuuDanhSachDocGiaVaoFile()
        {
            using (StreamWriter writer = new StreamWriter("..\\data_docgia.txt"))
            {
                List<DocGia> danhSachDocGia = InDanhSachDocGiaTheoMa();
                foreach (DocGia docGia in danhSachDocGia)
                {
                    string line = docGia.MaDG + ";" + docGia.Ho + ";" + docGia.Ten + ";" + docGia.Phai + ";" + docGia.TrangThaiThe;
                    writer.WriteLine(line);
                }
            }
            
        }
        public static void ThemDocGiaVaoFile(string path, DocGia dg)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, true);

                sw.WriteLine("{0};{1};{2};{3};{4}", dg.MaDG, dg.Ho, dg.Ten, dg.Phai, dg.TrangThaiThe);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
