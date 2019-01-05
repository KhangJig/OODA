using QuanLyPhongMach2.DAO;
using QuanLyPhongMach2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongMach2
{
    public partial class frmHoaDonThanhToan : Form
    {
        public frmHoaDonThanhToan()
        {
            InitializeComponent();
        }

        int tienThuoc;

        #region RÀNG BUỘC CÁC KÍ TỰ TRONG Ô TEXTBOX
        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void txtTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }
        #endregion

        // Load dữ liệu
        public void LoadData()
        {
            ChiTietHoaDon dh = HoaDon.LayHoaDon(frmPhieuKhamBenh.MaPK);
            txtHoTen.Text = dh.TenBN;
            txtTienKham.Text = dh.TienKham.ToString();
            txtTienThuoc.Text = dh.TienThuoc.ToString();

            if (ckbSuDungThuoc.Checked == true)
            {
                txtSum.Text = (Convert.ToInt32(txtTienThuoc.Text) + Convert.ToInt32(txtTienKham.Text)).ToString();
            }
            else
                txtSum.Text = Convert.ToInt32(txtTienKham.Text).ToString();
        }
        
        private void frmHoaDonThanhToan_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            LoadData();
            tienThuoc = int.Parse(txtTienThuoc.Text.ToString());
            if (Convert.ToInt32(txtTienThuoc.Text) == 0)
            {
                ckbSuDungThuoc.Checked = false;
            }
        }

        // kiểm tra sử dụng thuốc
        private void ckbSuDungThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSuDungThuoc.Checked == true)
            {
                txtTienThuoc.Text = tienThuoc.ToString();
                txtSum.Text = (Convert.ToInt32(txtTienThuoc.Text) + Convert.ToInt32(txtTienKham.Text)).ToString();
            }
            else
            {
                txtTienThuoc.Text = "0";
                txtSum.Text = Convert.ToInt32(txtTienKham.Text).ToString();
            }
        }

        #region SỰ KIỆN CÁC BUTTON
        private void btnLuu_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            if(txtHoTen.Text!= null)
            {
                try
                {
                    HoaDon.CapNhapHoaDon(frmPhieuKhamBenh.MaPK, int.Parse(txtTienThuoc.Text), int.Parse(txtTienKham.Text));

                    if (ckbSuDungThuoc.Checked == true)
                        txtSum.Text = (Convert.ToInt32(txtTienThuoc.Text) + Convert.ToInt32(txtTienKham.Text)).ToString();
                    else
                        txtSum.Text = Convert.ToInt32(txtTienKham.Text).ToString();

                    lblThongBao.ForeColor = Color.Green;
                    lblThongBao.Text = "Cập nhập hoá đơn thành công";
                    tb.stt(lblThongBao);
                    btnThoat.Focus();
                }
                catch
                {
                    lblThongBao.Text = "Dữ liệu nhập vào không hợp lệ";
                    tb.stt(lblThongBao);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
