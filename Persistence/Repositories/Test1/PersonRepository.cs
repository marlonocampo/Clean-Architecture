using Domain.Interfaces.Test1;
using Domain.Models.Test1;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories.Test1
{
    public class PersonRepository : IPersonRepo
    {
        readonly AppSettings appSettings;
        public PersonRepository(IOptions<AppSettings> options) 
        { 
            appSettings = options.Value;
        }
        public string[] GetNames()
        {
            var names = appSettings.Nombres;
            return names;
        }
    }
}
 