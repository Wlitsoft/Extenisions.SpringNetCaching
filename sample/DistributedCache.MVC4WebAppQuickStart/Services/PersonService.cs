
using System;
using Spring.Caching;

namespace DistributedCache.MVC4WebAppQuickStart.Services
{
    public class PersonService : IPersonService
    {
        [CacheResult("DistributedCache", "'DistributedCache.MVC4WebAppQuickStart.Services.PersonService.SayHello'", TimeToLive = "2m")]
        public string SayHello()
        {
            return $"Hello_ currTime:{DateTime.Now}";
        }
    }
}