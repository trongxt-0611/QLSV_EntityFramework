using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
using BLL;
using System.Configuration;
namespace QLSV_EF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvDSSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BusinessLogic.Instance.SetCBB(cboLopSH);
            BusinessLogic.Instance.SetCBBSort(cboSortType);
            Show(0, "");

        }
        public void Show(int idLop, string search)
        {
            dgvDSSV.DataSource = BusinessLogic.Instance.getListSvByIdAndName(idLop, search);
            //var svs = BusinessLogic.Instance.getListSvByIdAndName(idLop, search);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            CbbItem cbi = cboLopSH.SelectedItem as CbbItem;
            int idLop = cbi._Value;
            Show(idLop, "");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CbbItem cbi = cboLopSH.SelectedItem as CbbItem;
            int idLop = cbi._Value;
            Show(idLop, txtSearch.Text);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            BusinessLogic.Instance.Delete(dgvDSSV);
            Show(0, "");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int? nothing = null;
            Form2 f2 = new Form2(nothing);
            f2.actionAfterOk += new Form2.MyDel(Show);
            if (f2.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Thêm thành công");
                Show(0,"");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDSSV.SelectedRows.Count != 1) return;
            DataGridViewRow selectedRow = dgvDSSV.SelectedRows[0];
            int mssv = int.Parse(selectedRow.Cells["Mssv"].Value.ToString());
            Form2 f2 = new Form2(mssv);
            f2.actionAfterOk += new Form2.MyDel(Show);
            if (f2.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Sửa thành công");
                Show(0, "");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            BusinessLogic.Instance.SortSV(dgvDSSV, cboSortType, cboLopSH, txtSearch.Text);
        }
    }
}
