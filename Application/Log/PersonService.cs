using Domain.Interfaces.Log;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Log
{
    public class PersonService : IPersonUseCase
    {
        readonly IPersonRepo _personRepo;
        public PersonService(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public string[] GetNames()
        {
            return _personRepo.GetNames();
        }

    }
}
