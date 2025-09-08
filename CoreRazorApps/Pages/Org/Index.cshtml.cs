using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreRazorApps.Models;

namespace CoreRazorApps.Pages.Org
{
    public class IndexModel : PageModel
    {
        private readonly CoreRazorApps.Models.OrgContext _context;

        public IndexModel(CoreRazorApps.Models.OrgContext context)
        {
            _context = context;
        }

        public IList<Organization> Organization { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Organization = await _context.organizations.ToListAsync();
        }
    }
}
