using Domain.Interfaces.Id;
using Domain.Interfaces.Log;
using Domain.Models.Log;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Entities.Log;
using Infrastructure.Persistence.Interfaces;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Repositories.Log
{
    public class PersonRepository : IPersonRepo, IBaseMapper<PersonModel, PersonEntity>
    {
        readonly AppSettings appSettings;
        readonly IPersonRepo _personRepo;
        readonly MiK8sContext _context;
        readonly IGenerateIdUseCase _generateId;
        public PersonRepository(IOptions<AppSettings> options, PersonRepository personRepo, MiK8sContext context, IGenerateIdUseCase generateId)
        {
            appSettings = options.Value;
            _personRepo = personRepo;
            _context = context;
            _generateId = generateId;
        }

        public PersonModel GetById(string id)
        {
            var person = _context.Persons.First(p => p.Id == id);

            return ConvertToModel(person);
        }

        public PersonModel Save(PersonModel personModel)
        {
            personModel.Id = _generateId.GenerateGuId();
            var entity = ConvertToEntity(personModel);

            _context.Persons.Add(entity);

            return ConvertToModel(entity);
        }

        public string[] GetNames()
        {
            var names = appSettings.Nombres;
            return names;
        }

        public PersonEntity ConvertToEntity(PersonModel Model)
        {
            throw new NotImplementedException();
        }

        public PersonModel ConvertToModel(PersonEntity entity)
        {
            throw new NotImplementedException();
        }

        PersonModel IPersonRepo.Delete(string id)
        {
            throw new NotImplementedException();
        }



        PersonModel IPersonRepo.Update(PersonModel personModel)
        {
            throw new NotImplementedException();
        }
    }
}
