
using System;
using System.Collections.Generic;
using System.Linq;
using DistributedCache.MVC4WebAppQuickStart.Models;
using Spring.Caching;

namespace DistributedCache.MVC4WebAppQuickStart.Services
{
    public class PersonService : IPersonService
    {
        static List<PersonModel> PersonList;

        static PersonService()
        {
            PersonList = new List<PersonModel>();

            for (int i = 1; i <= 100; i++)
            {
                PersonList.Add(new PersonModel()
                {
                    Id = i,
                    Name = $"姓名—{i}",
                    Age = i
                });
            }
        }

        [CacheResult("DistributedCache", "'DistributedCache.MVC4WebAppQuickStart.Services.PersonService.SayHello'", TimeToLive = "2m")]
        public string SayHello()
        {
            return $"Hello_ currTime:{DateTime.Now}";
        }

        [CacheResult("DistributedCache", "'DistributedCache.MVC4WebAppQuickStart.Services.PersonService.SayHello-' + #id", TimeToLive = "2m")]
        public PersonModel GetById(int id)
        {
            return PersonList.FirstOrDefault(p => p.Id == id);
        }

    }
}