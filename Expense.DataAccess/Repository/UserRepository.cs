using Expense.DataAccess.Data;
using Expense.DataAccess.Repository.IRepository;
using Expense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.DataAccess.Repository {
    public class UserRepository : IUserRepository {

        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) {
            _db = db;
        }
        public void CreateUser(User user) {
            Console.WriteLine(user);
            _db.Userset.Add(user);
            _db.SaveChanges();
            return;
        }

        public void DeleteUser(User user) {
            _db.Userset.Remove(user);
            _db.SaveChanges();
            return;
        }

        public User? GetUserByEmail(string email) {
            return _db.Userset.FirstOrDefault(x => x.Email == email);
        }

        public User? GetUserById(int id) {
            return _db.Userset.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateUser(User user) {
            _db.Userset.Update(user);
            _db.SaveChanges();
            return;
        }
    }
}
