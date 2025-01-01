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
        readonly MiK8sContext _context;
        readonly IGenerateIdUseCase _generateId;
        public PersonRepository(IOptions<AppSettings> options, MiK8sContext context, IGenerateIdUseCase generateId)
        {
            appSettings = options.Value;
            _context = context;
            _generateId = generateId;
        }

        public PersonModel GetById(string id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new Exception("Person not found");
            }
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
            return new PersonEntity
            {
                Id = Model.Id,
                Name = Model.Name,
                DNI = Model.DNI,
                IsDeleted = Model.IsDeleted
            };
        }

        public PersonModel ConvertToModel(PersonEntity entity)
        {
            return new PersonModel
            {
                Id = entity.Id,
                Name = entity.Name,
                DNI = entity.DNI,
                IsDeleted = entity.IsDeleted
            };
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
