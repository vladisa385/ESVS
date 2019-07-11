using System.Threading.Tasks;
using ESVS.Application.Interfaces;
using ESVS.Application.Notifications.Models;

namespace ESVS.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message) => 
            Task.CompletedTask;
    }
}
