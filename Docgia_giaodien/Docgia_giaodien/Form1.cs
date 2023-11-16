using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Docgia_giaodien
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
  
            
            // Khởi tạo một đối tượng DocGia
                 
            // Thêm đối tượng DocGia vào danh sách
            //DocGia dg;
            //dg = new DocGia() { MaDG = 11111, Ho = "Tran Mai ", Ten = "Tiến", Phai = "Nam", TrangThaiThe = 1 };
            //readerFunc.AddReader(dg);
            ReaderFunc.DocFile();

            DataGrid_DocGia.DataSource = ReaderFunc.ListDocGia; 
        }

        private void btnSapTheoTen_Click(object sender, EventArgs e)
        {
            DataGrid_DocGia.DataSource = null;
            DataGrid_DocGia.DataSource= ReaderFunc.InDanhSachDocGiaTheoTen();
        }

        private void btnSapTheoMaThe_Click(object sender, EventArgs e)
        {
            DataGrid_DocGia.DataSource = null;
            DataGrid_DocGia.DataSource = ReaderFunc.InDanhSachDocGiaTheoMa();
        }

        private void DataGrid_DocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = DataGrid_DocGia.Rows[e.RowIndex];
            int MaDG = int.Parse(row.Cells[0].Value.ToString());
            txtMaDG.Text = " ";
            txtMaDG.Text += MaDG;
            
            string Ho = row.Cells[1].Value.ToString();
            txtHo.Text = Ho;
            string Ten = row.Cells[2].Value.ToString();
            txtTen.Text = Ten;
            string Phai = row.Cells[3].Value.ToString();
            txtPhai.Text = Phai;
            int TrangThaiThe = int.Parse(row.Cells[4].Value.ToString());
            txtTrangThai.Text = " ";
            txtTrangThai.Text += TrangThaiThe;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGrid_DocGia.DataSource = null;
            ReaderFunc.ListDocGia = new List<DocGia>();
            int MaDG = int.Parse(txtMaDG.Text);
            ReaderFunc.XoaDocGia(MaDG);
            MessageBox.Show(ReaderFunc.message);
            ReaderFunc.LuuDanhSachDocGiaVaoFile();
            ReaderFunc.XoaTatCaDocGia();
            ReaderFunc.DocFile();
            DataGrid_DocGia.DataSource = ReaderFunc.ListDocGia;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataGrid_DocGia.DataSource = null;
            ReaderFunc.ListDocGia = new List<DocGia>();
            DocGia newReader;
            int a = ReaderFunc.GetMaDG();
            newReader = new DocGia() { MaDG = a, Ho = txtHo.Text, Ten = txtTen.Text, Phai = txtPhai.Text, TrangThaiThe = 1 };
            ReaderFunc.AddReader(newReader);
            ReaderFunc.LuuDanhSachDocGiaVaoFile();
            ReaderFunc.XoaTatCaDocGia();
            MessageBox.Show("Thêm độc giả thành công !! ");
            
            ReaderFunc.DocFile();
            DataGrid_DocGia.DataSource = ReaderFunc.ListDocGia;
        }

        private void btnHieuChinh_Click(object sender, EventArgs e)
        {
            DataGrid_DocGia.DataSource = null;
            ReaderFunc.ListDocGia = new List<DocGia>();
            int a = ReaderFunc.GetMaDG();
            DocGia Hieuchinh = ReaderFunc.GetReaderByMaDG(int.Parse(txtMaDG.Text));
            Hieuchinh = new DocGia() { MaDG = a, Ho = txtHo.Text, Ten = txtTen.Text, Phai = txtPhai.Text, TrangThaiThe = 1 };
            ReaderFunc.AddReader(Hieuchinh);
            ReaderFunc.LuuDanhSachDocGiaVaoFile();
            ReaderFunc.XoaTatCaDocGia();
            MessageBox.Show("Hiệu chỉnh độc giả thành công !! ");
            ReaderFunc.DocFile();
            DataGrid_DocGia.DataSource = ReaderFunc.ListDocGia;
        }
    }
}
