using Kho_Adamstore.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kho_Adamstore
{
    public partial class chitietpn : Form
    {
        public chitietpn()
        {
            InitializeComponent();
        }

        public bool kiemtra(string mactpn)
        {
            string query = "select * from ChiTietPN where MaCTPN = ('" + mactpn + "')";
            DataTable ketqua = DataProvider.Instance.ExecuteQuery(query);
            return ketqua.Rows.Count > 0;
        }
        public void clear()
        {
            txtmact.Text = "";
            
            txtsize.Text = "";
            txtsl.Text = "";
            txtdongia.Text = "";


        }
        public void load()
        {
            string query = "select * from ChiTietPN ";//vi su dung split cat theo khoang trang suy ra viet phaii cach dau phay,


            dtgrvctpn.DataSource = DataProvider.Instance.ExecuteQuery(query);//thuc hien cau truy van voi tham so @tenhang, su dung new ojcect de lay 2 doi tuong Xoai vaff Nho
        }



        private void chitietpn_Load(object sender, EventArgs e)
        {
            load();
            showcbmahang();
            showcbmanv();
            showcbmapn();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string mactpn = txtmact.Text;
            string mapn = cbmapn.Text;
            string mahang = cbmahang.Text;
            string manv = cbmanv.Text;
            string size = txtsize.Text;
            string soluong = txtsl.Text;
            string dongia = txtdongia.Text;
            if (kiemtra(mactpn) == true || mactpn == "")
            {
                MessageBox.Show("Mã trùng hoặc lỗi ");
            }
            else
            {
                string query = "INSERT INTO ChiTietPN (MaCTPN,MaPN,MaHang,MaNV,Size,SoLuongNhap,DonGiaNhap)VALUES ('" + mactpn + "','" + mapn + "','" + mahang + "','" + manv + "', '" + size + "','" + soluong + "','" + dongia + "') ";
                dtgrvctpn.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            load();
            clear();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string mactpn = txtmact.Text;
            string mapn = cbmapn.SelectedValue.ToString();
            string mahang = cbmahang.SelectedValue.ToString();
            string manv = cbmanv.Text;
            string size = txtsize.Text;
            string soluong = txtsl.Text;
            string dongia = txtdongia.Text;
            if (kiemtra(mactpn) == true)
            {
                string query = " UPDATE ChiTietPN SET MaPN = N'" + mapn + "', MaHang = N'" + mahang + "',MaNV = '" + manv + "',Size = N'" + size + "',SoLuongNhap = N'" + soluong + "',DonGiaNhap = N'" + dongia + "' Where MaCTPN = '" + mactpn + "' ";

                dtgrvctpn.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show("Mã Hàng không tồn tại");
            }


            load();
            clear();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mactpn = txtmact.Text;
            string mapn = cbmapn.SelectedValue.ToString();
            string mahang = cbmahang.SelectedValue.ToString();
            string manv = cbmanv.Text;
            string size = txtsize.Text;
            string soluong = txtsl.Text;
            string dongia = txtdongia.Text;
            if (kiemtra(mactpn) == false)
            {
                MessageBox.Show("Mã không tồn tại");
            }
            else
            {
                string query = " DELETE  FROM ChiTietPN WHERE MaCTPN = '" + mactpn + "' ";
                dtgrvctpn.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            load();
            clear();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string timkiem = txttimkiem.Text;
            string query = "select* from ChiTietPN WHERE MaPN like '%" + timkiem + "%'";
            dtgrvctpn.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void cbmapn_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        public void showcbmapn()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(@"select * from PhieuNhap");
            cbmapn.DataSource = data;
            cbmapn.DisplayMember = "MaPN";
            cbmapn.ValueMember = "MaPN";
        }

        private void cbmahang_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        public void showcbmahang()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(@"select * from Hang");
            cbmahang.DataSource = data;
            cbmahang.DisplayMember = "TenHang";
            cbmahang.ValueMember = "MaHang";
        }

        private void cbmanv_MouseClick(object sender, MouseEventArgs e)
        {
            

        }
        public void showcbmanv()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(@"select * from NhanVien");
            cbmanv.DataSource = data;
            cbmanv.DisplayMember = "TenNV";
            cbmanv.ValueMember = "MaNV";
        }

        private void dtgrvctpn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0)
            {
                txtmact.Text = dtgrvctpn.Rows[idx].Cells["MaCTPN"].Value.ToString();
                cbmapn.Text = dtgrvctpn.Rows[idx].Cells["MaPN"].Value.ToString();
                cbmahang.Text = dtgrvctpn.Rows[idx].Cells["MaHang"].Value.ToString();
                cbmanv.Text = dtgrvctpn.Rows[idx].Cells["MaNV"].Value.ToString();
                txtsize.Text = dtgrvctpn.Rows[idx].Cells["Size"].Value.ToString();
                txtsl.Text = dtgrvctpn.Rows[idx].Cells["SoLuongNhap"].Value.ToString();
                txtdongia.Text = dtgrvctpn.Rows[idx].Cells["DonGiaNhap"].Value.ToString();
            }
        }
    }
}
