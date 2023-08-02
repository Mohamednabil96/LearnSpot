using System.Security.Principal;
using TaskDay2.Models;

namespace TaskDay2.Repository
{
    public class AccountRepository : IAccountRepository
    {
        MyDbContext context;
        public AccountRepository(MyDbContext context)
        {
            this.context = context;
        }
        public Account Get(string username, string password)
        {
            return context.Account.FirstOrDefault(a => a.UserName == username && a.Password == password);
        }
        public string GetRoles(int id)
        {
            if (id % 2 == 0)
            {
                return "Admin";
            }
            return "Student";
        }
        public void Create(Account account)
        {
            context.Account.Add(account);
        }

        public bool Find(string username, string password)
        {
            Account acc = context.Account
                .FirstOrDefault(e => e.UserName == username && e.Password == password);
            if (acc != null)
                return true;
            else
                return false;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
