using Data;
using Data.Models;
using Services.Models.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IExpensesServices
    {
        Expenses AddItem(ExpenseItem model);
        Expenses GetItem(long Id);
        Expenses EditItem(ExpenseItem model);
        bool DeleteItem(long Id);
        List<Expenses> GetExpenses();
    }
    public class ExpensesServices : IExpensesServices
    {
        private readonly ExpensesDbContext _db;
        public ExpensesServices(ExpensesDbContext db)
        {
            this._db = db;
        }


        public List<Expenses> GetExpenses()
        {
            return _db.Expenses.ToList();
        }

        public Expenses AddItem(ExpenseItem model)
        {
            //string date = "04/01/" + FiscalYear.ToString();
            //DateTime dtInitial = Convert.ToDateTime(date);
            //DateTime dtEnd = Convert.ToDateTime(date).AddYears(1);
            //if (model.Date >= dtInitial && model.Date < dtEnd)
            //{

            //}
            long Id = 0;
            var FiscalYear = model.Date.Year;
            if (FiscalYear > 0)
            {
                var Expense = new Expenses()
                {
                    Amount = model.Amount,
                    Description = model.Description,
                    Date = model.Date
                };
                _db.Expenses.Add(Expense);
                _db.SaveChanges();//this generates the Id for customer
                Id = Expense.Id;
                return Expense;
            }
            else
            {
                throw new System.ArgumentException("verify your Information", "Save");
            }
            return new Expenses();
        }

        public Expenses GetItem(long Id)
        {
            return _db.Expenses.Find(Id);
        }

        public Expenses EditItem(ExpenseItem model)
        {
            var Expense = new Expenses()
            {
                Id = model.ExpensesId,
                Amount = model.Amount,
                Description = model.Description,
                Date = model.Date
            };
            // find the record to update
            var entityToUpdate = _db.Expenses.Find(model.ExpensesId);
            if (entityToUpdate != null)
            {
                //set the new values 
                _db.Entry(entityToUpdate).CurrentValues.SetValues(Expense);
                _db.SaveChanges();
            }
            return Expense;
        }

        public bool DeleteItem(long Id)
        { // find the record to delete
            var entityToDelete = _db.Expenses.Find(Id);
            _db.Expenses.Remove(entityToDelete);
            _db.SaveChanges();
            return true;
        }
    }
}
