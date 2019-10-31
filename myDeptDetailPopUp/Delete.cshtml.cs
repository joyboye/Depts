using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Navistar2.Data;

namespace Navistar2.Pages.myDeptDetailPopUp
{
    public class DeleteModel : PageModel
    {
        private readonly Navistar2.Data.ApplicationDbContext _context;

        public DeleteModel(Navistar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeptDetailPopUp DeptDetailPopUp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeptDetailPopUp = await _context.DeptDetailPopUp.FirstOrDefaultAsync(m => m.DID == id);

            if (DeptDetailPopUp == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeptDetailPopUp = await _context.DeptDetailPopUp.FindAsync(id);

            if (DeptDetailPopUp != null)
            {
                _context.DeptDetailPopUp.Remove(DeptDetailPopUp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
