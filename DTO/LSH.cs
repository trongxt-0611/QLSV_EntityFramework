using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("LopSH")]
    public class LSH
    {
        public LSH()
        {
            SVs = new HashSet<SV>();
        }
        [Key]
        public int IdLop { get; set; }

        [Column("TenLop")]
        public string Name { get; set; }
        public virtual ICollection<SV> SVs { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
