using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_Demo
{
    public partial class FormTuyChon : Form
    {
        private QuanLySinhVien quanLySinhVien;
        private ListView listView;

        public FormTuyChon()
        {
            InitializeComponent();
        }

        public FormTuyChon(QuanLySinhVien quanLySinhVien, ListView listView, string loai)
        {
            InitializeComponent();
            this.quanLySinhVien = quanLySinhVien;
            this.listView = listView;

            if (loai == "search")
            {
                btnSapXep.Enabled = false;
            }    
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTuyChon_Load(object sender, EventArgs e)
        {

        }

        private void TimKiem_Click(object sender, EventArgs e)
        {
            SinhVien sv = null;

            if (rdMaSV.Checked)
                sv = quanLySinhVien.DanhSach.Find(s => s.MaSo.Trim() == txtTimKiem.Text.Trim());
            else if (rdHoTen.Checked)
                sv = quanLySinhVien.DanhSach.Find(s => s.HoTen.Contains(txtTimKiem.Text.Trim()));
            else if (rdNgaySinh.Checked)
                sv = quanLySinhVien.DanhSach.Find(s => s.NgaySinh.Day == int.Parse(txtTimKiem.Text));

            if (sv is null)
            {
                MessageBox.Show("Khong tim thay SV", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Close();

            ListViewItem item = new ListViewItem(sv.MaSo);
            item.SubItems.Add(sv.HoTen);
            item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sv.DiaChi);
            item.SubItems.Add(sv.Lop);
            item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
            item.SubItems.Add(String.Join(", ", sv.ChuyenNganh));
            item.SubItems.Add(sv.Hinh);

            listView.Items.Clear();
            listView.Items.Add(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rdNgaySinh.Checked)
            {
                quanLySinhVien.DanhSach.Sort(new SinhVienSortNgaySinh());
            }
            else if (rdHoTen.Checked)
            {
                quanLySinhVien.DanhSach.Sort(new SinhVienSortHoTen());
            }
            else if (rdMaSV.Checked)
            {
                quanLySinhVien.DanhSach.Sort(new SinhVienSortMaSo());
            }

            listView.Items.Clear();
            foreach (var sv in quanLySinhVien.DanhSach)
            {
                ListViewItem item = new ListViewItem(sv.MaSo);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(String.Join(", ", sv.ChuyenNganh));
                item.SubItems.Add(sv.Hinh);

                listView.Items.Add(item);
            }

            this.Close();
        }
    }
 }

