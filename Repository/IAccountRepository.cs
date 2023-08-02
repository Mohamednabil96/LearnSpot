using TaskDay2.Models;

namespace TaskDay2.Repository
{
    public interface IAccountRepository
    {
        bool Find(string username, string password);
        Account Get(string username, string password);
        void Create(Account account);
        void Save();
        string GetRoles(int id);
    }
}
