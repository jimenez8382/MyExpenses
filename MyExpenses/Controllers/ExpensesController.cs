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
        [HttpPost]
        public ActionResult Create(ExpenseItem model)
        {
            this.TempData["Notification"] = "Your record was created successfully.";
            this.TempData["NotificationCSS"] = "notificationbox nb-success";

            ////To display an error use
            //this.TempData["NotificationCSS"] = "notificationbox nb-error";

            ////To display a warning use
            //this.TempData["NotificationCSS"] = "notificationbox nb-warning";

            var itemAdded = _service.AddItem(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ExpenseItem());
        }
    }
}