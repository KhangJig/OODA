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
    public partial class frmCapNhatThongTinND : Form
    {
        public frmCapNhatThongTinND()
        {
            InitializeComponent();
        }

        #region RÀNG BUỘC CÁC KÍ TỰ TRONG CÁC Ô TEXTBOX

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) )
            {
                return;
            }
            e.Handled = true;
        }

        private void txtTenNguoiDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }
        #endregion

        #region LOAD DỮ LIỆU LÊN FORM CHÍNH
        private void frmCapNhatThongTinND_Load(object sender, EventArgs e)
        {
            ChiTietNguoiDung nd = NguoiDung.LayThongTin(PhanQuyenNguoiDung.TenDangNhap);
            txtDiaChi.Text = nd.DiaChi;
            //dtpNgaySinh.Text = nd.NgaySinh.Day =;
            dtpNgaySinh.Text = nd.NgaySinh.ToString();
            txtSoDienThoai.Text = nd.SDT;
            txtTenNguoiDung.Text = nd.TenND;
            if (nd.GioiTinh == true)
            {
                rdoNam.Checked = true;
            }
            else
                rdoNu.Checked = true;
            lblThongBao.Text = "";
        }
        #endregion

        #region CÁC SỰ KIỆN CỦA BUTTON
        private void btnLuu_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            var str = new StandardWord();
            
            //Lấy các giá trị từ các textbox
            string TenND = str.Standard_Word(txtTenNguoiDung.Text);
            string DiaChi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;
            DateTime NgaySinh = dtpNgaySinh.Value;
            int GioiTinh;
            if (rdoNam.Checked == true)
                GioiTinh = 1;
            else
                GioiTinh = 0;
            if (TenND.Trim() != "")//Cắt khoảng trắng để kiêm tra sự đúng đắn của dữ liệu nhập vào. tránh trường hợp người dùng nhập toàn khoảng trắng
            {
                    if (DiaChi.Trim() != "")
                    {
                    if (DateTime.Compare(DateTime.Now, dtpNgaySinh.Value) >= 0)
                        {
                            //DateTime ns = DateTime.Parse(NgaySinh);//Chuyền kiểu qua DateTime để bắt lỗi cho ngaysinh người dùng nhập
                            NguoiDung.CapNhatThongTin(PhanQuyenNguoiDung.TenDangNhap, TenND, NgaySinh, GioiTinh, DiaChi, SDT);
                            MessageBox.Show("Cập nhập thành công!");
                            this.Close();

                        }
                        else
                        {
                            lblThongBao.Text = "Ngày sinh không hợp lệ";
                            tb.stt(lblThongBao);
                            dtpNgaySinh.Focus();
                        }
                    }
                    else
                    {
                        lblThongBao.Text = "Vui lòng nhập địa chỉ";
                        tb.stt(lblThongBao);
                        txtDiaChi.Focus();
                    }
            }
            else
            {
                lblThongBao.Text = "Vui lòng nhập tên người dùng";
                tb.stt(lblThongBao);
                txtTenNguoiDung.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
