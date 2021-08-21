using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("SinhVien")]
    public class SV
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Mssv { get; set; }

        [Column("TenSV")]
        public string Name { get; set; }

        [Column("NgaySinh",TypeName ="Date")]
        public DateTime BirthDay { get; set; }

        [Column("GioiTinh")]
        public bool Gender { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int IdLop { get; set; }

        [ForeignKey("IdLop")]
        public virtual LSH LSH { get; set; }
    }
}
