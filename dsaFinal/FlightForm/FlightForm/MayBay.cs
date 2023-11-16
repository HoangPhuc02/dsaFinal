using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightForm
{
    public class MayBay
    {

        public string SoHieuMB;
        public string LoaiMB;
        public int SoCho;
        public int SoChuyenBay = 0;

        public MayBay(string shmb, string lmb, int socho)
        {
            this.SoHieuMB = shmb.Substring(0, Math.Min(shmb.Length, Define.MAX_LENGTH_SHMB));
            this.LoaiMB = lmb.Substring(0, Math.Min(lmb.Length, Define.MAX_LENGTH_LMB));
            this.SoCho = socho;
        }
    }

    public class DanhSachMayBay
    {
        
        public MayBay[] dsMayBay = new MayBay[Define.MAX_MAYBAY];
        public int soLuong = 0;

        public int ThemMayBay(MayBay mb)
        {
            if (soLuong >= Define.MAX_MAYBAY)
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


        /*public void InDanhSach()
        {

            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine("May bay thu " + (i + 1).ToString() + ": " + dsMayBay[i].SoHieuMB + " " + dsMayBay[i].LoaiMB + " " + dsMayBay[i].SoCho.ToString());
            }
        }*/
    }
}
