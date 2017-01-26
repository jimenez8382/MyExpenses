using System.Collections.Generic;
using System.Linq;
namespace Services
{
    public interface IExpensesServices
    {
        List<Expenses> GetExpenses();
    }
    public class ExpensesServices : IExpensesServices
    {
        private readonly ExpensesDbContext _db;
        public TotalExpensesServices(ExpensesDbContext db)
        {
            this._db = db;
        }


        public List<Expenses> GetExpenses()
        {
            return _db.Expens.ToList();
        }
        
    }
}
