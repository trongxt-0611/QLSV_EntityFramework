using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    class CreateDB: CreateDatabaseIfNotExists<QlsvContext>
    {
        protected override void Seed(QlsvContext context)
        {
            context.LSHs.AddRange(new LSH[]
            {
                new LSH{IdLop =1, Name = "CNTT_Nhat1"},
                new LSH{IdLop =2, Name = "CNTT_Nhat2"}
            });
            context.SVs.AddRange(new SV[]
            {
                new SV{Mssv = 102190342, Name ="Tran Xuan Trong", BirthDay = DateTime.Now.Date,Gender = false, IdLop=1},
                new SV{Mssv = 102190322, Name ="Tran Thi Trong", BirthDay = DateTime.Now.Date,Gender = true, IdLop=1},
                new SV{Mssv = 102190333, Name ="Nguyen Van Trong", BirthDay = DateTime.Now.Date,Gender = false, IdLop=2}
            });
        }
    }
}
