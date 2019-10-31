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
    public class IndexModel : PageModel
    {
        private readonly Navistar2.Data.ApplicationDbContext _context;

        public IndexModel(Navistar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DeptOwner> DeptOwner { get;set; }

        public async Task OnGetAsync()
        {
            DeptOwner = await _context.DeptOwner.ToListAsync();
        }
    }
}
