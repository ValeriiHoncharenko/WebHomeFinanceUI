using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomeFinanceUI.Data
{
    public interface INameTransactionService
    {
        Task<List<RootObject>> OnGetAsync();     
    }
}
