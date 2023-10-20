using Expense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.DataAccess.Repository.IRepository {
    public interface IUserRepository {
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
        public User? GetUserById(int id);
        public User? GetUserByEmail(string email);


    }
}
