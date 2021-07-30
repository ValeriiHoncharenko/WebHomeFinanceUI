using System;

namespace WebHomeFinanceUI.Data
{
    public class RootObjectReport
    {        
            public int Id { get; set; }
            public DateTime DateTransaction { get; set; }
            public string Name { get; set; }
            public string TypeTransaction { get; set; }
            public decimal Amount { get; set; }      

    }
}
