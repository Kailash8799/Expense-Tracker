using Expense.DataAccess.Data;
using Expense.DataAccess.Repository.IRepository;
using Expense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.DataAccess.Repository {
    public class TransactionRepository : ITransactionRepository {
        private readonly AppDbContext _context;
        public TransactionRepository(AppDbContext context) {
            _context = context;
        }

        public void CreateTransition(Transaction transaction) {
            _context.Transactionset.Add(transaction);
            _context.SaveChanges();
            return;
        }

        public void DeleteTransition(Transaction transaction) {
            _context.Transactionset.Remove(transaction);
            _context.SaveChanges();
            return;
        }

        public Transaction? GetTransactionById(int id) {
            return _context.Transactionset.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Transaction> GetTransactions(int id) {
            Console.WriteLine(id);
            return _context.Transactionset.Where(u=>u.UserId == id);
        }

        public void UpdateTransition(Transaction transaction) {
            _context.Transactionset.Update(transaction);
            _context.SaveChanges();
            return;
        }
    }
}
