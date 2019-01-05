using DevExpress.XtraReports.UI;
using QuanLyPhongMach2.DAO;
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
    public partial class frmBaoCaoDoanhThuTheoNgay : Form
    {
        public frmBaoCaoDoanhThuTheoNgay()
        {
            InitializeComponent();
        }

        int thang = DateTime.Now.Month;
        int nam = DateTime.Now.Year;

        //Hàm LoadData để load lại dữ liệu khi có sự thay đổi
        public void LoadData()
        {
            cbxThang.Text = thang.ToString();
            numNam.Value = nam;
            dgvDoanhThu.DataSource = BaoCaoDoanhThu.LayDuLieu(thang, nam);

            dgvDoanhThu.Columns["NgayKham"].HeaderText = "Ngày";
            dgvDoanhThu.Columns["SoBN"].HeaderText = "Số bệnh nhân";
            dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Doanh thu";

            dgvDoanhThu.Columns["NgayKham"].Width = 200;
            dgvDoanhThu.Columns["SoBN"].Width = 150;
            dgvDoanhThu.Columns["DoanhThu"].Width = 200;
        }
        //Load form
        private void frmBCDoanhThuTheoNgay_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbxThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            thang = int.Parse(cbxThang.Text);
            LoadData();
        }

        private void numNam_ValueChanged(object sender, EventArgs e)
        {
            nam = (int)numNam.Value;
            LoadData();
        }

        private void bttXemBaoCao_Click(object sender, EventArgs e)
        {
            cbxThang.Text = thang.ToString();
            numNam.Value = nam;
            rptBaoCaoDoanhThuTheoNgay report = new rptBaoCaoDoanhThuTheoNgay();
            report.DataSource = BaoCaoDoanhThu.LayDuLieu(thang, nam);
            report.BinData();
            ReportPrintTool tool = new ReportPrintTool(report);
            report.ShowPreviewDialog();
        }

    }
}
