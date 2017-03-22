using DistributedCache.MVC4WebAppQuickStart.Models;

namespace DistributedCache.MVC4WebAppQuickStart.Services
{
    public interface IPersonService
    {
        string SayHello();

        PersonModel GetById(int id);
    }
}