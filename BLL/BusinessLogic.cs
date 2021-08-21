using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;
namespace BLL
{
    public class BusinessLogic
    {
        private static BusinessLogic _Instance;
        public static BusinessLogic Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BusinessLogic();
                }
                return _Instance;
            }
        }
        private BusinessLogic()
        {
        }
        public void SetCBB(ComboBox cb)
        {
            cb.Items.Add(new CbbItem
            {
                _Value = 0,
                _Text = "ALL"
            });
            QlsvContext db = new QlsvContext();
            foreach(LSH i in db.LSHs)
            {
                cb.Items.Add(new CbbItem
                {
                    _Text = i.Name,
                    _Value = i.IdLop
                });
            }
            cb.SelectedIndex = 0;
        }
        public void SetCBBForm2(ComboBox cb)
        {
            QlsvContext db = new QlsvContext();
            foreach (LSH i in db.LSHs)
            {
                cb.Items.Add(new CbbItem
                {
                    _Text = i.Name,
                    _Value = i.IdLop
                });
            }
        }
        public void SetCBBSort(ComboBox cb)
        {
            cb.Items.AddRange(new CbbItem[]
            {
               new CbbItem{_Text = "Desc - MSSV",_Value = 1},
               new CbbItem{_Text = "Asc - MSSV",_Value = 2},
               new CbbItem{_Text = "Desc - Name",_Value = 3},
               new CbbItem{_Text = "Asc - Name",_Value = 4}
            });
        }
        public void SortSV(DataGridView dgv, ComboBox cbSort , ComboBox cbLSH, string search)
        {
            if (cbSort.SelectedIndex == -1) return;
            int idLop = ((CbbItem)cbLSH.SelectedItem)._Value;
            CbbItem sortType = cbSort.SelectedItem as CbbItem;
            int idSort = sortType._Value;
            List<SV> list = getListSvByIdAndName(idLop, search);
            switch (idSort)
            {
                case 1:
                    list.Sort(
                        delegate(SV s1, SV s2)
                        {
                            return s1.Mssv < s2.Mssv? 1: -1;
                        }   
                    );
                    dgv.DataSource = list;
                    break;
                case 2:
                    list.Sort(
                        delegate (SV s1, SV s2)
                        {
                            return s1.Mssv > s2.Mssv ? 1 : -1;
                        }
                    );
                    dgv.DataSource = list;
                    break;
                case 3:
                    list.Sort(
                        delegate (SV s1, SV s2)
                        {
                            if (s1.Name == null && s2.Name == null) return 0;
                            else if (s1.Name == null) return 1;
                            else if (s2.Name == null) return -1;
                            else return s2.Name.CompareTo(s1.Name);
                        }
                        
                    );
                    dgv.DataSource = list;
                    break;
                case 4:
                    list.Sort(
                        delegate (SV s1, SV s2)
                        {
                            if (s1.Name == null && s2.Name == null) return 0;
                            else if (s1.Name == null) return -1;
                            else if (s2.Name == null) return 1;
                            else return s1.Name.CompareTo(s2.Name);
                        }
                    );
                    dgv.DataSource = list;
                    break;
            }
        }
        public void Delete(DataGridView dgv)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    QlsvContext db = new QlsvContext();
                    foreach (DataGridViewRow i in dgv.SelectedRows)
                    {
                        DialogResult result = MessageBox.Show("Muốn xóa sv: " + i.Cells["Name"].Value.ToString() + "?",
                        "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes) {
                            int mssv = int.Parse(i.Cells["Mssv"].Value.ToString());
                            SV svdel = db.SVs.Find(mssv);
                            db.SVs.Remove(svdel);
                            db.SaveChanges();
                        }
                        
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<SV> getListSvByIdAndName(int id, string name)
        {
            QlsvContext db = new QlsvContext();
            if (id == 0)
            {
                if (string.IsNullOrEmpty(name))
                {
                    return db.SVs.ToList();
                }
                else
                {
                    return db.SVs.Where(s => s.Name.Contains(name)).ToList();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(name))
                {
                    return db.SVs.Where(s => s.IdLop == id).ToList();
                }
                else
                {
                    return db.SVs.Where(s => s.IdLop == id && s.Name.Contains(name)).ToList();
                }
            }
        }
        public bool AddOrEdit(SV sv, int? mssvOfForm2)
        {
            if (mssvOfForm2 == null)
            {
                return Add(sv);
            }
            else
            {
                return Edit(sv);
            }
        }
        public bool Add(SV sv)
        {
            try
            {
                QlsvContext db = new QlsvContext();
                db.SVs.Add(sv);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool Edit(SV sv)
        {
            try
            {
                QlsvContext db = new QlsvContext();
                SV svEdit = db.SVs.Find(sv.Mssv);
                svEdit.Name = sv.Name;
                svEdit.Gender = sv.Gender;
                svEdit.BirthDay = sv.BirthDay;
                svEdit.IdLop = sv.IdLop;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
