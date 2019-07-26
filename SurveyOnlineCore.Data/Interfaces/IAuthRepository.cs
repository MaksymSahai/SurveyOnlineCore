using SurveyOnlineCore.Data.Entities;
using System.Threading.Tasks;

namespace SurveyOnlineCore.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<Customers> Register(Customers customer, string password);
        Task<Customers> Login(string customerName, string password);
        Task<bool> CustomerExists(string customerName);
    }
}
