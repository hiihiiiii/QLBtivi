using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLBtivi
{
	public partial class Form : System.Windows.Forms.Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		DataTable table = new DataTable();
		string SQL_DSNhanVien;
		string dkDT;
		string rdbTimKiem = null;
		public string TongDT { get; private set; }
		public string TongHDB { get; private set; }
		public Form()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			dgvDSNV.DataSource = pd.DocBang("select * from NhanVien");
			dtgDSSP.DataSource = pd.DocBang("select * from DMTivi");
			SQL_DSNhanVien = "select * from NhanVien";
			dgvDoanhThu.DataSource = pd.DocBang("select * from HoaDonBan");
			dgvDoanhThu.ReadOnly = true;


			dtpNV.Format = DateTimePickerFormat.Custom;
			dtpNV.CustomFormat = "MM/dd/yyyy";
			dtpSP.Format = DateTimePickerFormat.Custom;
			dtpSP.CustomFormat = "MM/dd/yyyy";
			TimeFor.Format = DateTimePickerFormat.Custom;
			TimeFor.CustomFormat = "dd/MM/yyyy";
			TimeTo.Format = DateTimePickerFormat.Custom;
			TimeTo.CustomFormat = "dd/MM/yyyy";
			txtTongDT.ForeColor = Color.Black;
			txtTongDT.BackColor = Color.White;
			txtTongHD_DT.ForeColor = Color.Black;
			txtTongHD_DT.BackColor = Color.White;

			txtTongDT.Enabled = false;
			txtTongHD_DT.Enabled = false;



			DataTable dt = pd.DocBang("select sum(TongTien) as tongtien, count(SoHDB) as TongHDB from HoaDonBan");
			TongDT = (dt.Rows[0])[0].ToString();
			txtTongDT.Text = TongDT + " vnd";

			TongHDB = (dt.Rows[0])[1].ToString();
			txtTongHD_DT.Text = TongHDB;

			//set quy
			BoxTimeDT.Items.Add("Quý 1");
			BoxTimeDT.Items.Add("Quý 2");
			BoxTimeDT.Items.Add("Quý 3");
			BoxTimeDT.Items.Add("Quý 4");
		}

		private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void tBanHang_Click(object sender, EventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void QuanLiBanTV_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void dgvDSNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnSua_Click(object sender, EventArgs e)
		{

		}

		private void btnXoa_Click(object sender, EventArgs e)
		{

		}

		private void btnLuu_Click(object sender, EventArgs e)
		{

		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}

		private void button10_Click(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void nudSoLuong_ValueChanged(object sender, EventArgs e)
		{

		}

		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void txtMaTV_TextChanged(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void txtSoHDB_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtMaNV_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtMaNCC_TextChanged(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label12_Click(object sender, EventArgs e)
		{

		}

		private void tBanHang_Click_1(object sender, EventArgs e)
		{

		}

		private void label5_Click_1(object sender, EventArgs e)
		{

		}

		private void txtDonGia_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtGiamGia_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtThanhTien_TextChanged(object sender, EventArgs e)
		{

		}

		private void label15_Click(object sender, EventArgs e)
		{

		}

		private void tDSSP_Click(object sender, EventArgs e)
		{

		}

		private void label24_Click(object sender, EventArgs e)
		{

		}

		private void textBox21_TextChanged(object sender, EventArgs e)
		{

		}

		private void groupBox11_Enter(object sender, EventArgs e)
		{

		}
		//form sanpham
		private void btnThemSP_Click(object sender, EventArgs e)
		{
			if (kiemtradl_sanpham() == true)
			{
				string sql = "insert into DMTivi(MaTV,TenTv,DonGiaNhap,DonGiaBan,SoLuong,ThoiGianBH," +
					"MaHangSX,MaKieu,MaMau,MaMH,MaCo,MaNuocSX) values('" + txtMaTV.Text + "','" + txtTenTV.Text + "','" + txtDonGiaNhap.Text + "'," +
					"'" + txtDonGiaBan.Text + "','" + txtSoLuong.Text + "','" + dtpSP.Value.Date.ToString() + "'," +
					"'" + txtMaHSX.Text + "','" + txtMaKieu.Text + "','" + txtMaMau.Text + "','" + txtMaManHinh.Text + "','" + txtMaCo.Text + "','" + txtMaNuocSX.Text + "')";
				pd.CapNhat(sql);
				dtgDSSP.DataSource = pd.DocBang("select * from DMTivi");
			}
		}
		bool kiemtradl_sanpham()
		{
			bool k = true;
			if (txtMaTV.Text.Trim().Equals("") || txtTenTV.Text.Trim() == "" || txtMaHSX.Text.Trim() == "" || txtMaKieu.Text.Trim() == "" ||
				txtMaMau.Text.Trim() == "" || txtMaManHinh.Text.Trim() == "" || txtMaCo.Text.Trim() == "" || txtMaNuocSX.Text.Trim() == "" ||
				txtSoLuong.Text.Trim() == "" || txtDonGiaNhap.Text.Trim() == "" || txtDonGiaBan.Text.Trim() == "")
			{
				k = false;
				MessageBox.Show("Vui lòng nhập đủ dữ liệu");

			}
			else
			{
				DataTable tb = pd.DocBang("select * from DMTivi where MaTV='" + txtMaTV.Text + "'");
				if (tb.Rows.Count > 0)
				{
					k = false;
					MessageBox.Show("Tivi đã tồn tại");

				}
			}
			return k;
		}

		private void btnSuaSP_Click(object sender, EventArgs e)
		{
			string sql;
			sql = "UPDATE DMTivi SET TenTv='" + txtTenTV.Text + "',DonGiaNhap='" + txtDonGiaNhap.Text + "',DonGiaBan='" + txtDonGiaBan.Text + "'," +
				"SoLuong='" + txtSoLuong.Text + "',ThoiGianBH='" + dtpSP.Value.Date.ToString() + "',MaHangSX='" + txtMaHSX.Text + "'," +
				"MaKieu='" + txtMaKieu.Text + "',MaMau='" + txtMaMau.Text + "',MaMH='" + txtMaManHinh.Text + "',MaCo='" + txtMaCo.Text + "',MaNuocSX='" + txtMaNuocSX.Text + "'" +
				"where MaTV='" + txtMaTV.Text + "'";
			pd.CapNhat(sql);
			dtgDSSP.DataSource = pd.DocBang("select * from DMTivi");
		}

		private void dtgDSSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow row = new DataGridViewRow();
			row = dtgDSSP.Rows[e.RowIndex];
			txtMaTV.Text = Convert.ToString(row.Cells["MaTV"].Value);
			txtTenTV.Text = Convert.ToString(row.Cells["TenTv"].Value);
			txtDonGiaNhap.Text = Convert.ToString(row.Cells["DonGiaNhap"].Value);
			txtDonGiaBan.Text = Convert.ToString(row.Cells["DonGiaBan"].Value);
			txtSoLuong.Text = Convert.ToString(row.Cells["SoLuong"].Value);
			dtpSP.Text = Convert.ToString(row.Cells["ThoiGianBH"].Value);
			txtMaHSX.Text = Convert.ToString(row.Cells["MaHangSX"].Value);
			txtMaKieu.Text = Convert.ToString(row.Cells["MaKieu"].Value);
			txtMaMau.Text = Convert.ToString(row.Cells["MaMau"].Value);
			txtMaManHinh.Text = Convert.ToString(row.Cells["MaMH"].Value);
			txtMaCo.Text = Convert.ToString(row.Cells["MaCo"].Value);
			txtMaNuocSX.Text = Convert.ToString(row.Cells["MaNuocSX"].Value);

		}
		private void btnThoatSP_Click(object sender, EventArgs e)
		{
			DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (dg == DialogResult.OK)
			{
				Application.Exit();
			}
		}
		private void resetSP()
		{
			txtMaTV.Text = "";
			txtTenTV.Text = "";
			txtDonGiaBan.Text = "";
			txtDonGiaNhap.Text = "";
			txtSoLuong.Text = "";
			dtpSP.Value = DateTime.Now;
			txtMaHSX.Text = "";
			txtMaKieu.Text = "";
			txtMaMau.Text = "";
			txtMaManHinh.Text = "";
			txtMaCo.Text = "";
			txtMaNuocSX.Text = "";

		}
		private void btnHuySP_Click(object sender, EventArgs e)
		{
			resetSP();
		}
		private void btnXoaSP_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				pd.CapNhat("delete ChiTietHDB where MaTV='" + txtMaTV.Text + "'");
				pd.CapNhat("delete ChiTietHDN where MaTV='" + txtMaTV.Text + "'");
				DataTable tb = pd.DocBang("select * from DMTivi where MaTV='" + txtMaTV.Text + "'");
				pd.CapNhat("delete from DMTivi where MaTV='" + txtMaTV.Text + "'");
				dtgDSSP.DataSource = pd.DocBang("select * from DMTivi");
			}
		}
		private void btnTimKiemSP_Click(object sender, EventArgs e)
		{
			string sql;
			sql = "select MaTV,TenTv,DonGiaNhap,DonGiaBan,SoLuong,ThoiGianBH,MaHangSX,MaKieu,MaMau," +
				"MaMH,MaCo,MaNuocSX from DMTivi where MaTV like N'%" + txtMaTV.Text.Trim() + "%'";


			if (txtMaTV.Text != "")
			{
				sql = sql + "and MaTV like N'%" + txtMaTV.Text.Trim() + "%'";
			}
			if (txtTenTV.Text != "")
			{
				sql = sql + "and TenTv like N'%" + txtTenTV.Text.Trim() + "%'";
			}
			if (txtDonGiaBan.Text != "")
			{
				sql = sql + "and DonGiaBan <= " + txtDonGiaBan.Text;
			}
			if (txtDonGiaNhap.Text != "")
			{
				sql = sql + "and DonGiaNhap <= " + txtDonGiaNhap.Text;
			}
			if (txtMaHSX.Text != "")
			{
				sql = sql + "and MaHangSX like N'%" + txtMaHSX.Text.Trim() + "%'";
			}
			if (txtMaKieu.Text != "")
			{
				sql = sql + "and MaKieu like N'%" + txtMaKieu.Text.Trim() + "%'";
			}
			if (txtMaManHinh.Text != "")
			{
				sql = sql + "and MaMH like N'%" + txtMaManHinh.Text.Trim() + "%'";
			}
			if (txtMaCo.Text != "")
			{
				sql = sql + "and MaCo like N'%" + txtMaCo.Text.Trim() + "%'";
			}
			if (txtMaNuocSX.Text != "")
			{
				sql = sql + "and MaNuocSX like N'%" + txtMaNuocSX.Text.Trim() + "%'";
			}

			dtgDSSP.DataSource = pd.DocBang(sql);
			dtgDSSP.Columns[0].HeaderText = "Mã Tivi";
			dtgDSSP.Columns[1].HeaderText = "Tên Tivi";
			dtgDSSP.Columns[2].HeaderText = "Đơn giá nhập";
			dtgDSSP.Columns[3].HeaderText = "Đơn giá bán";
			dtgDSSP.Columns[4].HeaderText = "Số lượng";
			dtgDSSP.Columns[5].HeaderText = "Thời gian bảo hành";
			dtgDSSP.Columns[6].HeaderText = "Mã hãng SX";
			dtgDSSP.Columns[7].HeaderText = "Mã kiểu";
			dtgDSSP.Columns[8].HeaderText = "Mã màu";
			dtgDSSP.Columns[9].HeaderText = "Mã màn hình";
			dtgDSSP.Columns[10].HeaderText = "Mã cỡ";
			dtgDSSP.Columns[11].HeaderText = "Mã nước SX";
			dtgDSSP.Columns[0].DataPropertyName = "MaTV";
			dtgDSSP.Columns[1].DataPropertyName = "TenTv";
			dtgDSSP.Columns[2].DataPropertyName = "DonGiaNhap";
			dtgDSSP.Columns[3].DataPropertyName = "DonGiaBan";
			dtgDSSP.Columns[4].DataPropertyName = "SoLuong";
			dtgDSSP.Columns[5].DataPropertyName = "ThoiGianBH";
			dtgDSSP.Columns[6].DataPropertyName = "MaHangSX";
			dtgDSSP.Columns[7].DataPropertyName = "MaKieu";
			dtgDSSP.Columns[8].DataPropertyName = "MaMau";
			dtgDSSP.Columns[9].DataPropertyName = "MaMH";
			dtgDSSP.Columns[10].DataPropertyName = "MaCo";
			dtgDSSP.Columns[11].DataPropertyName = "MaNuocSX";
		}

		// Form nhan vien
		private void dgvDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow row = new DataGridViewRow();
			row = dgvDSNV.Rows[e.RowIndex];
			txtMaNV.Text = Convert.ToString(row.Cells["MaNV"].Value);
			txtTenNV.Text = Convert.ToString(row.Cells["TenNV"].Value);
			txtGioiTinh.Text = Convert.ToString(row.Cells["GioiTinh"].Value);
			dtpNV.Text = Convert.ToString(row.Cells["NgaySinh"].Value);
			txtDienThoai.Text = Convert.ToString(row.Cells["DienThoai"].Value);
			txtMaCa.Text = Convert.ToString(row.Cells["MaCa"].Value);
			txtMaCV.Text = Convert.ToString(row.Cells["MaCV"].Value);
			txtDiaChi.Text = Convert.ToString(row.Cells["DiaChi"].Value);
		}
		bool kiemtradl()
		{
			bool k = true;
			if (txtMaNV.Text.Trim().Equals("") || txtTenNV.Text.Trim() == "" || txtGioiTinh.Text.Trim() == "" ||
				txtDienThoai.Text.Trim() == "" || txtMaCa.Text.Trim() == "" || txtMaCV.Text.Trim() == "" || txtDiaChi.Text.Trim() == "")
			{
				k = false;
				MessageBox.Show("Vui lòng nhập đủ dữ liệu");

			}
			else
			{
				DataTable tb = pd.DocBang("select * from NhanVien where MaNV='" + txtMaNV.Text + "'");
				if (tb.Rows.Count > 0)
				{
					k = false;
					MessageBox.Show("Mã nhân viên đã tồn tại");

				}
			}
			return k;
		}
		private void reset()
		{
			txtMaNV.Text = "";
			txtTenNV.Text = "";
			txtGioiTinh.Text = "";
			txtDienThoai.Text = "";
			txtMaCa.Text = "";
			txtMaCV.Text = "";
			txtDiaChi.Text = "";
			dtpNV.Value = DateTime.Now;
		}
		private void btnThemNV_Click(object sender, EventArgs e)
		{
			if (kiemtradl() == true)
			{
				string sql = "insert into NhanVien(MaNV,TenNV,GioiTinh,NgaySinh,DienThoai,MaCa,MaCV,DiaChi) values('" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + txtGioiTinh.Text + "','" + dtpNV.Value.Date.ToString() + "'," +
					"'" + txtDienThoai.Text + "','" + txtMaCa.Text + "','" + txtMaCV.Text + "',N'" + txtDiaChi.Text + "')";
				pd.CapNhat(sql);
				dgvDSNV.DataSource = pd.DocBang("select * from NhanVien");
				SQL_DSNhanVien = "select * from NhanVien";
			}

		}
		private void btnTimKiemNV_Click(object sender, EventArgs e)
		{
			string sql;
			sql = "select MaNV,TenNV,GioiTinh,NgaySinh," +
				"DienThoai,MaCa,MaCV,DiaChi from NhanVien where MaNV like N'%" + txtMaNV.Text.Trim() + "%'";


			if (txtMaNV.Text != "")
			{
				sql = sql + "and MaNV like N'%" + txtMaNV.Text.Trim() + "%'";
			}
			if (txtTenNV.Text != "")
			{
				sql = sql + "and TenNV like N'%" + txtTenNV.Text.Trim() + "%'";
			}
			if (txtGioiTinh.Text != "")
			{
				sql = sql + "and GioiTinh like N'%" + txtGioiTinh.Text.Trim() + "%'";
			}
			if (txtDienThoai.Text != "")
			{
				sql = sql + "and DienThoai like N'%" + txtDienThoai.Text.Trim() + "%'";
			}
			if (txtMaCa.Text != "")
			{
				sql = sql + "and MaCa like N'%" + txtMaCa.Text.Trim() + "%'";
			}
			if (txtMaCV.Text != "")
			{
				sql = sql + "and MaCV like N'%" + txtMaCV.Text.Trim() + "%'";
			}
			if (txtDiaChi.Text != "")
			{
				sql = sql + "and DiaChi like N'%" + txtDiaChi.Text.Trim() + "%'";
			}

			dgvDSNV.DataSource = pd.DocBang(sql);
			dgvDSNV.Columns[0].HeaderText = "Mã nhân viên";
			dgvDSNV.Columns[1].HeaderText = "Tên nhân viên";
			dgvDSNV.Columns[2].HeaderText = "Giới tính";
			dgvDSNV.Columns[3].HeaderText = "Ngày sinh";
			dgvDSNV.Columns[4].HeaderText = "Điện thoại";
			dgvDSNV.Columns[5].HeaderText = "Mã ca";
			dgvDSNV.Columns[6].HeaderText = "Mã công việc";
			dgvDSNV.Columns[7].HeaderText = "Địa chỉ";
			dgvDSNV.Columns[0].DataPropertyName = "MaNV";
			dgvDSNV.Columns[1].DataPropertyName = "TenNV";
			dgvDSNV.Columns[2].DataPropertyName = "GioiTinh";
			dgvDSNV.Columns[3].DataPropertyName = "NgaySinh";
			dgvDSNV.Columns[4].DataPropertyName = "DienThoai";
			dgvDSNV.Columns[5].DataPropertyName = "MaCa";
			dgvDSNV.Columns[6].DataPropertyName = "MaCV";
			dgvDSNV.Columns[7].DataPropertyName = "DiaChi";
		}

		private void btnThoatNV_Click(object sender, EventArgs e)
		{
			DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (dg == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private void btnHuyNV_Click(object sender, EventArgs e)
		{
			SQL_DSNhanVien = "select * from NhanVien";
			reset();
		}

		private void btnLuuNV_Click(object sender, EventArgs e)
		{
			table = pd.DocBang(SQL_DSNhanVien);
			if (table.Rows.Count > 0)
			{
				Excel.Application exApp = new Excel.Application();
				Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
				Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

				Excel.Range tenDanhSach = (Excel.Range)exSheet.Cells[5, 2];
				exSheet.get_Range("B5:G5").Merge(true);
				tenDanhSach.Font.Size = 12;
				tenDanhSach.Font.Bold = true;
				tenDanhSach.Font.Color = Color.Blue;
				tenDanhSach.Value = "DANH SÁCH NHÂN VIÊN";

				exSheet.get_Range("A7:G7").Font.Bold = true;
				exSheet.get_Range("A7:G7").HorizontalAlignment =
					Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
				exSheet.get_Range("A7").Value = "STT";
				exSheet.get_Range("B7").Value = "Mã nhân viên";
				exSheet.get_Range("C7").Value = "Tên nhân viên";
				exSheet.get_Range("C7").ColumnWidth = 20;
				exSheet.get_Range("D7").Value = "Giới tính";
				exSheet.get_Range("E7").Value = "Ngày sinh";
				exSheet.get_Range("F7").Value = "Điện thoại";
				exSheet.get_Range("G7").Value = "Mã ca";
				exSheet.get_Range("H7").Value = "Mã công việc";
				exSheet.get_Range("I7").Value = "Địa chỉ";
				for (int i = 0; i < table.Rows.Count; i++)
				{
					exSheet.get_Range("A" + (i + 10).ToString() + ":H" + (i + 10).ToString()).Font.Bold = false;
					exSheet.get_Range("A" + (i + 10).ToString()).Value = (i + 1).ToString();
					exSheet.get_Range("B" + (i + 10).ToString()).Value = table.Rows[i]["MaNV"].ToString();
					exSheet.get_Range("C" + (i + 10).ToString()).Value = table.Rows[i]["TenNV"].ToString();
					exSheet.get_Range("D" + (i + 10).ToString()).Value = table.Rows[i]["GioiTinh"].ToString();
					exSheet.get_Range("E" + (i + 10).ToString()).Value = table.Rows[i]["NgaySinh"].ToString();
					exSheet.get_Range("F" + (i + 10).ToString()).Value = table.Rows[i]["DienThoai"].ToString();
					exSheet.get_Range("G" + (i + 10).ToString()).Value = table.Rows[i]["MaCa"].ToString();
					exSheet.get_Range("H" + (i + 10).ToString()).Value = table.Rows[i]["MaCV"].ToString();
					exSheet.get_Range("I" + (i + 10).ToString()).Value = table.Rows[i]["DiaChi"].ToString();
				}
				exSheet.Name = "TiVi";
				exBook.Activate();
				saveDSTV.Filter = "Excel Document(*.xls)|*.xls |Word Document(*.doc) \r\n|*.doc|All files(*.*)|*.*";
				saveDSTV.FilterIndex = 1;
				saveDSTV.AddExtension = true;
				saveDSTV.DefaultExt = ".xls";
				if (saveDSTV.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					exBook.SaveAs(saveDSTV.FileName.ToString());
				exApp.Quit();
			}
			else
			{
				MessageBox.Show("Không có danh sách để in");
			}
		}
		private void btnXoaNV_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				pd.CapNhat("delete from ChiTietHDN where SoHDN in (select SoHDN from HoaDonNhap where MaNV='" + txtMaNV.Text + "')");
				pd.CapNhat("delete from ChiTietHDB where SoHDB in (select SoHDB from HoaDonBan where MaNV='" + txtMaNV.Text + "')");
				pd.CapNhat("delete HoaDonBan where MaNV='" + txtMaNV.Text + "'");
				pd.CapNhat("delete HoaDonNhap where MaNV='" + txtMaNV.Text + "'");
				DataTable tb = pd.DocBang("select * from NhanVien where MaNV='" + txtMaNV.Text + "'");
				pd.CapNhat("delete from NhanVien where MaNV='" + txtMaNV.Text + "'");
				dgvDSNV.DataSource = pd.DocBang("select * from NhanVien");
				SQL_DSNhanVien = "select * from NhanVien";
			}
		}

		private void btnSuaNV_Click(object sender, EventArgs e)
		{

			string sql;
			sql = "UPDATE NhanVien SET NgaySinh='" + dtpNV.Value.Date.ToString() + "', TenNV=N'" + txtTenNV.Text + "',GioiTinh= N'" + txtGioiTinh.Text + "',DiaChi=N'" + txtDiaChi.Text + "'" +
				",MaCa='" + txtMaCa.Text + "',MaCV='" + txtMaCV.Text + "',DienThoai='" + txtDienThoai.Text + "' WHERE MaNV='" + txtMaNV.Text + "'";
			pd.CapNhat(sql);
			dgvDSNV.DataSource = pd.DocBang("select * from NhanVien");
			SQL_DSNhanVien = "select * from NhanVien";
		}

		private void dgvDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnXuatDT_Click(object sender, EventArgs e)
		{
			Excel.Application exApp = new Excel.Application();
			Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
			Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

			//định dạng chung 
			Excel.Range name = (Excel.Range)exSheet.Cells[1, 1];
			name.Font.Size = 12;
			name.Font.Bold = true;
			name.Font.Color = Color.Blue;
			name.Value = "Của hàng bán TiVi và các thiết bị điện tử";

			Excel.Range DiaChi = (Excel.Range)exSheet.Cells[2, 1];
			DiaChi.Font.Size = 12;
			DiaChi.Font.Bold = true;
			DiaChi.Font.Color = Color.Blue;
			DiaChi.Value = "Địa chỉ: 99 Nguyễn Chí Thanh, Láng Hạ, Đống Đa, Hà Nội";

			Excel.Range dt = (Excel.Range)exSheet.Cells[3, 1];
			dt.Font.Size = 12;
			dt.Font.Bold = true;
			dt.Font.Color = Color.Blue;
			dt.Value = "Hotline: 0865564397 - 0862947104";


			Excel.Range Header = (Excel.Range)exSheet.Cells[5, 2];
			exSheet.get_Range("B5:G5").Merge(true);
			name.Font.Size = 12;
			name.Font.Bold = true;
			name.Font.Color = Color.DarkBlue;
			name.Value = "DANH SÁCH HÓA ĐƠN";

			//định dạng tiêu đề bảng

			exSheet.get_Range("A7:G7").Font.Bold = true;
			exSheet.get_Range("A7:G7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
			exSheet.get_Range("A7").Value = "STT";
			exSheet.get_Range("B7").Value = "Mã Hóa Đơn Bán";
			exSheet.get_Range("C7").Value = "Mã Nhân Viên";
			exSheet.get_Range("D7").Value = "Mã Khách Hàng";
			exSheet.get_Range("E7").Value = "Ngày Bán";
			exSheet.get_Range("F7").Value = "Thuế";
			exSheet.get_Range("G7").Value = "Tổng Tiền";


			//Lấy DL
			string sql = "Select * from HoaDonBan " + dkDT;
			DataTable XuatFile = pd.DocBang(sql);

			//In DL
			for (int i = 0; i < XuatFile.Rows.Count; i++)
			{
				exSheet.get_Range("A" + (i + 8).ToString() + ":G" + (i + 8).ToString()).Font.Bold = false;
				exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
				exSheet.get_Range("B" + (i + 8).ToString()).Value = XuatFile.Rows[i]["SoHDB"].ToString();
				exSheet.get_Range("C" + (i + 8).ToString()).Value = XuatFile.Rows[i]["MaNV"].ToString();
				exSheet.get_Range("D" + (i + 8).ToString()).Value = XuatFile.Rows[i]["MaKhach"].ToString();
				exSheet.get_Range("E" + (i + 8).ToString()).Value = XuatFile.Rows[i]["NgayBan"].ToString();
				exSheet.get_Range("F" + (i + 8).ToString()).Value = XuatFile.Rows[i]["Thue"].ToString();
				exSheet.get_Range("G" + (i + 8).ToString()).Value = XuatFile.Rows[i]["TongTien"].ToString();
			}
			exSheet.Name = "HoaDonBan";
			exBook.Activate();//kích hoạt file excel
							  //thiết lập các thuộc tính của savefileDiaLog
			dlgSaveDT.Filter = "Excel Document(*.xls)|*.xls |Word Document(*.doc)|*.doc|All files(*.*)|*.*";
			dlgSaveDT.FilterIndex = 1;
			dlgSaveDT.AddExtension = true;
			dlgSaveDT.DefaultExt = ".xls";
			if (dlgSaveDT.ShowDialog() == System.Windows.Forms.DialogResult.OK) exBook.SaveAs(dlgSaveDT.FileName.ToString());
			exApp.Quit();
		}

		private void rdbTheoNgay_CheckedChanged(object sender, EventArgs e)
		{
			rdbTimKiem = rdbTheoNgay.Text;
		}

		private void btnXoaDT_Click(object sender, EventArgs e)
		{
			dgvDoanhThu.DataSource = pd.DocBang("Select * from HoaDonBan");
			DataTable dt = pd.DocBang("Select sum(TongTien) as tongtien, count(SoHDB) from HoaDonBan");
			TongDT = (dt.Rows[0])[0].ToString();
			TongHDB = (dt.Rows[0])[1].ToString();
			dkDT = "";

			txtTongDT.Text = TongDT + " vnd";
			txtTongHD_DT.Text = TongHDB;
			txtNameNV.Text = null;
			txtNameKH.Text = null;
			txtNamTheoQuy.Text = null;
			BoxTimeDT.Text = null;
			txtValueFor.Text = null;
			txtValueTo.Text = null;
			rdbTheoNgay.Checked = false;
			rdbTheoQuy.Checked = false;
			rdbTheoGiaTri.Checked = false;
			rdbTheoNV.Checked = false;
			rdbTheoKH.Checked = false;
			txtMaHDB_DT.Text = null;
		}

		private void rdbTheoQuy_CheckedChanged(object sender, EventArgs e)
		{
			rdbTimKiem = rdbTheoQuy.Text;
		}

		private void rdbTheoGiaTri_CheckedChanged(object sender, EventArgs e)
		{
			rdbTimKiem = rdbTheoGiaTri.Text;
		}

		private void rdbTheoNV_CheckedChanged(object sender, EventArgs e)
		{
			rdbTimKiem = rdbTheoNV.Text;
		}

		private void rdbTheoKH_CheckedChanged(object sender, EventArgs e)
		{
			rdbTimKiem = rdbTheoKH.Text;
		}

		private void btnTimKiemDT_Click(object sender, EventArgs e)
		{

			if (rdbTimKiem == null)
			{
				MessageBox.Show("Hãy chọn loại dữ liệu cần tìm kiếm!", "Thông báo");
			}
			else if (rdbTimKiem.ToString() == rdbTheoNgay.Text)
			{

				string DTimetextTo = TimeTo.Value.Year.ToString() + "/" + TimeTo.Value.Month.ToString() + "/" + TimeTo.Value.Day.ToString();
				string DTimetextFor = TimeFor.Value.Year.ToString() + "/" + TimeFor.Value.Month.ToString() + "/" + TimeFor.Value.Day.ToString();

				dkDT = "Where NgayBan >= '" + DTimetextFor + "' and NgayBan <= '" + DTimetextTo + "'";
				string sql = "Select * from HoaDonBan " + dkDT + " order by NgayBan DESC";
				dgvDoanhThu.DataSource = pd.DocBang(sql);

				DataTable dt = pd.DocBang("Select sum(TongTien) as tongtien, count(SoHDB) from HoaDonBan " + dkDT);
				TongDT = (dt.Rows[0])[0].ToString();
				txtTongDT.Text = TongDT + " vnd";

				TongHDB = (dt.Rows[0])[1].ToString();
				txtTongHD_DT.Text = TongHDB;

			}
			else if (rdbTimKiem.ToString() == rdbTheoQuy.Text)
			{
				string nam = txtNamTheoQuy.Text;
				string item = BoxTimeDT.Text;
				int thang = 0;
				if (item == "Quý 1") thang = 1;
				else if (item == "Quý 2") thang = 4;
				else if (item == "Quý 3") thang = 7;
				else if (item == "Quý 4") thang = 10;

				int endDay;
				if (thang + 2 == 3 || thang + 2 == 12)
				{
					endDay = 31;
				}
				else endDay = 30;

				string DTimetextTo = nam + "/" + (thang + 2).ToString() + "/" + endDay.ToString();
				string DTimetextFor = nam + "/" + thang.ToString() + "/1";


				dkDT = "Where NgayBan >= '" + DTimetextFor + "' and NgayBan <= '" + DTimetextTo + "'";
				string sql = "Select * from HoaDonBan " + dkDT + " order by NgayBan DESC";
				dgvDoanhThu.DataSource = pd.DocBang(sql);

				DataTable dt = pd.DocBang("Select sum(TongTien) as tongtien, count(SoHDB) from HoaDonBan " + dkDT);
				TongDT = (dt.Rows[0])[0].ToString();
				txtTongDT.Text = TongDT + " vnd";

				TongHDB = (dt.Rows[0])[1].ToString();
				txtTongHD_DT.Text = TongHDB;


			}
			else if (rdbTimKiem.ToString() == rdbTheoGiaTri.Text)
			{
				string valueST = txtValueFor.Text;
				string valueED = txtValueTo.Text;
				if (valueST == "") valueST = "1";
				if (valueED == "") valueED = "0";

				if (int.Parse(valueST) <= int.Parse(valueED))
				{

					dkDT = "Where TongTien >= '" + valueST + "' and TongTien <= '" + valueED + "'";
					string sql = "Select * from HoaDonBan " + dkDT + " order by TongTien";
					dgvDoanhThu.DataSource = pd.DocBang(sql);

					DataTable dt = pd.DocBang("Select sum(TongTien) as tongtien, count(SoHDB) from HoaDonBan " + dkDT);
					TongDT = (dt.Rows[0])[0].ToString();
					txtTongDT.Text = TongDT + " vnd";

					TongHDB = (dt.Rows[0])[1].ToString();
					txtTongHD_DT.Text = TongHDB;
				}
				else
				{
					MessageBox.Show("Hãy nhập lại giá trị", "Thông báo");

				}
			}
			else if (rdbTimKiem.ToString() == rdbTheoKH.Text)
			{
				if (txtNameKH.Text.Trim() != "")
				{
					string name = txtNameKH.Text;
					DataTable DSKH = pd.DocBang("select MaKhach from KhachHang where TenKhach like N'%" + name + "%' ");

					DataTable Dem = pd.DocBang("select count(MaKhach) from KhachHang where TenKhach like N'%" + name + "%' ");
					int n = int.Parse((Dem.Rows[0])[0].ToString());
					if (n > 0)
					{
						string s = "";
						string[] DSMaKH = new string[n + 1];
						s = "Where MaKhach = '" + (DSKH.Rows[0])[0].ToString() + "' ";
						for (int i = 1; i < n; i++)
						{
							DSMaKH[i] = (DSKH.Rows[i])[0].ToString();
							s += "or MaKhach ='" + DSMaKH[i] + "' ";
						}



						dkDT = s;
						string sql = "Select * from HoaDonBan " + dkDT;
						dgvDoanhThu.DataSource = pd.DocBang(sql);

						DataTable dt = pd.DocBang("Select sum(TongTien) as tongtien, count(SoHDB) from HoaDonBan " + dkDT);
						TongDT = (dt.Rows[0])[0].ToString();
						txtTongDT.Text = TongDT + " vnd";

						TongHDB = (dt.Rows[0])[1].ToString();
						txtTongHD_DT.Text = TongHDB;
					}
					else MessageBox.Show("Không tồn tại khách hàng có cùng tên với tên bạn vừa nhập", "Thông báo");



				}
				else
				{
					MessageBox.Show("Hãy nhập tên khách hàng", "Thông báo");
				}

			}
			else if (rdbTheoNV.Checked == true)
			{
				if (txtNameNV.Text.Trim() != "")
				{
					string name = txtNameNV.Text;
					DataTable DSNV = pd.DocBang("select MaNV from NhanVien where TenNV like N'%" + name + "%' ");

					DataTable Dem = pd.DocBang("select count(MaNV) from NhanVien where TenNV like N'%" + name + "%' ");
					int n = int.Parse((Dem.Rows[0])[0].ToString());

					if (n > 0)
					{
						string s = "";
						string[] DSMaNV = new string[n + 1];
						s = "Where MaNV = '" + (DSNV.Rows[0])[0].ToString() + "' ";
						for (int i = 1; i < n; i++)
						{
							DSMaNV[i] = (DSNV.Rows[i])[0].ToString();
							s += "or MaNV ='" + DSMaNV[i] + "' ";
						}


						dkDT = s;
						string sql = "Select * from HoaDonBan " + dkDT;
						dgvDoanhThu.DataSource = pd.DocBang(sql);

						DataTable dt = pd.DocBang("Select sum(TongTien) as tongtien, count(SoHDB) from HoaDonBan " + dkDT);
						TongDT = (dt.Rows[0])[0].ToString();
						txtTongDT.Text = TongDT + " vnd";

						TongHDB = (dt.Rows[0])[1].ToString();
						txtTongHD_DT.Text = TongHDB;
					}
					else MessageBox.Show("Không tồn tại nhân viên có cùng tên với tên bạn vừa nhập", "Thông báo");
				}
				else
				{
					MessageBox.Show("Hãy nhập tên nhân viên", "Thông báo");
				}
			}
		}

		private void btnThoatDT_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void btnHienThiCT_HDB_Click(object sender, EventArgs e)
		{

			string SoHDB = txtMaHDB_DT.Text;
			if (SoHDB == "")
			{
				MessageBox.Show("Hãy nhập mã số hóa đơn bán", "Thông báo");
			}
			else
			{
				string sql = "Select SoHDB, DMTiVi.MaTV, TenTV, DonGiaBan, ChiTietHDB.SoLuong, GiamGia, ThanhTien from ChiTietHDB join DMTiVi on DMTiVi.MaTV = ChiTietHDB.MaTV where SoHDB = '" + SoHDB + "'";

				string check_count = "Select count(MaTV) from ChiTietHDB where SoHDB = '" + SoHDB + "'";
				string dem_count = (pd.DocBang(check_count).Rows[0])[0].ToString();
				if (int.Parse(dem_count) > 0)
				{
					dgvDoanhThu.DataSource = pd.DocBang(sql);

					DataTable dt = pd.DocBang("Select TongTien from HoaDonBan  where SoHDB ='" + SoHDB + "'");
					String TongCT_HDB = (dt.Rows[0])[0].ToString();
					txtTongDT.Text = TongCT_HDB + " vnd";

					txtTongHD_DT.Text = "1";
				}
				else
				{
					MessageBox.Show("Không tìm thấy dữ liệu trùng lặp với dữ liệu bạn vừa nhập", "Thông báo");
				}



			}
		}

		private void btnLocDT_Click(object sender, EventArgs e)
		{


			if (rdbTangDan.Checked == false && rdbGiamDan.Checked == false)
			{
				MessageBox.Show("Vui lòng chọn điều kiện sắp xếp");
			}
			else if (rdbTangDan.Checked == true)
			{

				string sql = "Select * from HoaDonBan " + dkDT + " order by TongTien";
				dgvDoanhThu.DataSource = pd.DocBang(sql);

				txtTongDT.Text = TongDT + " vnd";

				txtTongHD_DT.Text = TongHDB;
			}
			else if (rdbGiamDan.Checked == true)
			{
				string sql = "Select * from HoaDonBan " + dkDT + " order by TongTien DESC";
				dgvDoanhThu.DataSource = pd.DocBang(sql);
				txtTongDT.Text = TongDT + " vnd";

				txtTongHD_DT.Text = TongHDB;
			}
		}

		private void btnLuuSP_Click(object sender, EventArgs e)
		{
			table = pd.DocBang("select * from DMTivi");
			if (table.Rows.Count > 0)
			{
				Excel.Application exApp = new Excel.Application();
				Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
				Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

				Excel.Range tenDanhSach = (Excel.Range)exSheet.Cells[5, 2];
				exSheet.get_Range("B5:G5").Merge(true);
				tenDanhSach.Font.Size = 12;
				tenDanhSach.Font.Bold = true;
				tenDanhSach.Font.Color = Color.Blue;
				tenDanhSach.Value = "DANH SÁCH TIVI";

				exSheet.get_Range("A7:G7").Font.Bold = true;
				exSheet.get_Range("A7:G7").HorizontalAlignment =
					Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
				exSheet.get_Range("A7").Value = "STT";
				exSheet.get_Range("B7").Value = "Mã tivi";
				exSheet.get_Range("C7").Value = "Tên tivi";
				exSheet.get_Range("C7").ColumnWidth = 20;
				exSheet.get_Range("D7").Value = "Đơn giá nhập";
				exSheet.get_Range("E7").Value = "Đơn giá bán";
				exSheet.get_Range("F7").Value = "Thời gian BH";
				exSheet.get_Range("G7").Value = "Mã kiểu";
				exSheet.get_Range("H7").Value = "Mã mẫu";
				exSheet.get_Range("I7").Value = "Mã MH";
				exSheet.get_Range("J7").Value = "Mã cỡ";
				exSheet.get_Range("K7").Value = "Mã nước SX";
				for (int i = 0; i < table.Rows.Count; i++)
				{
					exSheet.get_Range("A" + (i + 12).ToString() + ":K" + (i + 12).ToString()).Font.Bold = false;
					exSheet.get_Range("A" + (i + 12).ToString()).Value = (i + 1).ToString();
					exSheet.get_Range("B" + (i + 12).ToString()).Value = table.Rows[i]["MaTV"].ToString();
					exSheet.get_Range("C" + (i + 12).ToString()).Value = table.Rows[i]["TenTv"].ToString();
					exSheet.get_Range("D" + (i + 12).ToString()).Value = table.Rows[i]["DonGiaNhap"].ToString();
					exSheet.get_Range("E" + (i + 12).ToString()).Value = table.Rows[i]["DonGiaBan"].ToString();
					exSheet.get_Range("F" + (i + 12).ToString()).Value = table.Rows[i]["ThoiGianBH"].ToString();
					exSheet.get_Range("G" + (i + 12).ToString()).Value = table.Rows[i]["MaKieu"].ToString();
					exSheet.get_Range("H" + (i + 12).ToString()).Value = table.Rows[i]["MaMau"].ToString();
					exSheet.get_Range("I" + (i + 12).ToString()).Value = table.Rows[i]["MaMH"].ToString();
					exSheet.get_Range("J" + (i + 12).ToString()).Value = table.Rows[i]["MaCo"].ToString();
					exSheet.get_Range("K" + (i + 12).ToString()).Value = table.Rows[i]["MaNuocSX"].ToString();
				}
				exSheet.Name = "TiVi";
				exBook.Activate();
				saveDSTV.Filter = "Excel Document(*.xls)|*.xls |Word Document(*.doc) \r\n|*.doc|All files(*.*)|*.*";
				saveDSTV.FilterIndex = 1;
				saveDSTV.AddExtension = true;
				saveDSTV.DefaultExt = ".xls";
				if (saveDSTV.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					exBook.SaveAs(saveDSTV.FileName.ToString());
				exApp.Quit();
			}
			else
			{
				MessageBox.Show("Không có danh sách để in");
			}
		}
	}
}
