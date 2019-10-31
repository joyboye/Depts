using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Navistar2.Data
{
    public class DeptOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DOID { get; set; }

        [Display(Name = "Department Owner")]
        public string Department_Owner { get; set; }

        [Display(Name = "Department Number")]
        public int DepartmentNumber { get; set; }

        [Display(Name = "Department Description")]
        public string Department_description { get; set; }

        [Display(Name = "Finance Department")]
        public int Finance_Department { get; set; }

        [Display(Name = "Employee Record Number")]
        public int Employee_Record_Number { get; set; }

        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Display(Name = "Supervisor Name")]
        public string Supervisor_Name { get; set; }

        [Display(Name = "Job Title")]
        public string Job_Title { get; set; }

        public string Employee { get; set; }

        public string Contractor { get; set; }
    }
}
