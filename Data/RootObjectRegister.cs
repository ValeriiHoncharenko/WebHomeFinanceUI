using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomeFinanceUI.Data
{
    public class RootObjectRegister
    {
        public int Id { get; set; }
        public DateTime DateTransaction { get; set; }
        public int NameTransactionId { get; set; }
        public decimal Amount { get; set; }
    }
}
