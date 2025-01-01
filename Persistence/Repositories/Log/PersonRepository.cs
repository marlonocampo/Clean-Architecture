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

        PersonModel IPersonRepo.Delete(string id)
        {
            if (!Exist(id))
            {
                throw new Exception("Person not found");
            }

            var index = _context.Persons.FindIndex(p => p.Id == id);

            _context.Persons[index].IsDeleted = true;

            return ConvertToModel(_context.Persons[index]);
        }



        PersonModel IPersonRepo.Update(PersonModel personModel)
        {
            if (!Exist(personModel.Id))
            {
                throw new Exception("Person not found");
            }

            var index = _context.Persons.FindIndex(p => p.Id == personModel.Id);

            var entity = new PersonEntity()
            {
                DNI = personModel.DNI,
                Name = personModel.Name,
                Id = personModel.Id,
                IsDeleted = personModel.IsDeleted
            };

            _context.Persons[index] = entity;
            return ConvertToModel(entity);
        }


        public bool Exist(string id)
        {
            return _context.Persons.Any(p => p.Id == id);
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
    }
}
