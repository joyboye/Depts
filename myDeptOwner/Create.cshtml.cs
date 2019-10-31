﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Navistar2.Data;

namespace Navistar2.Pages.myDeptOwner
{
    public class CreateModel : PageModel
    {
        private readonly Navistar2.Data.ApplicationDbContext _context;

        public CreateModel(Navistar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeptOwner DeptOwner { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeptOwner.Add(DeptOwner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}