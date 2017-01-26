using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Expenses
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Expenses")]
        public double Amount { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
