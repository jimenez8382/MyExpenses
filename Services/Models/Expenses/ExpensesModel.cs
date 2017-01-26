using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Expenses
{
    public class ExpenseItem
    {
        public ExpenseItem()
        {
        }
        public long ExpensesId { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Expenses")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double Expenses { get; set; }

        [Required]
        [Display(Name = "Decription")]
        public string Decription { get; set; }
    }
}
