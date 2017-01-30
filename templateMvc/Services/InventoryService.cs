using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BondDataLayer;
using templateMvc.Models;

namespace templateMvc.Services
{
    public class InventoryService : IInventoryService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public List<BONDINFO> BondInformation
        {
            get { return _context.BONDINFOes.ToList(); }

        }
    }
}