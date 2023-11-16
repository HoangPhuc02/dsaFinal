using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Docgia_giaodien
{
    public class MuonTra
    {
        public int MaSach;
        public DateTime NgayMuon;
        public DateTime? NgayTra;
        public int TrangThai;
        public MuonTra(int maSach, DateTime ngayMuon)
        {
            MaSach = maSach;
            NgayMuon = ngayMuon;
            NgayTra = null; // NgayTra được khởi tạo là null, vì khi mới mượn sách chưa có ngày trả.
            TrangThai = 0; // Trạng thái được khởi tạo là 0, vì khi mới mượn sách trạng thái là chưa trả.
        }
    }

}
