using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Navistar2.Data;

namespace Navistar2.Pages.myDeptDetail
{
    public class DetailsModel : PageModel
    {
        private readonly Navistar2.Data.ApplicationDbContext _context;

        public DetailsModel(Navistar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public DepartmentDetail DepartmentDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DepartmentDetail = await _context.DepartmentDetail.FirstOrDefaultAsync(m => m.DDID == id);

            if (DepartmentDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
