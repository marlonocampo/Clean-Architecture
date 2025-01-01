using Domain.Models.Log;
using System;

namespace Domain.Interfaces.Log
{
    public interface IPersonRepo
    {
        public PersonModel Save(PersonModel personModel);
        public PersonModel Update(PersonModel personModel);
        public PersonModel Delete(string id);
        public PersonModel GetById(string id);
        public bool Exist(string id);
        public string[] GetNames();
    }
}
