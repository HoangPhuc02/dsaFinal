using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docgia_giaodien
{
    public class Sach
    {
        public int masach;
        public int trangthai;
        public int vitri;
        public Sach next;
        public MuonTra MuonTra;
        public Sach(int masach, int trangthai, int vitri, Sach next)
        {
            this.masach = masach;
            this.trangthai = trangthai;
            this.vitri = vitri;
            this.next = next;
        }
    }
    public class DanhMucSach
    {
        public Sach head;
        public Sach tail;
        public int soluong;
        private static int dem = 1000; // Biến đếm số lượng sách để tự động tạo mã sách
        private HashSet<int> danhSachMaSach = new HashSet<int>(); // Lưu danh sách các mã sách đã được sử dụng
        public DanhMucSach()
        {
            head = null;
            tail = null;
            soluong = 0;
        }
        public IEnumerator<Sach> GetEnumerator()
        {
            Sach sach = head; // khởi tạo node sach là tại node head 
            while (sach != null) // nếu sach chưa chạy hết danh sách
            {
                yield return sach; // trả về đối tượng Sach hiện tại bằng yield return
                sach = sach.next; // chỉ đến đối tượng Sach tiếp theo trong danh sách
            }
        }
        public bool isEmpty()
        {
            return soluong == 0;
        }
        public void ThemSach(Sach sach)
        {
            do
            {
                // Tạo mã sách mới
                dem++;
                if (dem > 9999)
                {
                    Console.WriteLine("Hệ thống đã đạt tới giới hạn số lượng sách.");
                    return;
                }

            } while (danhSachMaSach.Contains(dem)); // Kiểm tra nếu mã sách đã tồn tại thì tạo lại

            Sach newest = new Sach(dem, sach.trangthai, sach.vitri, null);
            danhSachMaSach.Add(dem);

            if (sach.trangthai == 0 || sach.trangthai == 1 || sach.trangthai == 2)
            {
                if (isEmpty())
                    head = newest;
                else
                    tail.next = newest;
                tail = newest;
                soluong++;
            }
            else
            {
                Console.WriteLine("================================");
                Console.WriteLine("Co loi xay ra khi nhap sach co ma :" + newest.masach);
                Console.WriteLine("================================");
            }
        }

        public void display()
        {
            Sach sach = head; // khởi tạo node p là tại node head 
            while (sach != null) // nếu p chưa chạy hết linklist
            {
                Console.WriteLine("         Ma sach :" + sach.masach);
                Console.WriteLine("         Trang thai :" + sach.trangthai);
                Console.WriteLine("         Vi tri :" + sach.vitri);
                Console.WriteLine("================================");
                sach = sach.next; // chỉ đế node tiếp theo trong linklist
            }
        }
        public void ThemSachKhiNapFile(Sach sach)
        {
            Sach newest = new Sach(sach.masach, sach.trangthai, sach.vitri, null);


            if (sach.trangthai == 0 || sach.trangthai == 1 || sach.trangthai == 2)
            {
                if (isEmpty())
                    head = newest;
                else
                    tail.next = newest;
                tail = newest;
                soluong++;
            }
            else
            {
                Console.WriteLine("================================");
                Console.WriteLine("Co loi xay ra khi nhap sach co ma :" + newest.masach);
                Console.WriteLine("================================");
            }
        }
    }
}
