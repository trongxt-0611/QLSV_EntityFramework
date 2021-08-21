using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using DAL;

namespace QLSV_EF
{
    public partial class Form2 : Form
    {
        public delegate void MyDel(int id, string name);
        public MyDel actionAfterOk { get; set; }
        public int? MSSV { get; set; }
        public Form2(int? mssv)
        {
            InitializeComponent();
            this.MSSV = mssv;
            BusinessLogic.Instance.SetCBBForm2(cboLSH);
            setUI();
        }


        public void setUI()
        {
            QlsvContext db = new QlsvContext();
            if (this.MSSV != null)
            {
                SV s = db.SVs.Find(MSSV);
                txtMssv.Text = s.Mssv +"";
                txtNameSv.Text = s.Name;
                dateTimePicker1.Value = s.BirthDay;
                if (s.Gender == true) radFemale.Checked = true;
                else radMale.Checked = true;
                //  cboLSH.SelectedIndex = s.ID_Lop - 1 ;
                int index = 0;
                foreach (CbbItem i in cboLSH.Items)
                {
                    if (s.IdLop == i._Value) break;
                    index++;
                }
                cboLSH.SelectedIndex = index;

                txtMssv.Enabled = false;
                btnOk.Text = "Update";
            }
            else
            {
                txtMssv.Enabled = true;
                btnOk.Text = "Add";
            }

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            SV sv = new SV
            {
                Mssv = int.Parse(txtMssv.Text),
                Name = txtNameSv.Text,
                Gender = radFemale.Checked == true ? true : false,
                BirthDay = dateTimePicker1.Value,
                IdLop = ((CbbItem)cboLSH.SelectedItem)._Value
            };

            if (BusinessLogic.Instance.AddOrEdit(sv, this.MSSV))
            {
                DialogResult = DialogResult.OK;
            }
            else DialogResult = DialogResult.Cancel;
            actionAfterOk(0, null);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
