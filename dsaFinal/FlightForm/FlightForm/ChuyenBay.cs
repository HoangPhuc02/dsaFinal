using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightForm
{

    public class ChuyenBay
    {
        public string MaCB;
        public DateTime NgayGioKhoiHanh;
        public string SanBayDen;
        public int TrangThai;
        public string SoHieuMB ;
        public List<string> DanhSachVe = new List<string>(Enumerable.Repeat("", 20));
        public int SoVe;
        public int SoVeDaDat = 0;
        public ChuyenBay next = null;
        //khoi tao
        public ChuyenBay(string maCB, DateTime ngayGioKhoiHanh, string sanBayDen, string soHieuMB, DanhSachMayBay ds)
        {
            this.MaCB = maCB.Substring(0, Math.Min(maCB.Length, Define.MAX_LENGTH_MACB));
            this.NgayGioKhoiHanh = ngayGioKhoiHanh;
            this.SanBayDen = sanBayDen;
            this.TrangThai = 1;
            this.SoHieuMB = soHieuMB;
            this.SoVe = ds.dsMayBay[ds.TimMayBay(soHieuMB)].SoCho;
        }
        public bool DatVe(HanhKhach hk, int viTri)
        {
            for(int i = 0; i < SoVe; i++)
            {
                if (DanhSachVe.Contains(hk.CMND))
                 {
                    //Console.WriteLine("Hanh khach da ton tai.");
                    return false;
                }
            }
            
            if (DanhSachVe[viTri] == "")
            {
                DanhSachVe[viTri] = hk.CMND;
                SoVeDaDat++;
                return true;
                    //Console.WriteLine("Hanh khach da ton tai.");
            }
            
            return false;
        }
        /*public void HuyVe(int soVe)
        {
            DanhSachVe[soVe] = null;
            SoVeDaDat--;
        }*/
    }


    public class DanhSachChuyenBay
    {
        public ChuyenBay head;
        public ChuyenBay tail;
        public int size;
        public DanhSachChuyenBay()
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
            if(temp.TrangThai == Define.CONVE || temp.TrangThai == Define.HETVE)
            {
                temp.TrangThai = Define.HUYCHUYEN;
                size--;
                return true;
            }    
            return false;
        }

        public bool ChinhNgayGio(ChuyenBay temp, DateTime a)
        {
            if(a > temp.NgayGioKhoiHanh)
            {
                temp.NgayGioKhoiHanh = a;
                return true;
            }
            return false;
        }
        public bool DaDuKhach(ChuyenBay temp)
        {
            if (temp.SoVeDaDat < temp.SoVe) return false;
            temp.TrangThai = Define.HETVE;
            return true;

        }
        public int SoVeChuaBan(ChuyenBay temp)
        {
            return temp.SoVe - temp.SoVeDaDat;
        }
        public void checkHoanTat(ChuyenBay temp,DanhSachMayBay dsmb)
        {
            if(temp.TrangThai == Define.HETVE || temp.TrangThai == Define.CONVE)
            {
                if(temp.NgayGioKhoiHanh <= DateTime.Now)
                {
                    temp.TrangThai = Define.HOANTAT;
                    dsmb.dsMayBay[dsmb.TimMayBay(temp.SoHieuMB)].SoChuyenBay++;
                }    
            }    
        }
        public void checkHoanTatAll(DanhSachMayBay dsmb)
        {
            ChuyenBay tmp = head;
            while(tmp != null)
            {
                checkHoanTat(tmp,dsmb);
                tmp = tmp.next;
            }    
        }
    }
}
