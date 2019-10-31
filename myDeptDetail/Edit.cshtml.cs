using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Navistar2.Data;

namespace Navistar2.Pages.myDeptDetail
{
    public class EditModel : PageModel
    {
        private readonly Navistar2.Data.ApplicationDbContext _context;

        public EditModel(Navistar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DepartmentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentDetailExists(DepartmentDetail.DDID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DepartmentDetailExists(int id)
        {
            return _context.DepartmentDetail.Any(e => e.DDID == id);
        }
    }
}
