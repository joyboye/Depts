using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Navistar2.Data
{
    public class DepartmentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DDID { get; set; }
        public string Month { get; set; }
        public int Approved { get; set; }
        public int Employee { get; set; }
        public int Contractor { get; set; }
        public int Open { get; set; }
    }
}
