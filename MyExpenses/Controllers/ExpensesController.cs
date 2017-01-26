using Services;
using Services.Models.Expenses;
using System.Web.Mvc;

namespace MyExpenses.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesServices _service;
        public ExpensesController(IExpensesServices service)
        {
            this._service = service;
        }
        public ActionResult Index()
        {
            return View(_service.GetExpenses());

        }
    }
}