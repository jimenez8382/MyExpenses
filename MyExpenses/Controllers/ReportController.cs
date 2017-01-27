using Services;
using Services.Models.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyExpenses.Controllers
{
    public class ReportController : Controller
    {
        private readonly IExpensesServices _service;
        public ReportController(IExpensesServices service)
        {
            this._service = service;
        }

        // GET: Report
        [HttpGet]
        public ActionResult Index(ExpenseReport model)
        {
            // The generated report will show all records inserted between April 1 of the given year and April 1 of the next year.
            if (model.FiscalYear > 0)
            {
                string date = "04/01/" + model.FiscalYear.ToString();
                DateTime dtInitial = Convert.ToDateTime(date);
                DateTime dtEnd = Convert.ToDateTime(date).AddYears(1);
                var report = _service.GetExpenses().Where(x => x.Date >= dtInitial).Where(x => x.Date < dtEnd).ToList();
                var ItemList = new ExpenseReport();
                foreach (var item in report)
                {
                    ItemList.Report.Add(new ExpenseItem{
                        Date = item.Date,
                        Description = item.Description,
                        Amount = item.Amount,
                        ExpensesId = item.Id
                    });
                }
                return View(ItemList);
            }
            else
            {
                return View(new  ExpenseReport());
            }
        }
        
    }
}