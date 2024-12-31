using Domain.Interfaces.Test1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test1
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
