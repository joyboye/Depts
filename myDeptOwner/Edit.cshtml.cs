using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Navistar2.Data;

namespace Navistar2.Pages.myDeptOwner
{
    public class EditModel : PageModel
    {
        private readonly Navistar2.Data.ApplicationDbContext _context;

        public EditModel(Navistar2.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeptOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptOwnerExists(DeptOwner.DOID))
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

        private bool DeptOwnerExists(int id)
        {
            return _context.DeptOwner.Any(e => e.DOID == id);
        }
    }
}
