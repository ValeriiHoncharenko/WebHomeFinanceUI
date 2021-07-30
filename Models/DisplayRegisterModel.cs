using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomeFinanceUI.Models
{
    public class DisplayRegisterModel
    {
        public int Id { get; set; }
        [Required]
     
        public DateTime DateTransaction { get; set; }
       
        [Required]        
        public int NameTransactionId { get; set; }

        [Required]      
        public decimal Amount { get; set; }
    }
}
