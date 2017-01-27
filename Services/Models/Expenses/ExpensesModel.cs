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
        public double Amount { get; set; }

        [Required]
        [Display(Name = "Decription")]
        public string Description { get; set; }
    }

    public class ExpenseReport
    {
        public ExpenseReport()
        {
            Report = new List<ExpenseItem>();
        }
        [Required]
        [Display(Name = "Fiscal Year")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int FiscalYear { get; set; }
        public List <ExpenseItem> Report { get; set; }
    }
}
