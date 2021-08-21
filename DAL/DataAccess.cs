using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DataAccess
    {
        private static DataAccess _Instance;
        public static DataAccess Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataAccess();
                }
                return _Instance;
            }
        }
        private DataAccess()
        {
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
            catch (Exception)
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
        public bool Delete(int mssv)
        {
            try
            {
                QlsvContext db = new QlsvContext();
                SV svdel = db.SVs.Find(mssv);
                db.SVs.Remove(svdel);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<SV> GetListSV(int id, string name)
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
    }
}
