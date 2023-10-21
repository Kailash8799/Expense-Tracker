using Expense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.DataAccess.Repository.IRepository {
    public interface ITransactionRepository {
        public void CreateTransition(Transaction transaction);
        public void UpdateTransition(Transaction transaction);
        public void DeleteTransition(Transaction transaction);
        public IEnumerable<Transaction> GetTransactions();
        public Transaction? GetTransactionById(int id);


    }
}
