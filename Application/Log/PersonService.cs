using Domain.Interfaces.Log;
using Domain.Models.Log;

namespace Application.Log
{
    public class PersonService : IPersonUseCase
    {
        readonly IPersonRepo _personRepo;
        public PersonService(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public PersonModel GetById(string id)
        {
            return _personRepo.GetById(id);
        }

        public PersonModel Save(PersonModel personModel)
        {
            return _personRepo.Save(personModel);
        }

        public string[] GetNames()
        {
            return _personRepo.GetNames();
        }

    }
}
