using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Navistar2.Data;

namespace Navistar2.Pages.myDeptDetailPopUp
{
    public class EditModel : PageModel
    {
        private readonly Navistar2.Data.ApplicationDbContext _context;

        public EditModel(Navistar2.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeptDetailPopUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptDetailPopUpExists(DeptDetailPopUp.DID))
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

        private bool DeptDetailPopUpExists(int id)
        {
            return _context.DeptDetailPopUp.Any(e => e.DID == id);
        }
    }
}
