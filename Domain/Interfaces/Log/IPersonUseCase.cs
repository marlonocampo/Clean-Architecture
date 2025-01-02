using Domain.Models.Log;

namespace Domain.Interfaces.Log
{
    public interface IPersonUseCase
    {
        public PersonModel GetById(string id);
        public PersonModel Save(PersonModel personModel);
        public PersonModel Update(PersonModel personModel);
        public PersonModel Delete(string id);
        public string[] GetNames();
    }
}
