using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightForm
{
   public class Define
    {
        //May bay
        public const int MAX_LENGTH_SHMB = 15;
        public const int MAX_LENGTH_LMB = 40;
        public const int MAX_SOCHO = 20;
        //Danh sach may bay 
        public const int MAX_MAYBAY = 300;

        //Chuyen bay
        public const int MAX_LENGTH_MACB = 15;
        //--Trang thai chuyen bay
        //0: hủy chuyến, 1: còn vé, 2: hết vé,3: hoàn tất
        public const int HUYCHUYEN = 0;
        public const int CONVE = 1;
        public const int HETVE = 2;
        public const int HOANTAT = 3;

        //HanhKhach
        public const int MAXLENGHT_CMND = 15;
        public const int MAXLENGHT_HOTENDEM = 50;
        public const int MAXLENGHT_TEN = 10;
        public const int MAXLENGHT_PHAI = 4;
    }
}
