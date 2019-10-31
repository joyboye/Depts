using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Navistar2.Data;

namespace Navistar2.Pages.myDeptOwner
{
    public class DeleteModel : PageModel
    {
        private readonly Navistar2.Data.ApplicationDbContext _context;

        public DeleteModel(Navistar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeptOwner DeptOwner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeptOwner = await _context.DeptOwner.FirstOrDefaultAsync(m => m.DOID == id);

            if (DeptOwner == null)
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

            DeptOwner = await _context.DeptOwner.FindAsync(id);

            if (DeptOwner != null)
            {
                _context.DeptOwner.Remove(DeptOwner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
