using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomeFinanceUI.Models
{
    public class DisplayNameModel
    {
        public int Id { get; set; } = 0;

        [Required]
        [StringLength(30, ErrorMessage = "Type transaction is too long")]
        [MinLength(3, ErrorMessage = "Type transaction is too short")]        
        public string Name { get; set; }
        
        [Required]          
        
        public int TypeTransaction { get; set; } 

    }
}
