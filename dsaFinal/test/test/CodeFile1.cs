using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    public class HanhKhach
    {
        public string Ten;
        public string CMND;
    }
    public class MayBay
    {
        private const int MAX_SHMB = 15;
        private const int MAX_LMB = 40;
        private const int MAX_SOCHO = 20;
        public string SoHieuMB;
        public string LoaiMB { get; set; }
        public int SoCho { get; set; }
        public int SoChuyenBay { get; set; }

        public MayBay(string shmb, string lmb, int socho)
        {
            SoHieuMB = shmb.Substring(0, Math.Min(shmb.Length, MAX_SHMB));
            LoaiMB = lmb.Substring(0, Math.Min(lmb.Length, MAX_LMB));
            SoCho = Math.Min(socho, MAX_SOCHO);
        }
    }

    public class DanhSachMayBay
    {
        private const int MAX_MAYBAY = 300;
        public MayBay[] dsMayBay = new MayBay[MAX_MAYBAY];
        public int soLuong = 0;

        public int ThemMayBay(MayBay mb)
        {
            if (soLuong >= MAX_MAYBAY)
            {
                return -1; // nếu quá tải thì báo lỗi
            }
            dsMayBay[soLuong] = mb;
            soLuong++;
            return soLuong; // nếu còn chỗ thì thêm chuyến bay
        }

        public void XoaMayBay(int viTri)
        {
            for (int i = viTri; i < soLuong - 1; i++)
            {
                dsMayBay[i] = dsMayBay[i + 1];
            }
            soLuong--;
        }

        public int TimMayBay(string soHieuMB)
        {
            for (int i = 0; i < soLuong; i++)
            {
                if (dsMayBay[i].SoHieuMB == soHieuMB)
                {
                    return i;
                }
            }
            return -1;
        }

        public void HieuChinh(int viTri, MayBay mb)
        {
            dsMayBay[viTri] = mb;
        }
  

        public void InDanhSach()
        {
            
            for(int i = 0; i < soLuong; i++)
            {
                Console.WriteLine("May bay thu " + (i+1).ToString() + ": " + dsMayBay[i].SoHieuMB + " " + dsMayBay[i].LoaiMB + " " + dsMayBay[i].SoCho.ToString());
            }    
        }
    }
    public class ChuyenBay
    {
        public string MaCB;
        public DateTime NgayGioKhoiHanh;
        public string SanBayDen;
        public int TrangThai;
        public string SoHieuMB;
        public List<string> DanhSachVe = new List<string>(Enumerable.Repeat("", 20));
        public int SoVe;
        public int SoVeDaDat = 0;
        public ChuyenBay next = null;
        //khoi tao
        public ChuyenBay(string maCB, DateTime ngayGioKhoiHanh, string sanBayDen, string soHieuMB,DanhSachMayBay ds)
        {
            this.MaCB = maCB.Substring(0, Math.Min(maCB.Length, 15));
            this.NgayGioKhoiHanh = ngayGioKhoiHanh;
            this.SanBayDen = sanBayDen;
            this.TrangThai = 1;
            this.SoHieuMB = soHieuMB;
            this.SoVe = ds.dsMayBay[ds.TimMayBay(soHieuMB)].SoCho;
        }
        public bool DatVe(HanhKhach hk)
        {
            for (int i = 0; i < SoVe; i++)
            {
                if (DanhSachVe.Contains(hk.CMND))
                {
                    Console.WriteLine("Hanh khach da ton tai.");
                    return false;
                }
            }
            for (int i = 0; i < SoVe; i++)
            {
                if (DanhSachVe[i] == "")
                {
                    DanhSachVe[i] = hk.CMND;
                    SoVeDaDat+=1;
                    Console.WriteLine("Them Hanh khach .");
                    return true;
                }
            }
            return true;
        }
        public void HuyVe(int soVe)
        {
            DanhSachVe[soVe] = null;
            SoVeDaDat--;
        }
    }

    //

    public class DanhSachChuyenBay
    {
        public ChuyenBay head;
        public ChuyenBay tail;
        public int size;
        public DanhSachChuyenBay ()
        {
            head = null;
            tail = null;
            size = 0;
        }
        public int length()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }
        public void ThemCB(string maCB, DateTime ngayGioKhoiHanh, string sanBayDen, string soHieuMB, DanhSachMayBay ds)
        {
            ChuyenBay newest = new ChuyenBay(maCB, ngayGioKhoiHanh, sanBayDen, soHieuMB, ds);
            if (isEmpty())
                head = newest;
            else
                tail.next = newest;
            tail = newest;
            size = size + 1;
        }
        public ChuyenBay TimMaCB(string MaCB)
        {
            ChuyenBay tmp = head;
            while (tmp != null)
            {
                if (tmp.MaCB == MaCB)
                    return tmp;
                tmp = tmp.next;
            }
            return null;
        }
        public bool HuyChuyen(ChuyenBay temp)
        {
            if (temp.TrangThai == 1 || temp.TrangThai == 2)// 1 còn vé 2 hết vé
            {
                temp.TrangThai = 0; // hủy chuyến
                size--;
                return true;
            }
            return false;
        }

        public bool ChinhNgayGio(ChuyenBay temp, DateTime a)
        {
            if (a > temp.NgayGioKhoiHanh)
            {
                temp.NgayGioKhoiHanh = a;
                return true;
            }
            return false;
        }
        public bool DaDuKhach(ChuyenBay temp)
        {
            if (temp.SoVeDaDat < temp.SoVe) return false;
            temp.TrangThai = 2;
            return true;

        }
        
        public void checkHoanTat(ChuyenBay temp, DanhSachMayBay dsmb)
        {
            if (temp.TrangThai ==2|| temp.TrangThai == 1)
            {
                if (temp.NgayGioKhoiHanh <= DateTime.Now)
                {
                    temp.TrangThai = 3; // 3 hoan tat
                   /* int index = dsmb.TimMayBay(temp.SoHieuMB);
                    if (index == -1) return;*/
                    dsmb.dsMayBay[dsmb.TimMayBay(temp.SoHieuMB)].SoChuyenBay+=1;
                }
            }
        }
        public void checkHoanTatAll(DanhSachMayBay dsmb)
        {
            ChuyenBay tmp = head;
            while (tmp != null)
            {
                checkHoanTat(tmp, dsmb);
                tmp = tmp.next;
            }
        }
    }
    class Program
    {
       
            static void Main(string[] args)
            {
                HanhKhach hk1 = new HanhKhach { Ten = "Nguyen Van A", CMND = "123456789" };
                HanhKhach hk2 = new HanhKhach { Ten = "Nguyen Van B", CMND = "987654321" };
                MayBay mb1 = new MayBay("MB001", "Boeing 747", 400);
                MayBay mb2 = new MayBay("MB002", "Airbus A320", 200);
                mb1.SoHieuMB = "MB004";
                DanhSachMayBay dsmb = new DanhSachMayBay();
                dsmb.ThemMayBay(mb1);
                dsmb.ThemMayBay(mb2);
                dsmb.InDanhSach();
                MayBay mb3 = new MayBay("MB003", "Boeing 777", 500);
                int vitri = dsmb.TimMayBay("MB002");
                if (vitri == -1)
                {
                    Console.WriteLine("Khong tim thay may bay");
                }
                else
                {
                   
                    //mb3 = mb4;
                    dsmb.HieuChinh(vitri, mb3);
                    dsmb.InDanhSach();
                }
                DateTime ngayKhoiHanh = new DateTime(2023, 5, 1, 10, 0, 0);
                ChuyenBay cb2 = new ChuyenBay("CB002", ngayKhoiHanh, "Hanoi", "MB004", dsmb);
                
                DanhSachChuyenBay dscb = new DanhSachChuyenBay();
                dscb.ThemCB("CB002", ngayKhoiHanh, "Hanoi", "MB004", dsmb);
                dscb.ThemCB("CB001", ngayKhoiHanh, "Da Nang", "MB003", dsmb);
                
                dscb.TimMaCB("CB002").DatVe(hk1);
                dscb.TimMaCB("CB002").DatVe(hk2);
            
                Console.WriteLine("So chuyen bay: " + dscb.length());
                Console.WriteLine("Danh sach chuyen bay: ");
                //dscb.InDanhSach();
                //dscb.HuyChuyen(cb1);
                dscb.checkHoanTatAll(dsmb);
                Console.WriteLine("So chuyen bay: " + dscb.length());
                Console.WriteLine("May bay đã thực hiện được số chuyến : "+ mb1.SoChuyenBay);
            Console.WriteLine("May bay đã thực hiện được số chuyến : " + mb2.SoChuyenBay);
            Console.WriteLine("Danh sach chuyen bay: ");
            //dscb.InDanhSach();
            Console.ReadLine();
            }
        }

    }