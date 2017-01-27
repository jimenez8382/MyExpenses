﻿using Services;
using Services.Models.Expenses;
using System;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ExpenseItem());
        }
        [HttpPost]
        public ActionResult Create(ExpenseItem model)
        {
          
            ////To display an error use
            //this.TempData["NotificationCSS"] = "notificationbox nb-error";

            ////To display a warning use
            //this.TempData["NotificationCSS"] = "notificationbox nb-warning";
            try
            {
                var itemAdded = _service.AddItem(model);
                this.TempData["Notification"] = "Your record was created successfully.";
                this.TempData["NotificationClass"] = "notificationbox notibox-success";
            }
            catch (Exception ex)
            {
                this.TempData["Notification"] = "We had a problem to save your Record,Verify your information and try again.";
                this.TempData["NotificationClass"] = "notificationbox notibox-error";
            }
            return RedirectToAction("Index");
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long Id)
        {
            // find the row we need to update and return new ExpenseItem
            var item = _service.GetItem(Id);
            var editIt = new ExpenseItem
            {
                Expenses = item.Amount,
                Date = item.Date,
                Decription = item.Description,
                ExpensesId = item.Id
            };
            return View(editIt);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(ExpenseItem model)
        {
            try
            {
                var item = _service.EditItem(model);
                this.TempData["Notification"] = "Your record was updated successfully.";
                this.TempData["NotificationClass"] = "notificationbox notibox-success";
            }
            catch (Exception ex)
            {
                this.TempData["Notification"] = "We had a problem to Update your Record,Verify your information and try again.";
                this.TempData["NotificationClass"] = "notificationbox notibox-error";
            }
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Delete(long Id)
        {
            try
            {
                var item = _service.DeleteItem(Id);
                this.TempData["Notification"] = "Your record was deleted successfully.";
                this.TempData["NotificationClass"] = "notificationbox notibox-success";
            }
            catch (Exception ex)
            {
                this.TempData["Notification"] = "We had a problem to delete your Record,try again.";
                this.TempData["NotificationClass"] = "notificationbox notibox-error";
            }
            return RedirectToAction("Index");
        }
    }
}