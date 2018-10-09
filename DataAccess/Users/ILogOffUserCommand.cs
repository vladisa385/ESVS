using System.Threading.Tasks;

namespace DataAccess.Users
{
    public interface ILogOffUserCommand
    {
        Task ExecuteAsync();
    }
}
