using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BondDataLayer;

namespace templateMvc.Services
{
    public interface IInventoryService
    {
        List<BONDINFO> BondInformation { get; }
    }
}
