using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Navistar2.Data
{
    public class DeptDetailPopUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID{ get; set; }
        public string SLT { get; set; }
        public int Department { get; set; }
        public string Department_description { get; set; }
        public int Finance_Department { get; set; }
        public int Employee_Record_Number { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Supervisor_Name { get; set; }
        public string Job_Title { get; set; }

        public string Employee { get; set; }
        public string Contractor { get; set; }
        
    }
}
