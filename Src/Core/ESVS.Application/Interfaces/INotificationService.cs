using System.Threading.Tasks;
using ESVS.Application.Notifications.Models;

namespace ESVS.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
